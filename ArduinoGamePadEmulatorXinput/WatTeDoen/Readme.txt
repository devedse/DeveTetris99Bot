Pak die XInputPadMicro.7z uit in C:\Users\Davy\Documents\Arduino\libraries

Dan edit de boards.txt om deze line bij arduino leonardo te adden:
leonardo.build.extra_flags={build.usb_flags} -DMCU=atmega32u4 -DARCH=AVR8 -DBOARD=LEONARDO -DF_USB=16000000 -DTARGET=XInputPadMicro -DUSE_LUFA_CONFIG_HEADER -IConfig/
