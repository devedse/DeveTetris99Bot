using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace DeveTetris99Bot.ArduinoSerial
{
    public class ArduinoSerialConnector
    {
        public const string FakePortName = "Fake";

        private readonly SerialPort _serialPort;
        private readonly TextBox _logTextBox;

        public ArduinoSerialConnector(string selectedPort, TextBox logTextBox)
        {
            if (selectedPort != FakePortName)
            {
                _serialPort = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
                _serialPort.Open();
            }

            _logTextBox = logTextBox;
        }

        public void Close()
        {
            if (_serialPort != null)
            {
                _serialPort.Close();
            }
        }

        //public void SendButtonPress(string button)
        //{
        //    var txt = $"#{button}-2\n";
        //    _serialPort.Write(txt);
        //}

        public void SendButtonDown(string button)
        {
            var txt = $"#{button}-0\n";

            if (_serialPort != null)
            {
                _serialPort.Write(txt);
            }

            _logTextBox.Text = txt + Environment.NewLine + _logTextBox.Text;
        }

        public void SendButtonUp(string button)
        {
            var txt = $"#{button}-1\n";

            if (_serialPort != null)
            {
                _serialPort.Write(txt);
            }

            _logTextBox.Text = txt + Environment.NewLine + _logTextBox.Text;
        }
    }
}
