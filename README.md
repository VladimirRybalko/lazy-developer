# lazy-developer
Everyone hates stupid frequently repeating actions. Me too.
So let's automate it.

I'm going to collect my automation tools and different useful tricks here. 
All of them help me with my daily work. Hope it will be also helpful for you.

## Listing
#### hosts.ps1
Simply tool to manage a windows hosts file. It will be very useful if you should switch between different environments during your work.

```powershell
# switch to hosts file.
switch-host 'dev'

# create a new empty host file in special my-hosts folder.
create 'dev'

# open an existing hosts file.
open 'qa'
```
