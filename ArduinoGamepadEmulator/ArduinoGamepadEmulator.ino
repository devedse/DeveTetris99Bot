#include <Joystick.h>

Joystick_ Joystick(JOYSTICK_DEFAULT_REPORT_ID,JOYSTICK_TYPE_GAMEPAD,
  10, 0,                  // Button Count, Hat Switch Count
  true, true, false,     // X and Y, but no Z Axis
  false, false, false,   // No Rx, Ry, or Rz
  false, false,          // No rudder or throttle
  false, false, false);  // No accelerator, brake, or steering


  

String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete

int led1Pin = 13;

boolean isConnected = false;
int lastButtonState[5] = {0,0,0,0,0};

void setup() {
  // Initialize Joystick Library
  Joystick.begin();
  Joystick.setXAxisRange(-1, 1);
  Joystick.setYAxisRange(-1, 1);
  Serial1.begin(9600);
  pinMode(led1Pin,OUTPUT);
}

void loop() {

  readSerialData();

  if(stringComplete)
  {
    stringComplete = false;
    String command = inputString.substring(1);

    String button = command.substring(0, command.indexOf('-'));
    String valueButton = command.substring(command.indexOf('-') + 1);

    int delayNumber = 1;

    digitalWrite(13, 1);
    
    if (button == "L") {
      Joystick.setXAxis(-1);
      delay(delayNumber);
      Joystick.setXAxis(0);
    } else if (button == "R") {
      Joystick.setXAxis(1);
      delay(delayNumber);
      Joystick.setXAxis(0);
    } else if (button == "U") {
      Joystick.setYAxis(-1);
      delay(delayNumber);
      Joystick.setYAxis(0);
    } else if (button == "D") {
      Joystick.setYAxis(1);
      delay(delayNumber);
      Joystick.setYAxis(0);
    } else if (button == "A") {
      Joystick.setButton(0, 1);
      delay(delayNumber);
      Joystick.setButton(0, 0);
    } else {
      int intbutton = button.toInt();
      Joystick.pressButton(intbutton);
      delay(delayNumber);
      Joystick.releaseButton(intbutton);
    }

    
    digitalWrite(13, 0);
    inputString = "";
  }

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
