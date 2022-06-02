<a href="https://discord.gg/zGUqfJQebn" alt="Discord">
<img src="https://cdn.scpsl.store/qurre/img/qurreLogo200x200-cyrcle.png" align="right" style="border-radius: 50%;" />
</a>
<p>
   <a href="https://discord.gg/zGUqfJQebn" alt="Discord">
      <img src="https://discord.com/api/guilds/779412392651653130/embed.png" alt="Discord"/>
   </a>
   <a href="https://github.com/Qurre-Team/Qurre-sl/releases" alt="Downloads">
      <img src="https://img.shields.io/github/downloads/Qurre-Team/Qurre-sl/total?color=%2300b813&style=plastic" alt="Downloads"/>
   </a>
   <a href="https://github.com/Qurre-Team/Qurre-sl/releases" alt="Release">
      <img src="https://img.shields.io/github/v/release/Qurre-Team/Qurre-sl.svg?style=plastic" alt="Release"/>
   </a>
   <a href="https://www.nuget.org/packages/Qurre" alt="nuget downloads">
      <img src="https://img.shields.io/nuget/dt/Qurre?label=nuget%20downloads&style=plastic" alt="nuget downloads"/>
   </a>
   <a href="https://www.nuget.org/packages/Qurre" alt="nuget release">
      <img src="https://img.shields.io/nuget/vpre/Qurre?style=plastic" alt="nuget release"/>
   </a>
</p>

# Qurre
Framework for SCP:SL servers with unique functions & api

# Installation
* Move `Assembly-CSharp.dll` into the `SCPSL_Data/Managed` 
* Move the rest of the files/folders to `~/.config` (`%AppData%` on Windows)
# Configs
You can configure configs in `~/.config`(`%AppData%` on Windows)`/Qurre/Configs/^server.port^-cfg.yml` 

```yml
#Are Debug logs enabled?
Qurre_Debug: false
#Are errors saved to the log file?
Qurre_Logging: true
#Are all console output being saved to a log file?
Qurre_All_Logging: false
#Should I show the Qurre version on Units for all roles?
Qurre_AllUnit: false
#Should I show the Qurre version on Units only for the Tutorial role?
Qurre_OnlyTutorialUnit: false
#Allow the appearance of blood?
Qurre_Spawn_Blood: true
#SCP 079 & SCP 096 will not see the wearer of SCP 268
Qurre_Better268: false
#Those who can use the "reload" command
Qurre_ReloadAccess: owner, 746538986@steam,309800126721@discord
Qurre_Banned: banned
Qurre_Kicked: kicked
Qurre_BanOrKick_msg: You have been %bok%.
Qurre_Reason: Reason
#Link-access to your database(MongoDB)
Qurre_DataBase: undefined
```
## [Example Plugin](https://github.com/Qurre-Team/example-plugin)

## Credits

**0Harmony - Owned by [Andreas Pardeike](https://github.com/pardeike)**

**MongoDB.\* - Owned by [MongoDB](https://github.com/mongodb)**

**DnsClient - Owned by [Michael Conrad](https://github.com/MichaCo)**

**YamlDotNet - Owned by [Antoine Aubry](https://github.com/aaubry)**

**Newtonsoft.Json - Owned by [James Newton-King](https://github.com/JamesNK)**

**NLayer - Owned by [NAudio](https://github.com/naudio)**

**Assembly-CSharp - Owned by [Northwood Studios](https://github.com/northwood-studios)**

**Some parts of the code may be similar to [Exiled](https://github.com/Exiled-Team/EXILED) or [Synapse](https://github.com/SynapseSL/Synapse)**
