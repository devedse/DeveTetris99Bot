using System.IO.Ports;

namespace DeveTetris99Bot.ArduinoSerial
{
    public static class ArduinoSerialHelper
    {
        public static string[] GetAvailableComConnections()
        {
            return SerialPort.GetPortNames();
        }
    }
}
