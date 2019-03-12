#include "XInputPad.h"
#include "util.h"


  

String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete

int led1Pin = 13;

boolean isConnected = false;
int lastButtonState[5] = {0,0,0,0,0};

void setup() {

  digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(300);                       // wait for a second
  digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW
  delay(300);      
  digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(300);                       // wait for a second
  digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW
  delay(300);      
  digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(300);                       // wait for a second
  digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW
  delay(300);      
  digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(300);                       // wait for a second
  digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW
  delay(300);      
  
  CPU_PRESCALE(0);

  bit_set(MCUCR, 1 << JTD);
  bit_set(MCUCR, 1 << JTD);
  
  Serial1.begin(9600);   
  pinMode(led1Pin,OUTPUT);

  xbox_init(true);
  
}

bool valuetje = false;

void loop() {
  xbox_reset_watchdog();

  digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(100); // wait for a second
  digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW
  delay(100);

  valuetje ? bit_set(gamepad_state.digital_buttons_2, XBOX_B)  : bit_clear(gamepad_state.digital_buttons_2, XBOX_B);
  valuetje = !valuetje;
  
  readSerialData();

  if(stringComplete)
  {
    stringComplete = false;
    String command = inputString.substring(1);

    String button = command.substring(0, command.indexOf('-'));
    String valueButton = command.substring(command.indexOf('-') + 1);

    int delayNumber = 100;

    digitalWrite(13, 1);

    if (button == "L") {
      gamepad_state.l_x = -32768;
      //Joystick.setXAxis(-1);
      delay(delayNumber);
      //Joystick.setXAxis(0);
      gamepad_state.l_x = 0;
    } else if (button == "R") {
      gamepad_state.l_x = 32768;
      //Joystick.setXAxis(1);
      delay(delayNumber);
      //Joystick.setXAxis(0);
      gamepad_state.l_x = 0;
    } else if (button == "U") {
      gamepad_state.l_y = -32768;
      //Joystick.setYAxis(-1);
      delay(delayNumber);
      //Joystick.setYAxis(0);
      gamepad_state.l_y = 0;
    } else if (button == "D") {
      gamepad_state.l_y = 32768;
      //Joystick.setYAxis(1);
      delay(delayNumber);
      //Joystick.setYAxis(0);
      gamepad_state.l_y = 0;
    } else if (button == "LH") {
      bit_set(gamepad_state.digital_buttons_1, XBOX_DPAD_LEFT);
      //Joystick.setHatSwitch(0, 270);
      delay(delayNumber);
      //Joystick.setHatSwitch(0, -1);
      bit_clear(gamepad_state.digital_buttons_1, XBOX_DPAD_LEFT);
    } else if (button == "RH") {
      bit_set(gamepad_state.digital_buttons_1, XBOX_DPAD_RIGHT);
      //Joystick.setHatSwitch(0, 90);
      delay(delayNumber);
      //Joystick.setHatSwitch(0, -1);
      bit_clear(gamepad_state.digital_buttons_1, XBOX_DPAD_RIGHT);
    } else if (button == "UH") {
      bit_set(gamepad_state.digital_buttons_1, XBOX_DPAD_UP);
      //Joystick.setHatSwitch(0, 0);
      delay(delayNumber);
      //Joystick.setHatSwitch(0, -1);
      bit_clear(gamepad_state.digital_buttons_1, XBOX_DPAD_UP);
    } else if (button == "DH") {
      bit_set(gamepad_state.digital_buttons_1, XBOX_DPAD_DOWN);
      //Joystick.setHatSwitch(0, 180);
      delay(delayNumber);
      //Joystick.setHatSwitch(0, -1);
      bit_clear(gamepad_state.digital_buttons_1, XBOX_DPAD_DOWN);
    } else {
      int intbutton = button.toInt() - 1;

      if (intbutton == 0) {
        bit_set(gamepad_state.digital_buttons_2, XBOX_B);
        delay(delayNumber);
        bit_clear(gamepad_state.digital_buttons_2, XBOX_B);
      } else if (intbutton == 1) {
        bit_set(gamepad_state.digital_buttons_2, XBOX_A);
        delay(delayNumber);
        bit_clear(gamepad_state.digital_buttons_2, XBOX_A);
      }
      //Joystick.pressButton(intbutton);
      //delay(delayNumber);
      //Joystick.releaseButton(intbutton);
    }
    

    
    digitalWrite(13, 0);
    inputString = "";
  }
  
  xbox_send_pad_state();
}

boolean getLedState()
{
  boolean state = false;
  if(inputString.substring(5,7).equals("ON"))
  {
    state = true;
  }else
  {
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
