using DeveTetris99Bot.ArduinoSerial;
using DeveTetris99Bot.Capture;
using DeveTetris99Bot.Tetris;
using DeveTetris99Bot.TetrisDetector;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeveTetris99Bot
{
    public partial class Tetris99BotForm : Form
    {
        public ArduinoSerialConnector CurrentSerialConnection { get; private set; }
        private Player tetrisPlayer;

        public Tetris99BotForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            var realGame = new RealGame(this, panelSimulator, panelSimulatorBlocks, panelDanger, labelLinesCleared, labelDanger);
            tetrisPlayer = new Player(realGame, realGame);


            for (int i = 0; i < Tetrimino.All.Length; i++)
            {
                var beest = Tetrimino.All[i];
                Console.WriteLine($"{i}:");
                Console.WriteLine(beest.ToString());

                var result = beest.RotateCW();
                Console.WriteLine(result.ToString());

                var result2 = result.RotateCW();
                Console.WriteLine(result2.ToString());

                var result3 = result2.RotateCW();
                Console.WriteLine(result3.ToString());

                var result4 = result3.RotateCW();
                Console.WriteLine(result4.ToString());

                if (!beest.Equals(result4))
                {
                    throw new Exception("Error");
                }
            }


            if (true)
            {
                var dsc = new DirectShowCapturer(this, pictureBox1, (bmp) =>
                {
                    var nextBlocks = TetrisDetectorCalculator.ScreenRefreshed(null, bmp, panel1, panel2);
                    realGame.LoadCapturedGameData(nextBlocks);
                });
            }
            else
            {
                var dsc2 = new FakeDetector("testimage.png", this, pictureBox1, (bmp) =>
                {
                    var nextBlocks = TetrisDetectorCalculator.ScreenRefreshed(null, bmp, panel1, panel2);
                    realGame.LoadCapturedGameData(nextBlocks);
                });
            }
            ReloadComPorts();

            base.OnLoad(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                tetrisPlayer.Play();
            });
        }

        private void ReloadComPorts()
        {
            comboBoxComConnections.Items.Clear();
            comboBoxComConnections.Items.Add(ArduinoSerialConnector.FakePortName);
            var foundComPorts = ArduinoSerialHelper.GetAvailableComConnections();
            foreach (var foundComPort in foundComPorts)
            {
                comboBoxComConnections.Items.Add(foundComPort);
            }
            if (foundComPorts.Any())
            {
                comboBoxComConnections.SelectedItem = ArduinoSerialConnector.FakePortName;
            }
        }

        private void buttonSerialArduinoConnectDisconnect_Click(object sender, System.EventArgs e)
        {
            if (CurrentSerialConnection == null)
            {
                var selectedPort = comboBoxComConnections.GetItemText(comboBoxComConnections.SelectedItem);
                CurrentSerialConnection = new ArduinoSerialConnector(selectedPort, textboxDebug);

                buttonSerialArduinoConnectDisconnect.Text = "Disconnect";
            }
            else
            {
                var toClose = CurrentSerialConnection;
                CurrentSerialConnection = null;
                toClose.Close();

                buttonSerialArduinoConnectDisconnect.Text = "Connect";
            }
        }

        private void buttonSerialArduinoRefresh_Click(object sender, System.EventArgs e)
        {
            ReloadComPorts();
        }

        //private void buttonArduinoAction_Click(object sender, System.EventArgs e)
        //{
        //    if (_currentSerialConnection != null)
        //    {
        //        var button = (Button)sender;
        //        _currentSerialConnection.SendButtonPress(button.Text.Split(' ').First());
        //    }
        //}

        private void buttonArduinoAction_Down(object sender, MouseEventArgs e)
        {
            if (CurrentSerialConnection != null)
            {
                var button = (Button)sender;
                CurrentSerialConnection.SendButtonDown(button.Text.Split(' ').First());
            }
        }

        private void buttonArduinoAction_Up(object sender, MouseEventArgs e)
        {
            if (CurrentSerialConnection != null)
            {
                var button = (Button)sender;
                CurrentSerialConnection.SendButtonUp(button.Text.Split(' ').First());
            }
        }
    }
}
