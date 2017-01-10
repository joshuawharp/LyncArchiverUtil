# LyncArchiverUtil
Lync Archiving Service to intercept and archive IM text in file system.

Welcome to the LyncArchivingService wiki!

This utility intercepts and logs the Lync conversations.

### How it works?

This util runs as an invisible windows form and has an icon in notification area.
When Lync conversation tab is closed, the log file is updated.

Setup creates a shortcut on your desktop. If you miss to click on Launch Application check box, use this short cut to launch the application.

This utility is added to start up applications list during the setup.

### Where are my logs?
They are stored in C:\Conversations by default with .conv file extension.

### How to change the log folder?
For this you need to know basic xml.
Open :
C:\Program Files (x86)\Lync.ArchiverUtil\Lync.ArchiverUtil.exe.config  file in note pad or notepad++
and change value of the node:
`<add key="FileArchivePath" value="C:\Conversations\" />`

### How to change file extension?
For this you need to know basic xml.
Open :
C:\Program Files (x86)\Lync.ArchiverUtil\Lync.ArchiverUtil.exe.config  file in note pad or notepad++
and change value of the node:
`<add key="FileExtension" value=".conv" />`

### How to download it?

Go to the below link,
https://github.com/avsnarayan/LyncArchiverUtil/blob/master/Lync.ArchiverUtil.Setup/bin/Release/Lync.ArchiverUtil.Setup.msi

and click on "**Raw**" or "**View Raw**"

### I need some more functionality ! How can I get it?
Go to https://github.com/avsnarayan/LyncArchiverUtil/issues/new and add new issue. You will be notified.
