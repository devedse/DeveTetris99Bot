using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveTetris99Bot.ArduinoSerial
{
    public class ArduinoSerialConnector
    {
        private readonly SerialPort _serialPort;

        public ArduinoSerialConnector(string selectedPort)
        {
            _serialPort = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            _serialPort.Open();
        }

        public void Close()
        {
            _serialPort.Close();
        }

        public void SendButtonPress(string button)
        {
            var txt = $"#{button}-2\n";
            _serialPort.Write(txt);
        }
    }
}
