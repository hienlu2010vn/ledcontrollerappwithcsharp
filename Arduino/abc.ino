#include <Wire.h>

int yellow = 8;
int red = 9;
int green = 10;

void setup()
{
  Serial.begin(9600);

  pinMode(yellow,OUTPUT);
  pinMode(red,OUTPUT);
  pinMode(green,OUTPUT);
}
String cmd;
void loop()
{
    if (Serial.available() > 0) {

      cmd = Serial.readStringUntil('\n');

    if (cmd == "redon") {
      digitalWrite(red,HIGH);
    }
    else if (cmd == "redoff") {
      digitalWrite(red,LOW);
    }
    else if (cmd == "greenon") {
      digitalWrite(green,HIGH);
    }
    else if (cmd == "greenoff") {
      digitalWrite(green,LOW);
    }
    else if (cmd == "yellowon") {
      digitalWrite(yellow,HIGH);
    }
    else if (cmd == "yellowoff") {
      digitalWrite(yellow,LOW);
    }
    else if (cmd == "allon") {
      digitalWrite(red,HIGH);
      digitalWrite(green,HIGH);
      digitalWrite(yellow,HIGH);
    }
    else if (cmd == "alloff") {
      digitalWrite(red,LOW);
      digitalWrite(green,LOW);
      digitalWrite(yellow,LOW);
    }
    else {
       Serial.write("invald input");
    }
  }
}
