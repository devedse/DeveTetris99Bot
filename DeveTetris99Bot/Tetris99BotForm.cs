using DeveTetris99Bot.ArduinoSerial;
using DeveTetris99Bot.Capture;
using DeveTetris99Bot.TetrisDetector;
using System.Linq;
using System.Windows.Forms;

namespace DeveTetris99Bot
{
    public partial class Tetris99BotForm : Form
    {
        private DirectShowCapturer dsc;
        private ArduinoSerialConnector _currentSerialConnection;

        public Tetris99BotForm()
        {
            InitializeComponent();

            //dsc = new DirectShowCapturer(this, pictureBox1, (bmp) =>
            //{
            //    TetrisDetectorCalculator.ScreenRefreshed(null, bmp, panel1, panel2);
            //});

            var dsc2 = new FakeDetector(this, pictureBox1, (bmp) =>
            {
                TetrisDetectorCalculator.ScreenRefreshed(null, bmp, panel1, panel2);
            });

            ReloadComPorts();
        }

        private void ReloadComPorts()
        {
            comboBoxComConnections.Items.Clear();
            var foundComPorts = ArduinoSerialHelper.GetAvailableComConnections();
            foreach(var foundComPort in foundComPorts)
            {
                comboBoxComConnections.Items.Add(foundComPort);
            }
            if (foundComPorts.Any())
            {
                comboBoxComConnections.SelectedItem = foundComPorts.First();
            }
        }

        private void buttonSerialArduinoConnectDisconnect_Click(object sender, System.EventArgs e)
        {
            if (_currentSerialConnection == null)
            {
                var selectedPort = comboBoxComConnections.GetItemText(comboBoxComConnections.SelectedItem);
                _currentSerialConnection = new ArduinoSerialConnector(selectedPort);

                buttonSerialArduinoConnectDisconnect.Text = "Disconnect";
            }
            else
            {
                _currentSerialConnection = null;
                _currentSerialConnection.Close();

                buttonSerialArduinoConnectDisconnect.Text = "Connect";
            }
        }

        private void buttonSerialArduinoRefresh_Click(object sender, System.EventArgs e)
        {
            ReloadComPorts();
        }

        private void buttonArduinoAction_Click(object sender, System.EventArgs e)
        {
            if (_currentSerialConnection != null)
            {
                var button = (Button)sender;
                _currentSerialConnection.SendButtonPress(button.Text);
            }
        }
    }
}
