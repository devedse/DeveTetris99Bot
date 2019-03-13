using DirectShowLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeveTetris99Bot.Capture
{
    public class DirectShowCapturer
    {
        private readonly IAMStreamConfig iasc;
        private IFilterGraph2 graph;
        private ICaptureGraphBuilder2 captureGraph;
        private Size videoSize;
        private string error = "";
        private readonly List<object> devices = new List<object>();
        private int x = 0;
        private int y = 0;
        private readonly Tetris99BotForm form;
        private readonly PictureBox pictureBox;
        private readonly Action<Bitmap> imageDetected;

        public DirectShowCapturer(Tetris99BotForm form, PictureBox pictureBox, Action<Bitmap> imageDetected)
        {
            this.form = form;
            this.pictureBox = pictureBox;
            this.imageDetected = imageDetected;

            InitDevice();
        }


        private void InitDevice()
        {
            try
            {
                //Set the video size to use for capture and recording
                videoSize = new Size(1280, 720);//827, 505);//1280, 720);

                //Initialize filter graph and capture graph
                graph = (IFilterGraph2)new FilterGraph();
                captureGraph = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
                captureGraph.SetFiltergraph(graph);
                //rot = new DsROTEntry(graph);
                //Create filter for Elgato
                Guid elgatoGuid = new Guid("39F50F4C-99E1-464A-B6F9-D605B4FB5918");
                Type comType = Type.GetTypeFromCLSID(elgatoGuid);
                IBaseFilter elgatoFilter = (IBaseFilter)Activator.CreateInstance(comType);
                graph.AddFilter(elgatoFilter, "Elgato Video Capture Filter");

                //Create smart tee filter, add to graph, connect Elgato's video out to smart tee in
                IBaseFilter smartTeeFilter = (IBaseFilter)new SmartTee();
                graph.AddFilter(smartTeeFilter, "Smart Tee");
                IPin outPin = GetPin(elgatoFilter, "Video"); //GetPin(PinDirection.Output, "Video", elgatoFilter);
                                                             //IPin inPin = GetPin(elgatoFilter, "Video");//GetPin(PinDirection.Input, smartTeeFilter);
                IPin inPin = GetPin(smartTeeFilter, "Input");//GetPin(PinDirection.Input, smartTeeFilter);
                SetAndGetAllAvailableResolution(outPin);

                graph.Connect(outPin, inPin);

                //Create video renderer filter, add it to graph, connect smartTee Preview pin to video renderer's input pin
                IBaseFilter videoRendererFilter = (IBaseFilter)new VideoRenderer();

                graph.AddFilter(videoRendererFilter, "Video Renderer");
                // outPin = GetPin(elgatoFilter, "Video");//GetPin(PinDirection.Output, "Preview", smartTeeFilter);
                outPin = GetPin(smartTeeFilter, "Preview");//GetPin(PinDirection.Output, "Preview", smartTeeFilter);
                                                           //outPin = GetPin(smartTeeFilter, "Capture");//GetPin(PinDirection.Output, "Preview", smartTeeFilter);
                                                           // i'm trying to send the capture output to the screen.. but probably it won't be good

                //inPin = GetPin(elgatoFilter, "Video");//GetPin(PinDirection.Input, videoRendererFilter);
                inPin = GetPin(videoRendererFilter, "Input");//GetPin(PinDirection.Input, videoRendererFilter);
                graph.Connect(outPin, inPin);
                //Render stream from video renderer
                captureGraph.RenderStream(PinCategory.Preview, MediaType.Video, videoRendererFilter, null, null);
                //graph.Render(
                //Set the video preview to be the videoFeed panel
                IVideoWindow vw = (IVideoWindow)graph;
                vw.put_Owner(pictureBox.Handle);
                vw.put_MessageDrain(form.Handle);
                vw.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipSiblings | WindowStyle.ClipChildren);
                vw.SetWindowPosition(0, 0, videoSize.Width, videoSize.Height);//1280, 720);

                //Start the preview
                IMediaControl mediaControl = graph as IMediaControl;
                //pictureBox1.
                mediaControl.Run();


                Task.Run(() =>
                {
                    Task.Delay(1000).Wait();
                    while (true)
                    {
                        var ss = Screenshot(pictureBox);

                        //ss.Save("outputje.png", ImageFormat.Png);

                        try
                        {
                            imageDetected(ss);
                        }
                        catch (Exception ex)
                        {

                        }

                        Task.Delay(20).Wait();
                    }
                });
            }
            catch (Exception err)
            {
                error = err.ToString();
            }
        }


        private Bitmap Screenshot(Control con)
        {
            //create image area
            Bitmap image = new Bitmap(con.Bounds.Width, con.Bounds.Height);
            Graphics g = Graphics.FromImage(image);
            g.CompositingQuality = CompositingQuality.HighQuality;//set highquality

            Point location = new Point();
            form.Invoke(new Action(() =>
            {
                location = form.PointToScreen(con.Location);
            }));

            g.CopyFromScreen(location.X, location.Y, 0, 0, new Size(con.Bounds.Width, con.Bounds.Height));

            return image;
        }



        private IPin GetPin(IBaseFilter filter, string pinname)
        {
            int hr = filter.EnumPins(out IEnumPins epins);
            checkHR(hr, "Can't enumerate pins");
            IntPtr fetched = Marshal.AllocCoTaskMem(4);
            IPin[] pins = new IPin[1];
            while (epins.Next(1, pins, fetched) == 0)
            {
                pins[0].QueryPinInfo(out PinInfo pinfo);
                bool found = (pinfo.name == pinname);
                DsUtils.FreePinInfo(pinfo);
                if (found)
                {
                    return pins[0];
                }
            }
            checkHR(-1, "Pin not found");
            return null;
        }

        public void checkHR(int hr, string msg)
        {
            if (hr < 0)
            {
                MessageBox.Show(msg);
                DsError.ThrowExceptionForHR(hr);
            }

        }

        public void SetAndGetAllAvailableResolution(IPin VideoOutPin)
        {
            int hr = 0;
            IAMStreamConfig streamConfig = (IAMStreamConfig)VideoOutPin;
            AMMediaType CorectvidFormat = new AMMediaType();
            IntPtr ptr;
            hr = streamConfig.GetNumberOfCapabilities(out int piCount, out int piSize);
            ptr = Marshal.AllocCoTaskMem(piSize);
            for (int i = 0; i < piCount; i++)
            {
                hr = streamConfig.GetStreamCaps(i, out AMMediaType searchmedia, ptr);
                VideoInfoHeader v = new VideoInfoHeader();

                Marshal.PtrToStructure(searchmedia.formatPtr, v);
                if (i == 2)// 4
                {
                    CorectvidFormat = searchmedia;
                }
            }
            hr = streamConfig.SetFormat(CorectvidFormat);

            IntPtr pmt = IntPtr.Zero;
            AMMediaType mediaType = new AMMediaType();
            IAMStreamConfig streamConfig1 = (IAMStreamConfig)VideoOutPin;
            hr = streamConfig1.GetFormat(out mediaType);
            BitmapInfoHeader bmpih = new BitmapInfoHeader();
            Marshal.PtrToStructure(mediaType.formatPtr, bmpih);
            x = bmpih.Width;
            y = bmpih.Height;
        }

        private void Elgato_Video_Capture_Load(object sender, EventArgs e)
        {

        }
    }
}
