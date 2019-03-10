#ifndef WiringPrivate_h
#define WiringPrivate_h

// pulled from ArduinoCore-avr/cores/arduino/wiring_private.h

#ifndef cbi
#define cbi(sfr, bit) (_SFR_BYTE(sfr) &= ~_BV(bit))
#endif
#ifndef sbi
#define sbi(sfr, bit) (_SFR_BYTE(sfr) |= _BV(bit))
#endif

#endif