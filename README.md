SystemTrayMenu<img src="https://raw.githubusercontent.com/Hofknecht/SystemTrayMenu/master/Resources/SystemTrayMenu.ico" alt="Trulli" width="24" height="24">  
------------------

[![Build Status](https://dev.azure.com/MarkusHofknecht/SystemTrayMenu/_apis/build/status/Hofknecht.SystemTrayMenu?branchName=master)](https://dev.azure.com/MarkusHofknecht/SystemTrayMenu/_build)
[![Build Version](https://img.shields.io/github/v/release/hofknecht/systemtraymenu)](https://github.com/Hofknecht/SystemTrayMenu/releases)

[![GitHub](https://github.com/favicon.ico)](https://github.com/Hofknecht/SystemTrayMenu/releases)
[![Downloads GitHub](https://img.shields.io/github/downloads/Hofknecht/SystemTrayMenu/total.svg)](https://github.com/Hofknecht/SystemTrayMenu/releases)
 |
[![SourceForge](https://user-images.githubusercontent.com/52528841/89990756-1aff8000-dc83-11ea-828a-a70a4d567399.png)](https://sourceforge.net/projects/systemtraymenu/files/latest/download)
[![Downloads SourceForge](https://img.shields.io/sourceforge/dt/systemtraymenu.svg)](https://sourceforge.net/projects/systemtraymenu/files/latest/download)
 |
[![WindowsStore](https://user-images.githubusercontent.com/52528841/88452959-371db780-ce63-11ea-9076-11920156456a.png)](https://www.microsoft.com/store/apps/9N24F8ZBJMT1)
[![Downloads Microsoft Store](https://img.shields.io/badge/downloads-%3E400-green)](https://www.microsoft.com/store/apps/9N24F8ZBJMT1)
 |
[![CHIP](https://user-images.githubusercontent.com/52528841/88452975-5583b300-ce63-11ea-8256-6e69a2bb3e2d.png)](https://www.chip.de/downloads/SystemTrayMenu_182854219.html)
[![Downloads CHIP](https://img.shields.io/badge/downloads-%3E1k-green)](https://www.chip.de/downloads/SystemTrayMenu_182854219.html)
 |
[![computerbild](https://user-images.githubusercontent.com/52528841/89651200-d9a65380-d8c3-11ea-9dab-e5563eb7c4f6.png)](https://www.computerbild.de/download/SystemTrayMenu-26748523.html)
[![Downloads computerbild](https://img.shields.io/badge/downloads-%3E100-green)](https://www.computerbild.de/download/SystemTrayMenu-26748523.html)

<!-- [![Gitter](https://badges.gitter.im/SystemTrayMenu/community.svg)](https://gitter.im/SystemTrayMenu/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge) -->

**Browse and open your files easily**

SystemTrayMenu is a free, open-source start menu alternative for Microsoft Windows. It offers a clear, personalized menu in the system tray. Files, links and folders are organized in several levels as drop-down menus.

We are using C# and .Net Core 3.1

![20200812_125923](https://user-images.githubusercontent.com/52528841/90009201-ee0c9680-dc9d-11ea-9b8a-b34108152f9b.gif)
![20200812_130823](https://user-images.githubusercontent.com/52528841/90009212-f1078700-dc9d-11ea-943a-d5fde4d6f2dc.gif)

Download the latest official version:  
https://github.com/Hofknecht/SystemTrayMenu/releases
  

FAQ
------------------

**What do I have to do now as first steps?**  
  
SystemTrayMenu is portable so you do not have to install it.  
We would recommend to put the unzipped SystemTrayMenu folder into a folder like "Portable Tools" in the SystemTrayMenu root directory.  
  
1. Step: After starting the application the first time you have to **choose the root directory**.  
C:\Cloudfolder e.g. Seafile, NextCloud or Dropbox\your folder with links e.g. Tools or SystemTrayMenu  
e.g. C:\Seafile\Tools  
In this directory you should put shortcuts of folders and files (App, Game, Script, URL, Network),  
which you are often using and especially when you can not find them over the windows start menu search.  
You can also consider to put there all files from your desktop.  

2. Step: **Move the SystemTrayMenu icon** by drag and drop from the system tray **into the taskbar** below.  
![group icon out](https://user-images.githubusercontent.com/52528841/83349567-1ab74000-a336-11ea-8676-3db33615a57a.gif)

3. Step: Now it is ready to start - just **click on the icon** in the taskbar to open the SystemTrayMenu. 

**How can I change the root directory?**

You can change the root directory in the settings menu, that you can open by right clicking on the SystemTrayMenu icon.  

**What does the hotkey do?**

In the settings menu you can choose a hotkey to open and close the SystemTrayMenu.  

**Can the SystemTrayMenu launch on windows startup?**

Yes, you can select this option in the settings menu, that you can open by right clicking on the SystemTrayMenu icon.  

**What can I do if I have a problem, idea or question?**

If a problem has occured or you have any ideas or questions, you are welcome to contact us.  
Our contact information you can find in the About window, that can be opened by right clicking on the SystemTrayMenu icon.   

**Find more FAQ topics here:**
[SystemTrayMenu FAQ](https://github.com/Hofknecht/SystemTrayMenu/issues?q=is%3Aissue+is%3Aclosed+label%3AFAQ)


Security
------------------

Some antiviruses might flag this program as malicious, but it is not! The source is open, so you can compile it yourself.  


Build
------------------

Install Visual Studio 2019.  
Install .NET Core 3.1 SDK [https://dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.300-windows-x64-installer).

Contributing
------------------

If you would like to contribute, everyone is welcome to.  
If you are considering a feature, need guidance, or want to talk about an idea, don't hesitate to create an issue here.  
When contributing please respect the style used by the codebase and consider the following rules:  
* Run FixCop.  
* Increase the version in the assembly file.  
* Add a commit message like: 
```
[Feature] Show icon in taskbar when application is running (#115), version 0.11.1.9
```

* Commit either directly to the master branch or create a new branch if you are not sure with your changes 
https://guides.github.com/activities/hello-world/.  
* Update the issue and set the status to closed.  

Contributors
------------------

Special thanks to our productive contibutors [Tanja Kauth](https://github.com/Tanjalibertatis) and [Peter Kirmeier](https://github.com/topeterk)!

Donations
------------------

We would be delighted if you could help us with the following:
* a star on this github project
* a like on [Facebook](https://www.facebook.com/Systemtraymenu-114069060335483)
* a review or rating on [Sourceforge](https://sourceforge.net/projects/systemtraymenu/)
* your ideas either as issues here in github or directly per mail

Don't hesitate to donate if you appreciate SystemTrayMenu and would like to support our work.  
[![PayPal](https://www.paypalobjects.com/webstatic/de_DE/i/de-pp-logo-100px.png)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=Y9W6H5HXQPPUQ&source=url)

