using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeveTetris99Bot.Capture
{
    public class FakeDetector
    {
        private readonly Tetris99BotForm form;
        private readonly PictureBox pictureBox;
        private readonly Action<Bitmap> imageDetected;

        public FakeDetector(Tetris99BotForm form, PictureBox pictureBox, Action<Bitmap> imageDetected)
        {
            this.form = form;
            this.pictureBox = pictureBox;
            this.imageDetected = imageDetected;


            var bmptje = new Bitmap("testimage.png");

            pictureBox.Image = bmptje;

            Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                while (true)
                {
                    var ss = new Bitmap("testimage.png");                    

                    try
                    {
                        imageDetected(ss);
                    }
                    catch (Exception ex)
                    {

                    }

                    Task.Delay(100).Wait();
                }
            });
        }
    }
}
