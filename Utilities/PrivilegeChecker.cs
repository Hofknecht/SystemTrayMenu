// <copyright file="PrivilegeChecker.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System.Linq;
    using System.Security.Principal;

    internal static class PrivilegeChecker
    {
        public static bool IsCurrentUserInAdminGroup { get; set; }

        public static void Initialize()
        {
            // https://stackoverflow.com/questions/3600322/check-if-the-current-user-is-administrator
            // https://learn.microsoft.com/en-us/troubleshoot/windows-server/identity/security-identifiers-in-windows
            // S-1-5-32-544
            // A built-in group. After the initial installation of the operating system,
            // the only member of the group is the Administrator account.
            // When a computer joins a domain, the Domain Admins group is added to
            // the Administrators group. When a server becomes a domain controller,
            // the Enterprise Admins group also is added to the Administrators group.
            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            var claims = principal.Claims;
            IsCurrentUserInAdminGroup = claims.FirstOrDefault(c => c.Value == "S-1-5-32-544") != null;
        }
    }
}