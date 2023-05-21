# Ultimate Launcher

A simple  tool for loading and launching programs and disk/cartridge images on a Ultimate 1541 equipped C64 (or an Ultimate 64) directly from the comfort of your desktop. Turn your disks in style.

![image](https://github.com/kebby/ultimate-launcher/assets/1643404/e42a4742-b48b-4e3d-a4da-076f950fe6a1)

## Prerequisites

Ultimate Launcher runs under Windows 10/11 (using .NET Framework 4.8) and under Linux using Mono (run `mono UltiLaunch.exe`). It should also run on old, pre-Catalina Macs but sadly nothing newer as Windows Forms on 64-bit Macs is still not supported.

## Usage

First, enter the IP address or host name of your Ultimate cartridge/64 once. From then on, you can select a directory at the top, and mount or run any PRGs, D64s or CRTs with the two buttons on the right.

### Command line interface / Conduit

Specify a relative or absolute directory or image file as command line parameter to automatically launch it (a directory will set the launcher's current directory). Feel free to add file type associations yourself.

If you're using Gargaj's [Conduit](https://github.com/gargaj/Conduit/) you can set the Ultimate Launcher as VICE executable - enjoy single click demo watching directly from Pouet, Demozoo or even the CSDB :)
