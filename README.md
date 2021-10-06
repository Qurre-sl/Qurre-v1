
<img src="https://cdn.fydne.xyz/qurre/Qurre-web_ol.gif" align="right" />
<p>
   <a href="https://discord.gg/zGUqfJQebn" alt="Discord">
      <img src="https://discord.com/api/guilds/779412392651653130/embed.png" alt="Discord Server"/>
   </a>
   <a href="https://github.com/Qurre-Team/Qurre-sl/releases" alt="Downloads">
      <img src="https://img.shields.io/github/downloads/Qurre-Team/Qurre-sl/total?color=%2300b813&style=plastic" alt="Discord Server"/>
   </a>
   <a href="https://github.com/Qurre-Team/Qurre-sl/releases" alt="Release">
      <img src="https://img.shields.io/github/v/release/Qurre-Team/Qurre-sl.svg?style=plastic" alt="Discord Server"/>
   </a>
   <a href="https://www.nuget.org/packages/Qurre" alt="nuget downloads">
      <img src="https://img.shields.io/nuget/dt/Qurre?label=nuget%20downloads&style=plastic" alt="Discord Server"/>
   </a>
   <a href="https://www.nuget.org/packages/Qurre" alt="nuget release">
      <img src="https://img.shields.io/nuget/vpre/Qurre?style=plastic" alt="Discord Server"/>
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
#Can other SCPs look at SCP-173?
Qurre_ScpTrigger173: false
#SCP 079 & SCP 096 will not see the wearer of SCP 268
Qurre_Better268: false
#If enabled, will spawn those who entered after the start of the round
Qurre_LateJoinSpawn: true
Qurre_Banned: banned
Qurre_Kicked: kicked
Qurre_BanOrKick_msg: You have been %bok%.
Qurre_Reason: Reason
#Link-access to your database(MongoDB)
Qurre_DataBase: undefined
```
## [Example Plugin](https://github.com/Qurre-Team/example-plugin)

Based on [Exiled](https://github.com/Exiled-Team/EXILED) & [Synapse](https://github.com/SynapseSL/Synapse)
