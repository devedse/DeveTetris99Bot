using DeveTetris99Bot.Config;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DeveTetris99Bot.TetrisDetector
{
    public static class TetrisDetectorCalculator
    {
        private const int BlockSize = 20;

        private const int BlackColorTreshhold = 60;
        private const float LightnessTreshhold = 0.3f;

        public static void ScreenRefreshed(object sender, Bitmap data, Panel panelToDrawIn, Panel panelToDrawIn2)
        {
            int dividertje = 1;


            int gridStartX = 480 / dividertje;
            int gridEndX = 800 / dividertje;
            int gridWidth = gridEndX - gridStartX;

            int blocksWidth = TetrisConstants.BoardWidth;


            int gridStartY = 40 / dividertje;
            int gridEndY = 680 / dividertje;
            int gridHeight = gridEndY - gridStartY;

            int blocksHeight = TetrisConstants.BoardHeight;

            int stepX = gridWidth / blocksWidth;
            int stepY = gridHeight / blocksHeight;

            //data.Save("testje.bmp", ImageFormat.Bmp);

            int startX = gridStartX + stepX / 2;
            int startY = gridStartY + stepY / 2;

            var g = panelToDrawIn.CreateGraphics();
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < blocksWidth; x++)
                {
                    var pixelX = startX + stepX * x;
                    var pixelY = startY + stepY * y;

                    int dingetje = 5;

                    var pixels = new List<Color>
                    {
                        data.GetPixel(pixelX, pixelY),
                        data.GetPixel(pixelX - stepX / dingetje, pixelY - stepY / dingetje),
                        data.GetPixel(pixelX + stepX / dingetje, pixelY - stepY / dingetje),
                        data.GetPixel(pixelX - stepX / dingetje, pixelY + stepY / dingetje),
                        data.GetPixel(pixelX + stepX / dingetje, pixelY + stepY / dingetje)
                    };

                    var darkest = Color.FromArgb(pixels.Min(t => t.R), pixels.Min(t => t.G), pixels.Min(t => t.B));

                    var avg = darkest.R + darkest.G + darkest.B / 3;

                    float hue = darkest.GetHue();
                    float saturation = darkest.GetSaturation();
                    float lightness = darkest.GetBrightness();

                    //if (darkest.R < BlackColorTreshhold && darkest.G < BlackColorTreshhold && darkest.B < BlackColorTreshhold)
                    //{
                    //    darkest = Color.Black;
                    //}
                    //else
                    //{
                    //    darkest = Color.Red;
                    //}
                    if (lightness < LightnessTreshhold)
                    {
                        darkest = Color.Black;
                    }
                    else
                    {
                        darkest = Color.Red;
                    }
                    var br = new SolidBrush(darkest);
                    g.FillRectangle(br, x * BlockSize, y * BlockSize, BlockSize, BlockSize);
                }
            }




            int xStepEersteBlokje = 18;
            int yStepEersteBlokje = 18;

            int xStartEersteBlokje = 824;
            int yStartEersteBlokje = 90;

            var graphicsPanel2 = panelToDrawIn2.CreateGraphics();
            int vakjeNummer = 0;

            DetectNextBlock(data, xStepEersteBlokje, yStepEersteBlokje, xStartEersteBlokje, yStartEersteBlokje, graphicsPanel2, 0);
            //Detect eerste blokje

            DetectNextBlock(data, 15, 15, 823, 151, graphicsPanel2, 1);
            DetectNextBlock(data, 15, 15, 823, 206, graphicsPanel2, 2);
            DetectNextBlock(data, 15, 15, 823, 260, graphicsPanel2, 3);
            DetectNextBlock(data, 15, 15, 823, 314, graphicsPanel2, 4);
            DetectNextBlock(data, 15, 15, 823, 370, graphicsPanel2, 5);

            data.Dispose();
        }

        private static void DetectNextBlock(Bitmap data, int stepX, int stepY, int xStart, int yStart, Graphics graphicsPanel2, int vakjeNummer)
        {
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    var pixelX = xStart + stepX * x;
                    var pixelY = yStart + stepY * y;

                    int dingetje = 5;

                    var pixels = new List<Color>
                    {
                        data.GetPixel(pixelX, pixelY),
                        data.GetPixel(pixelX - stepX / dingetje, pixelY - stepY / dingetje),
                        data.GetPixel(pixelX + stepX / dingetje, pixelY - stepY / dingetje),
                        data.GetPixel(pixelX - stepX / dingetje, pixelY + stepY / dingetje),
                        data.GetPixel(pixelX + stepX / dingetje, pixelY + stepY / dingetje)
                    };


                    var darkest = Color.FromArgb(pixels.Min(t => t.R), pixels.Min(t => t.G), pixels.Min(t => t.B));

                    var avg = darkest.R + darkest.G + darkest.B / 3;

                    float hue = darkest.GetHue();
                    float saturation = darkest.GetSaturation();
                    float lightness = darkest.GetBrightness();

                    //if (darkest.R < BlackColorTreshhold && darkest.G < BlackColorTreshhold && darkest.B < BlackColorTreshhold)
                    //{
                    //    darkest = Color.Black;
                    //}
                    //else
                    //{
                    //    darkest = Color.Red;
                    //}
                    if (lightness < 0.3f)
                    {
                        darkest = Color.Black;
                    }
                    else
                    {
                        darkest = Color.Red;
                    }
                    var br = new SolidBrush(darkest);
                    graphicsPanel2.FillRectangle(br, x * BlockSize, y * BlockSize + vakjeNummer * (BlockSize * 3), BlockSize, BlockSize);
                }
            }
        }
    }
}
