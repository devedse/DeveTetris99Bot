# DeveTetris99Bot

## Introduction

After seeing my girlfriend reck havoc in Tetris 99 I thought hey I can do that too! Except that I couldn't... So I build a bot.

## Progress

| Nr | Task | Status |
|--|--|--|
| 1 | Direct Show capturing of Elgato HD 60 capture card | Done (Code can use some improvements) (Uses some kind of 2005 library) |
| 2 | Convert Direct Show capture to Bitmap | Done (Uses screenshots of the DirectShow output as a workaround because I couldn't get this to work) |
| 3 | Detect next blocks from Bitmap | Used HSV color values to detect what blocks are what |
| 4 | Calculate next move | C# code detect what keypresses needs to happen ([Source](https://github.com/Hohol/TetrisPlayer/)) |
| 5 | Send keypresses to Arduino | Using a Serial connection and a USB-UART connector I send keypresses as strings to my Arduino Leonardo |
| 6 | Simulate Xbox 360 controller | I hacked an Arduino library from ([Source](https://github.com/kuwoh/XInputPadMicro)) (See section Arduino library) |
| 7 | Send Xbox 360 controller commands to COOV N100 | Connect Arduino Leonardo using it's USB port to the COOV N100 ([Buy](https://nl.aliexpress.com/item/Coov-N100-for-PS3-PS4-Xbox-One-Xbox-360-USB-Controller-Converter-Adapter-to-Nintendo-Switch/32823586852.html)) and plug that into the USB port from the switch |

## Todo

| Nr | Description |
|--|--|
| 1 | Detect sent lines from enemy players and act upon them |
| 2 | Handle more accurately when people are going to send lines and play slower then (currently it's too cautious) |

## Arduino library

Deploying this is simply done by using Freematics Arduino Builder and deploying the compiled file (with Bootloader) in the folder: https://github.com/devedse/DeveTetris99Bot/tree/master/ArduinoGamePadEmulatorXinput/Compiled
