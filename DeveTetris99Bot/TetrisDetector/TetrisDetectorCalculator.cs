using DeveTetris99Bot.Config;
using DeveTetris99Bot.Helpers;
using DeveTetris99Bot.Tetris;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DeveTetris99Bot.TetrisDetector
{
    public static class TetrisDetectorCalculator
    {
        private const int BlackColorTreshhold = 60;
        private const float LightnessTreshhold = 0.3f;

        public static TetrisDetectionData ScreenRefreshed(object sender, Bitmap data, Panel panelToDrawIn, Panel panelToDrawIn2)
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
            for (int y = 0; y < blocksHeight; y++)
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
                    g.FillRectangle(br, x * TetrisConstants.BlockSize, y * TetrisConstants.BlockSize, TetrisConstants.BlockSize, TetrisConstants.BlockSize);
                }
            }




            int xStepEersteBlokje = 18;
            int yStepEersteBlokje = 18;

            int xStartEersteBlokje = 824;
            int yStartEersteBlokje = 90;

            var graphicsPanel2 = panelToDrawIn2.CreateGraphics();

            var tetriminos = new List<Tetrimino>
            {
                DetectNextBlock(data, xStepEersteBlokje, yStepEersteBlokje, xStartEersteBlokje, yStartEersteBlokje, graphicsPanel2, 0),
                //Detect eerste blokje

                DetectNextBlock(data, 15, 15, 823, 151, graphicsPanel2, 1),
                DetectNextBlock(data, 15, 15, 823, 206, graphicsPanel2, 2),
                DetectNextBlock(data, 15, 15, 823, 260, graphicsPanel2, 3),
                DetectNextBlock(data, 15, 15, 823, 314, graphicsPanel2, 4),
                DetectNextBlock(data, 15, 15, 823, 370, graphicsPanel2, 5)
            };

            var detectionData = new TetrisDetectionData()
            {
                Danger = DetectDanger(data),
                TheNewIncomingTetriminos = tetriminos
            };

            data.Dispose();
            return detectionData;
        }

        private static int DetectDanger(Bitmap data)
        {
            int pixelX = 451;
            int pixelYStart = 664;
            int blockWidth = 32;
            int dingetje = blockWidth / 4;

            int dangerCount = 0;

            for (int y = 0; y < 20; y++)
            {
                var pixelY = pixelYStart - (y * blockWidth);

                var pixels = new List<Color>
                {
                    data.GetPixel(pixelX, pixelY),
                    data.GetPixel(pixelX - dingetje, pixelY - dingetje),
                    data.GetPixel(pixelX + dingetje, pixelY - dingetje),
                    data.GetPixel(pixelX - dingetje, pixelY + dingetje),
                    data.GetPixel(pixelX + dingetje, pixelY + dingetje)
                };

                var avgHue = pixels.Average(t => t.GetHue());
                var avgLightness = pixels.Average(t => Math.Max(Math.Max(t.R, t.G), t.B));


                var l1 = pixels[0].GetBrightness();
                var l2 = pixels[1].GetBrightness();
                var l3 = pixels[2].GetBrightness();
                var l4 = pixels[3].GetBrightness();
                var l5 = pixels[4].GetBrightness();



                if (avgLightness > 190 && avgHue > 340 && avgHue < 358f)
                {
                    dangerCount++;
                }
                else
                {
                    break;
                }
            }

            return dangerCount;
        }

        private static Tetrimino DetectNextBlock(Bitmap data, int stepX, int stepY, int xStart, int yStart, Graphics graphicsPanel2, int vakjeNummer)
        {
            bool[,] tetriminoArray = new bool[4, 4];

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
                        tetriminoArray[y + 1, x] = true;
                    }
                    var br = new SolidBrush(darkest);
                    graphicsPanel2.FillRectangle(br, x * TetrisConstants.BlockSize, y * TetrisConstants.BlockSize + vakjeNummer * (TetrisConstants.BlockSize * 3), TetrisConstants.BlockSize, TetrisConstants.BlockSize);
                }
            }

            if (tetriminoArray[0, 0] == false &&
                tetriminoArray[0, 1] == false &&
                tetriminoArray[0, 2] == false &&
                tetriminoArray[0, 3] == false &&
                tetriminoArray[0, 3] == false &&
                tetriminoArray[1, 3] == false &&
                tetriminoArray[2, 3] == false &&
                tetriminoArray[3, 3] == false)
            {
                tetriminoArray = MultiArrayHelper.TrimArray(0, 3, tetriminoArray);
            }

            int rowToCheck = tetriminoArray.GetLength(0) - 1;

            if (tetriminoArray[0, 0] == false &&
                tetriminoArray[rowToCheck, 1] == false &&
                tetriminoArray[rowToCheck, 2] == false &&
                tetriminoArray[1, 0] == false &&
                tetriminoArray[2, 0] == false)
            {
                tetriminoArray = MultiArrayHelper.TrimArray(rowToCheck, 0, tetriminoArray);
            }

            //    if (tetriminoArray[1, 0] == false &&
            //    tetriminoArray[1, 1] == false &&
            //    tetriminoArray[1, 2] == false &&
            //    tetriminoArray[1, 3] == false)
            //{
            //    tetriminoArray = new bool[1, 4] { { tetriminoArray[0, 0], tetriminoArray[0, 1], tetriminoArray[0, 2], tetriminoArray[0, 3] } };
            //}

            //if (tetriminoArray[0, 3] == false && tetriminoArray[1, 3] == false)
            //{
            //    tetriminoArray = new bool[2, 3] { { tetriminoArray[0, 0], tetriminoArray[0, 1], tetriminoArray[0, 2] }, { tetriminoArray[1, 0], tetriminoArray[1, 1], tetriminoArray[1, 2] } };
            //}

            //if (tetriminoArray[0, 0] == false && tetriminoArray[1, 0] == false)
            //{
            //    tetriminoArray = new bool[2, 2] { { tetriminoArray[0, 1], tetriminoArray[0, 2] }, { tetriminoArray[1, 1], tetriminoArray[1, 2] } };
            //}

            if (MultiArrayHelper.IsValidTetrino(tetriminoArray))
            {
                return new Tetrimino(tetriminoArray);
            }
            else
            {
                return null;
            }
        }



        //private static bool[,] RemoveColumn(bool[,] originalArray, int columnToRemove)
        //{
        //    bool[,] result = new bool[originalArray.GetLength(0), originalArray.GetLength(1) - 1];

        //    for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
        //    {
        //        for (int k = 0, u = 0; k < originalArray.GetLength(1); k++)
        //        {
        //            if (k == columnToRemove)
        //                continue;

        //            result[j, u] = originalArray[i, k];
        //            u++;
        //        }
        //        j++;
        //    }

        //    return result;
        //}

        //private static bool[,] RemoveRow(bool[,] originalArray, int rowToRemove)
        //{
        //    bool[,] result = new bool[originalArray.GetLength(0), originalArray.GetLength(1) - 1];

        //    for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
        //    {
        //        for (int k = 0, u = 0; k < originalArray.GetLength(1); k++)
        //        {
        //            if (k == columnToRemove)
        //                continue;

        //            result[j, u] = originalArray[i, k];
        //            u++;
        //        }
        //        j++;
        //    }

        //    return result;
        //}
    }
}
