﻿// <copyright file="JsonParser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helper.Updater
{
    // Copyright (c) 2018 Alex Parker
    // Copyright (c) 2018-2019 Peter Kirmeier

    // Permission is hereby granted, free of charge, to any person obtaining a copy of
    // this software and associated documentation files (the "Software"), to deal in
    // the Software without restriction, including without limitation the rights to
    // use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
    // the Software, and to permit persons to whom the Software is furnished to do so,
    // subject to the following conditions:

    // The above copyright notice and this permission notice shall be included in all
    // copies or substantial portions of the Software.

    // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
    // FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
    // COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
    // IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
    // CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text;

    // Really simple JSON parser in ~300 lines
    // - Attempts to parse JSON files with minimal GC allocation
    // - Nice and simple "[1,2,3]".FromJson<List<int>>() API
    // - Classes and structs can be parsed too!
    //      class Foo { public int Value; }
    //      "{\"Value\":10}".FromJson<Foo>()
    // - Can parse JSON without type information into Dictionary<string,object> and List<object> e.g.
    //      "[1,2,3]".FromJson<object>().GetType() == typeof(List<object>)
    //      "{\"Value\":10}".FromJson<object>().GetType() == typeof(Dictionary<string,object>)
    // - No JIT Emit support to support AOT compilation on iOS
    // - Attempts are made to NOT throw an exception if the JSON is corrupted or invalid: returns null instead.
    // - Only public fields and property setters on classes/structs will be written to
    //
    // Limitations:
    // - No JIT Emit support to parse structures quickly
    // - Limited to parsing <2GB JSON files (due to int.MaxValue)
    // - Parsing of abstract classes or interfaces is NOT supported and will throw an exception.
    public static class JSONParser
    {
        [ThreadStatic]
        private static Stack<List<string>> splitArrayPool;
        [ThreadStatic]
        private static StringBuilder stringBuilder;
        [ThreadStatic]
        private static Dictionary<Type, Dictionary<string, FieldInfo>> fieldInfoCache;
        [ThreadStatic]
        private static Dictionary<Type, Dictionary<string, PropertyInfo>> propertyInfoCache;

        public static T FromJson<T>(this string json)
        {
            // Initialize, if needed, the ThreadStatic variables
            if (propertyInfoCache == null)
            {
                propertyInfoCache = new Dictionary<Type, Dictionary<string, PropertyInfo>>();
            }

            if (fieldInfoCache == null)
            {
                fieldInfoCache = new Dictionary<Type, Dictionary<string, FieldInfo>>();
            }

            if (stringBuilder == null)
            {
                stringBuilder = new StringBuilder();
            }

            if (splitArrayPool == null)
            {
                splitArrayPool = new Stack<List<string>>();
            }

            // Remove all whitespace not within strings to make parsing simpler
            stringBuilder.Length = 0;
            for (int i = 0; i < json.Length; i++)
            {
                char c = json[i];
                if (c == '"')
                {
                    i = AppendUntilStringEnd(true, i, json);
                    continue;
                }

                if (char.IsWhiteSpace(c))
                {
                    continue;
                }

                stringBuilder.Append(c);
            }

            // Parse the thing!
            return (T)ParseValue(typeof(T), stringBuilder.ToString());
        }

        internal static object ParseValue(Type type, string json)
        {
            if (type == typeof(string))
            {
                if (json.Length <= 2)
                {
                    return string.Empty;
                }

                StringBuilder parseStringBuilder = new(json.Length);
                for (int i = 1; i < json.Length - 1; ++i)
                {
                    if (json[i] == '\\' && i + 1 < json.Length - 1)
                    {
                        int j = "\"\\nrtbf/".IndexOf(json[i + 1]);
                        if (j >= 0)
                        {
                            parseStringBuilder.Append("\"\\\n\r\t\b\f/"[j]);
                            ++i;
                            continue;
                        }

                        if (json[i + 1] == 'u' && i + 5 < json.Length - 1)
                        {
                            if (uint.TryParse(json.AsSpan(i + 2, 4), System.Globalization.NumberStyles.AllowHexSpecifier, null, out uint c))
                            {
                                parseStringBuilder.Append((char)c);
                                i += 5;
                                continue;
                            }
                        }
                    }

                    parseStringBuilder.Append(json[i]);
                }

                return parseStringBuilder.ToString();
            }

            if (type.IsPrimitive)
            {
                var result = Convert.ChangeType(json, type, System.Globalization.CultureInfo.InvariantCulture);
                return result;
            }

            if (type == typeof(decimal))
            {
                decimal.TryParse(json, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out decimal result);
                return result;
            }

            if (json == "null")
            {
                return null;
            }

            if (type.IsEnum)
            {
                if (json[0] == '"')
                {
                    json = json[1..^1];
                }

                try
                {
                    return Enum.Parse(type, json, false);
                }
                catch
                {
                    return 0;
                }
            }

            if (type.IsArray)
            {
                Type arrayType = type.GetElementType();
                if (json[0] != '[' || json[^1] != ']')
                {
                    return null;
                }

                List<string> elems = Split(json);
                Array newArray = Array.CreateInstance(arrayType, elems.Count);
                for (int i = 0; i < elems.Count; i++)
                {
                    newArray.SetValue(ParseValue(arrayType, elems[i]), i);
                }

                splitArrayPool.Push(elems);
                return newArray;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type listType = type.GetGenericArguments()[0];
                if (json[0] != '[' || json[^1] != ']')
                {
                    return null;
                }

                List<string> elems = Split(json);
                var list = (IList)type.GetConstructor(new Type[] { typeof(int) }).Invoke(new object[] { elems.Count });
                for (int i = 0; i < elems.Count; i++)
                {
                    list.Add(ParseValue(listType, elems[i]));
                }

                splitArrayPool.Push(elems);
                return list;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                Type keyType, valueType;
                {
                    Type[] args = type.GetGenericArguments();
                    keyType = args[0];
                    valueType = args[1];
                }

                // Refuse to parse dictionary keys that aren't of type string
                if (keyType != typeof(string))
                {
                    return null;
                }

                // Must be a valid dictionary element
                if (json[0] != '{' || json[^1] != '}')
                {
                    return null;
                }

                // The list is split into key/value pairs only, this means the split must be divisible by 2 to be valid JSON
                List<string> elems = Split(json);
                if (elems.Count % 2 != 0)
                {
                    return null;
                }

                var dictionary = (IDictionary)type.GetConstructor(new Type[] { typeof(int) }).Invoke(new object[] { elems.Count / 2 });
                for (int i = 0; i < elems.Count; i += 2)
                {
                    if (elems[i].Length <= 2)
                    {
                        continue;
                    }

                    string keyValue = elems[i][1..^1];
                    object val = ParseValue(valueType, elems[i + 1]);
                    dictionary.Add(keyValue, val);
                }

                return dictionary;
            }

            if (type == typeof(object))
            {
                return ParseAnonymousValue(json);
            }

            if (json[0] == '{' && json[^1] == '}')
            {
                return ParseObject(type, json);
            }

            return null;
        }

        private static int AppendUntilStringEnd(bool appendEscapeCharacter, int startIdx, string json)
        {
            stringBuilder.Append(json[startIdx]);
            for (int i = startIdx + 1; i < json.Length; i++)
            {
                if (json[i] == '\\')
                {
                    if (appendEscapeCharacter)
                    {
                        stringBuilder.Append(json[i]);
                    }

                    stringBuilder.Append(json[i + 1]);
                    i++; // Skip next character as it is escaped
                }
                else if (json[i] == '"')
                {
                    stringBuilder.Append(json[i]);
                    return i;
                }
                else
                {
                    stringBuilder.Append(json[i]);
                }
            }

            return json.Length - 1;
        }

        // Splits { <value>:<value>, <value>:<value> } and [ <value>, <value> ] into a list of <value> strings
        private static List<string> Split(string json)
        {
            List<string> splitArray = splitArrayPool.Count > 0 ? splitArrayPool.Pop() : new List<string>();
            splitArray.Clear();
            if (json.Length == 2)
            {
                return splitArray;
            }

            int parseDepth = 0;
            stringBuilder.Length = 0;
            for (int i = 1; i < json.Length - 1; i++)
            {
                switch (json[i])
                {
                    case '[':
                    case '{':
                        parseDepth++;
                        break;
                    case ']':
                    case '}':
                        parseDepth--;
                        break;
                    case '"':
                        i = AppendUntilStringEnd(true, i, json);
                        continue;
                    case ',':
                    case ':':
                        if (parseDepth == 0)
                        {
                            splitArray.Add(stringBuilder.ToString());
                            stringBuilder.Length = 0;
                            continue;
                        }

                        break;
                }

                stringBuilder.Append(json[i]);
            }

            splitArray.Add(stringBuilder.ToString());

            return splitArray;
        }

        private static object ParseAnonymousValue(string json)
        {
            if (json.Length == 0)
            {
                return null;
            }

            if (json[0] == '{' && json[^1] == '}')
            {
                List<string> elems = Split(json);
                if (elems.Count % 2 != 0)
                {
                    return null;
                }

                var dict = new Dictionary<string, object>(elems.Count / 2);
                for (int i = 0; i < elems.Count; i += 2)
                {
                    dict.Add(elems[i][1..^1], ParseAnonymousValue(elems[i + 1]));
                }

                return dict;
            }

            if (json[0] == '[' && json[^1] == ']')
            {
                List<string> items = Split(json);
                var finalList = new List<object>(items.Count);
                for (int i = 0; i < items.Count; i++)
                {
                    finalList.Add(ParseAnonymousValue(items[i]));
                }

                return finalList;
            }

            if (json[0] == '"' && json[^1] == '"')
            {
                return ParseValue(typeof(string), json); // fix https://github.com/zanders3/json/issues/29
            }

            if (char.IsDigit(json[0]) || json[0] == '-')
            {
                if (json.Contains('.'))
                {
                    double.TryParse(json, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double result);
                    return result;
                }
                else
                {
                    _ = int.TryParse(json, out int result);
                    return result;
                }
            }

            if (json == "true")
            {
                return true;
            }

            if (json == "false")
            {
                return false;
            }

            // handles json == "null" as well as invalid JSON
            return null;
        }

        private static Dictionary<string, T> CreateMemberNameDictionary<T>(T[] members)
            where T : MemberInfo
        {
            Dictionary<string, T> nameToMember = new(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < members.Length; i++)
            {
                /*T member = members[i];
                if (member.IsDefined(typeof(IgnoreDataMemberAttribute), true))
                    continue;

                string name = member.Name;
                if (member.IsDefined(typeof(DataMemberAttribute), true))
                {
                    DataMemberAttribute dataMemberAttribute = (DataMemberAttribute)Attribute.GetCustomAttribute(member, typeof(DataMemberAttribute), true);
                    if (!string.IsNullOrEmpty(dataMemberAttribute.Name))
                        name = dataMemberAttribute.Name;
                }

                nameToMember.Add(name, member);*/
                // The above code is not working with .Net framework 2.0, so we ignore these attributes for compatibility reasons:
                nameToMember.Add(members[i].Name, members[i]);
            }

            return nameToMember;
        }

        private static object ParseObject(Type type, string json)
        {
            object instance = FormatterServices.GetUninitializedObject(type);

            // The list is split into key/value pairs only, this means the split must be divisible by 2 to be valid JSON
            List<string> elems = Split(json);
            if (elems.Count % 2 != 0)
            {
                return instance;
            }

            if (!fieldInfoCache.TryGetValue(type, out Dictionary<string, FieldInfo> nameToField))
            {
                nameToField = CreateMemberNameDictionary(type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy));
                fieldInfoCache.Add(type, nameToField);
            }

            if (!propertyInfoCache.TryGetValue(type, out Dictionary<string, PropertyInfo> nameToProperty))
            {
                nameToProperty = CreateMemberNameDictionary(type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy));
                propertyInfoCache.Add(type, nameToProperty);
            }

            for (int i = 0; i < elems.Count; i += 2)
            {
                if (elems[i].Length <= 2)
                {
                    continue;
                }

                string key = elems[i][1..^1];
                string value = elems[i + 1];

                if (nameToField.TryGetValue(key, out FieldInfo fieldInfo))
                {
                    fieldInfo.SetValue(instance, ParseValue(fieldInfo.FieldType, value));
                }
                else if (nameToProperty.TryGetValue(key, out PropertyInfo propertyInfo))
                {
                    propertyInfo.SetValue(instance, ParseValue(propertyInfo.PropertyType, value), null);
                }
            }

            return instance;
        }
    }
}