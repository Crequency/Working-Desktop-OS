<pre align="center">
██╗    ██╗      ██████╗ ███████╗███████╗██╗  ██╗████████╗ ██████╗ ██████╗      ██████╗ ███████╗
██║    ██║      ██╔══██╗██╔════╝██╔════╝██║ ██╔╝╚══██╔══╝██╔═══██╗██╔══██╗    ██╔═══██╗██╔════╝
██║ █╗ ██║█████╗██║  ██║█████╗  ███████╗█████╔╝    ██║   ██║   ██║██████╔╝    ██║   ██║███████╗
██║███╗██║╚════╝██║  ██║██╔══╝  ╚════██║██╔═██╗    ██║   ██║   ██║██╔═══╝     ██║   ██║╚════██║
╚███╔███╔╝      ██████╔╝███████╗███████║██║  ██╗   ██║   ╚██████╔╝██║         ╚██████╔╝███████║
 ╚══╝╚══╝       ╚═════╝ ╚══════╝╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝          ╚═════╝ ╚══════╝
</pre>
<p align="center">
  <a href="./LICENSE" target="_blank"><img src="https://img.shields.io/github/license/Catrol-org/Working-Desktop-OS?style=for-the-badge"></img></a>
  <a href="https://dotnet.microsoft.com/" target="_blank"><img src="https://img.shields.io/badge/.NET%206-5C2D91?style=for-the-badge&logo=.net&logoColor=white"></img></a>
  <a href="#" target="_blank"><img src="https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white"></img></a>
  <a href="#" target="_blank"><img src="https://img.shields.io/badge/Linux-FCC624?style=for-the-badge&logo=linux&logoColor=black"></img></a>
  <a href="#" target="_blank"><img src="https://img.shields.io/badge/mac%20os-000000?style=for-the-badge&logo=macos&logoColor=F0F0F0"></img></a>
</p>
<p align="center">
🌏 <a href="#-中文文档">&nbsp;中文&nbsp;</a> | <a href="#-english-docs">English</a> 🌎<br>
🔗 <a href="https://www.wdos.online">官网主页 - Home Page</a> | <a href="https://docs.wdos.online">官方文档 - Official Docs</a> 🗒
</p>
<p align="center">
<a href="https://github.com/Catrol-org/Working-Desktop-OS/issues" target="_blank"><img alt="GitHub issues" src="https://img.shields.io/github/issues/Catrol-org/Working-Desktop-OS?style=flat-square"></a>
<a href="https://github.com/Catrol-org/Working-Desktop-OS/issues?q=is%3Aclosed" target="_blank"><img alt="GitHub closed issues" src="https://img.shields.io/github/issues-closed/Catrol-org/Working-Desktop-OS?style=flat-square"></a>
<a href="https://github.com/Catrol-org/Working-Desktop-OS/pulls" target="_blank"><img alt="GitHub pull requests" src="https://img.shields.io/github/issues-pr/Catrol-org/Working-Desktop-OS?style=flat-square"></a>
<a href="https://github.com/Catrol-org/Working-Desktop-OS/pulls?q=is%3Aclosed" target="_blank"><img alt="GitHub closed pull requests" src="https://img.shields.io/github/issues-pr-closed/Catrol-org/Working-Desktop-OS?style=flat-square"></a>
<a href="https://github.com/Catrol-org/Working-Desktop-OS/milestones" target="_blank"><img alt="GitHub milestones" src="https://img.shields.io/github/milestones/all/Catrol-org/Working-Desktop-OS?style=flat-square"></a>
</p>

----

<a href="https://www.wdos.online/" target="_blank"><img align="right" width="200" height="200" src="https://source.catrol.cn/icons/Project/Catrol/WDOS/logo2-mid.png"></img></a>

<!-- TOC -->

- [🥪 Version - Features 🔰](#markdown-header-🥪-version-features-🔰)
- [📄 中文文档](#markdown-header-📄-中文文档)
    - [✨ 介绍](#markdown-header-✨-介绍)
        - [🚩 WDOS 是什么?](#markdown-header-🚩-wdos-是什么)
        - [🔰 WDOS 的特性](#markdown-header-🔰-wdos-的特性)
            - [🔮 OS 模型](#markdown-header-🔮-os-模型)
            - [📱 插件模型](#markdown-header-📱-插件模型)
- [📄 English Docs](#markdown-header-📄-english-docs)
    - [✨ Introduction](#markdown-header-✨-introduction)
        - [🚩 What's WDOS?](#markdown-header-🚩-whats-wdos)
        - [🔰 Feature of WDOS](#markdown-header-🔰-feature-of-wdos)
            - [🔮 OS Model](#markdown-header-🔮-os-model)
            - [📱 插件模型](#markdown-header-📱-插件模型_1)

<!-- /TOC -->

----

<a id="markdown-markdown-header-🥪-version-features-🔰" name="markdown-header-🥪-version-features-🔰"></a>
# 🥪 Version - Features 🔰

| Version | Features                          | Descr                     |
|---------|-----------------------------------|---------------------------|
| Alpha   | nothing...<br>still developing... | The first version of WDOS |

<a id="markdown-markdown-header-📄-中文文档" name="markdown-header-📄-中文文档"></a>
# 📄 中文文档
<a id="markdown-markdown-header-✨-介绍" name="markdown-header-✨-介绍"></a>
## ✨ 介绍
<a id="markdown-markdown-header-🚩-wdos-是什么" name="markdown-header-🚩-wdos-是什么"></a>
### 🚩 WDOS 是什么?
简单来说, WDOS 是一个致力于打造更加良好优秀且易用的桌面体验的类 OS 桌面程序, 得益于插件机制和加载器模型, WDOS 可以轻松扩展它的功能, 就像一个真正的 OS 一样. 也正因为如此, 我们在 WDOS 中模拟了许多 OS 的行为, 以便于开发者能够保持以往的开发习惯, 无需花费太多的代价来适配 WDOS .  
同时, 我们鼓励开发者开发好用的程序, 并为更优秀的体验而适配 WDOS . 这将是一个良性循环, 有益于开源社区的发展.

<a id="markdown-markdown-header-🔰-wdos-的特性" name="markdown-header-🔰-wdos-的特性"></a>
### 🔰 WDOS 的特性
<a id="markdown-markdown-header-🔮-os-模型" name="markdown-header-🔮-os-模型"></a>
#### 🔮 OS 模型
1. 启动界面   ->    执行大部分初始化逻辑, 并启动管道服务, 开始接受管道消息并分配管道服务器
2. 登陆界面   ->    系统初始化完毕, 等待用户登录, 此时不允许任何除此以外的图形界面出现, 系统已锁定
3. 桌面环境   ->    用户进入桌面环境, 可以开始使用桌面程序, 并且可以执行大部分操作, 系统响应操作, 并通过管道控制外接程序, 一个完善的窗口管理器将在此期间负责窗口的模拟与逻辑, 外接程序的界面由窗口管理器负责在屏幕上绘制
4. 系统设置   ->    有别于系统内部的设置应用, 系统设置模仿了现实中的 BIOS 系统, 以期拥有更加仿真的类 OS 体验
5. 关机界面   ->    释放大部分已经使用的空间, 通知所有外接程序结束工作, 并强制结束不能响应通知的外接程序进程, 并关闭管道服务

<a id="markdown-markdown-header-📱-插件模型" name="markdown-header-📱-插件模型"></a>
#### 📱 插件模型
本质是使用了 MEF 框架用于扩展原有功能, 流程如下:  
启动: 主程序 -> 启动: 加载器 -> 等待: 加载器 > 建立: 与主程序的连接 -> 命令: 加载器 > 加载插件 -> 循环: 消息流 | 并 | 处理: 消息 -> 等待: 主程序 > 关闭系统.  
之所以不使用 MEF 直接将插件加载到主程序中, 是因为为了避免单一插件的崩溃导致整个系统的崩溃, 而使用管道将主程序与插件和加载器隔离开, 可以将完整系统分割成数个子系统与主程序系统, 降低了耦合性, 提高了鲁棒性  

<a id="markdown-markdown-header-📄-english-docs" name="markdown-header-📄-english-docs"></a>
# 📄 English Docs
<a id="markdown-markdown-header-✨-introduction" name="markdown-header-✨-introduction"></a>
## ✨ Introduction
<a id="markdown-markdown-header-🚩-whats-wdos" name="markdown-header-🚩-whats-wdos"></a>
### 🚩 What's WDOS?
WDOS is a desktop program like a OS, which is committed to provide a better and more comfortable experience for developers. It is based on the plugin model and loader model, and can be easily extended. It is like a real OS, which enables developers to keep their old development habits, without spending too much time on adapting WDOS.  
In the same time, we encourage developers to develop great programs, and to adapt WDOS for better experience. This will be a positive loop, which benefits the development of open source community.

<a id="markdown-markdown-header-🔰-feature-of-wdos" name="markdown-header-🔰-feature-of-wdos"></a>
### 🔰 Feature of WDOS
<a id="markdown-markdown-header-🔮-os-model" name="markdown-header-🔮-os-model"></a>
#### 🔮 OS Model
1. Start up screen        ->    Execute most of the initialization logic, start the pipe service, start to receive pipe messages and allocate pipe server.
2. Login screen           ->    System initialization is complete, wait for user to login, this time, it is not allowed to have any other graphical interface appear, system is locked.
3. Desktop environment    ->    User enters the desktop environment, can start using desktop applications, and can execute most of the operations, system responds to operations, and through the pipe controls external programs, a complete window manager will be in this time responsible for window simulation and logic, external programs' interface will be managed by the window manager, and external programs will be terminated when the system is shutdown.
4. System settings        ->    There is a different from the system internal settings application, the system settings is like a BIOS system, in order to provide a more realistic OS experience.
5. Shutdown screen        ->    Release most of the used space, notify all external programs to end work, and force end external programs that cannot respond to notification.

<a id="markdown-markdown-header-📱-插件模型_1" name="markdown-header-📱-插件模型_1"></a>
#### 📱 插件模型
In fact, it is using the MEF framework to extend the original function, the process is as follows:  
Start up: Main program -> Start up: Loader -> Wait: Loader > Connect: with the main program -> Command: Loader > Load plugin -> Loop: Message flow | And | Handle: Message -> Wait: Main program > Shutdown system.  
The reason why we do not use MEF directly to load plugins into the main program, is because to avoid the single plugin crash causing the entire system crash, we use the pipe to separate the main program and plugin and loader, and can separate the entire system into several sub systems and the main program system, can reduce the coupling, and improve the robustness.


