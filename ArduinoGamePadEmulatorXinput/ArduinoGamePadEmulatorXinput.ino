#include "XInputPad.h"
#include "util.h"


  

String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete

int led1Pin = 13;

boolean isConnected = false;

bool pad_up, pad_down, pad_left, pad_right, pad_y, pad_b, pad_x, pad_a, pad_black, pad_white, pad_start, pad_select, pad_l3, pad_r3;
uint8_t pad_left_analog_x,  pad_left_analog_y, pad_right_analog_x, pad_right_analog_y; //pad_l, pad_r, 

void setup() {
  pinMode(led1Pin,OUTPUT);  
  digitalWrite(led1Pin, LOW);   // turn the LED on (HIGH is the voltage level)    
  
  CPU_PRESCALE(0);

  bit_set(MCUCR, 1 << JTD);
  bit_set(MCUCR, 1 << JTD);
  
  Serial1.begin(9600);

  xbox_init(true);

  pad_left_analog_x = pad_left_analog_y = pad_right_analog_x = pad_right_analog_y = 0x7F;
}

bool valuetje = false;

void loop() {
  xbox_reset_watchdog();
  
  readSerialData();

  if(stringComplete)
  {
    stringComplete = false;
    String command = inputString.substring(1);

    String button = command.substring(0, command.indexOf('-'));
    String valueButton = command.substring(command.indexOf('-') + 1);
    uint8_t valueButtonInt = valueButton.toInt();
    
    bool valueButtonBool = true;
    if (valueButtonInt == 1) {
      valueButtonBool = false;
    }

    digitalWrite(13, valueButtonBool);

    if (button == "L") {
      if (valueButtonBool) {
        pad_left_analog_x = 0x00;
      } else {
        pad_left_analog_x = 0x7F;
      }
    } else if (button == "R") {
      if (valueButtonBool) {
        pad_left_analog_x = 0xFF;
      } else {
        pad_left_analog_x = 0x7F;
      }
    } else if (button == "U") {
      if (valueButtonBool) {
        pad_left_analog_y = 0x00;
      } else {
        pad_left_analog_y = 0x7F;
      }
    } else if (button == "D") {
      if (valueButtonBool) {
        pad_left_analog_y = 0xFF;
      } else {
        pad_left_analog_y = 0x7F;
      }
    } else if (button == "LR") {
      if (valueButtonBool) {
        pad_right_analog_x = 0x00;
      } else {
        pad_right_analog_x = 0x7F;
      }
    } else if (button == "RR") {
      if (valueButtonBool) {
        pad_right_analog_x = 0xFF;
      } else {
        pad_right_analog_x = 0x7F;
      }
    } else if (button == "UR") {
      if (valueButtonBool) {
        pad_right_analog_y = 0x00;
      } else {
        pad_right_analog_y = 0x7F;
      }
    } else if (button == "DR") {
      if (valueButtonBool) {
        pad_right_analog_y = 0xFF;
      } else {
        pad_right_analog_y = 0x7F;
      }
    } else if (button == "LH") {
      pad_left = valueButtonBool;
    } else if (button == "RH") {
      pad_right = valueButtonBool;
    } else if (button == "UH") {
      pad_up = valueButtonBool;
    } else if (button == "DH") {
      pad_down = valueButtonBool;
    } else {
      int intbutton = button.toInt() - 1;

      if (intbutton == 0) {
        pad_a = valueButtonBool;
      } else if (intbutton == 1) {
        pad_b = valueButtonBool;
      } else if (intbutton == 2) {
        pad_x = valueButtonBool;
      } else if (intbutton == 3) {
        pad_y = valueButtonBool;
      } else if (intbutton == 4) {
        pad_start = valueButtonBool;
      } else if (intbutton == 5) {
        pad_select = valueButtonBool;
      } else if (intbutton == 6) {
        pad_black = valueButtonBool;
      } else if (intbutton == 7) {
        pad_white = valueButtonBool;
      } else if (intbutton == 8) {
        pad_l3 = valueButtonBool;
      } else if (intbutton == 9) {
        pad_r3 = valueButtonBool;
      }
    }
        
    inputString = "";
  }
  
  pad_up    ? bit_set(gamepad_state.digital_buttons_1, XBOX_DPAD_UP)    : bit_clear(gamepad_state.digital_buttons_1, XBOX_DPAD_UP);
  pad_down  ? bit_set(gamepad_state.digital_buttons_1, XBOX_DPAD_DOWN)  : bit_clear(gamepad_state.digital_buttons_1, XBOX_DPAD_DOWN);
  pad_left  ? bit_set(gamepad_state.digital_buttons_1, XBOX_DPAD_LEFT)  : bit_clear(gamepad_state.digital_buttons_1, XBOX_DPAD_LEFT);
  pad_right ? bit_set(gamepad_state.digital_buttons_1, XBOX_DPAD_RIGHT) : bit_clear(gamepad_state.digital_buttons_1, XBOX_DPAD_RIGHT);

  pad_start  ? bit_set(gamepad_state.digital_buttons_1, XBOX_START)       : bit_clear(gamepad_state.digital_buttons_1, XBOX_START);
  pad_select ? bit_set(gamepad_state.digital_buttons_1, XBOX_BACK)        : bit_clear(gamepad_state.digital_buttons_1, XBOX_BACK);
  pad_l3     ? bit_set(gamepad_state.digital_buttons_1, XBOX_LEFT_STICK)  : bit_clear(gamepad_state.digital_buttons_1, XBOX_LEFT_STICK);
  pad_r3     ? bit_set(gamepad_state.digital_buttons_1, XBOX_RIGHT_STICK) : bit_clear(gamepad_state.digital_buttons_1, XBOX_RIGHT_STICK);

  pad_a ? bit_set(gamepad_state.digital_buttons_2, XBOX_A) : bit_clear(gamepad_state.digital_buttons_2, XBOX_A);
  pad_b ? bit_set(gamepad_state.digital_buttons_2, XBOX_B) : bit_clear(gamepad_state.digital_buttons_2, XBOX_B);
  pad_x ? bit_set(gamepad_state.digital_buttons_2, XBOX_X) : bit_clear(gamepad_state.digital_buttons_2, XBOX_X);
  pad_y ? bit_set(gamepad_state.digital_buttons_2, XBOX_Y) : bit_clear(gamepad_state.digital_buttons_2, XBOX_Y);

  pad_black ? bit_set(gamepad_state.digital_buttons_2, XBOX_LB)    : bit_clear(gamepad_state.digital_buttons_2, XBOX_LB);
  pad_white ? bit_set(gamepad_state.digital_buttons_2, XBOX_RB)    : bit_clear(gamepad_state.digital_buttons_2, XBOX_RB);

  if(pad_start && pad_select) {
    bit_set(gamepad_state.digital_buttons_2, XBOX_HOME);
  } else {
    bit_clear(gamepad_state.digital_buttons_2, XBOX_HOME);
  }

  gamepad_state.l_x = pad_left_analog_x * 257 + -32768;
  gamepad_state.l_y = pad_left_analog_y * -257 + 32767;
  gamepad_state.r_x = pad_right_analog_x * 257 + -32768;
  gamepad_state.r_y = pad_right_analog_y * -257 + 32767;

  //gamepad_state.lt = pad_l * 0xFF;
  //gamepad_state.rt = pad_r * 0xFF;

  xbox_send_pad_state();
}

boolean getLedState()
{
  boolean state = false;
  if(inputString.substring(5,7).equals("ON")) {
    state = true;
  } else {
    state = false;
  }
  return state;
}

String getTextToPrint()
{
  String value = inputString.substring(5,inputString.length()-2);
  return value;
}

void readSerialData() {
  if (Serial1.available()) {
    // get the new byte:
    char inChar = (char)Serial1.read();
    
    // add it to the inputString:
    inputString += inChar;
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}
