using DeveTetris99Bot.Capture;
using DeveTetris99Bot.TetrisDetector;
using System.Windows.Forms;

namespace DeveTetris99Bot
{
    public partial class Tetris99BotForm : Form
    {
        private DirectShowCapturer dsc;

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
        }
    }
}
