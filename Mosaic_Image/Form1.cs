using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Drawing.Imaging;
using MLApp;

namespace Mosaic_Image
{
    public partial class Form1 : Form
    {
        MLApp.MLApp matlab;
        BackgroundWorker TileProcess;
        //BackgroundWorker TileNatProcess;
        BackgroundWorker MosiacProcess;
        BackgroundWorker MatLabProcess;
        Bitmap TargetImage;
        PixelFormat TimageFormat;
        List<Image_mos> TileImageList = new List<Image_mos>();
        List<Color> AvgClrList = new List<Color>();
        Bitmap usedtempTile;

        string Manmade = @"C:\Users\Rajith Hasith\OneDrive\University\Marsters\Computer Vision\Assignment\Images\Mosiac\Images\Manall";
        string Natural = @"C:\Users\Rajith Hasith\OneDrive\University\Marsters\Computer Vision\Assignment\Images\Mosiac\Images\NatAll";
        string TilesFolder;

        string folderPath;
        int tilePixSize;
        int HighestPerc;

        enum Catogaries { Man, Nat };
        string Catogary = "";

        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();

            TileProcess.WorkerReportsProgress = true;
            TileProcess.WorkerSupportsCancellation = true;

            //TileNatProcess.WorkerReportsProgress = true;
            //TileNatProcess.WorkerSupportsCancellation = true;

            MosiacProcess.WorkerReportsProgress = true;
            MosiacProcess.WorkerSupportsCancellation = true;

            ImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pers.Text = "";
           // Tile_nat_Btn.Enabled = false;
            Tile_Brws_Btn.Enabled = false;
            tileSize.Enabled = false;
            MosaicBtn.Enabled = false;
            cancelBtn.Enabled = false;
            TargetBtn.Enabled = false;


        }
        private void InitializeBackgroundWorker()
        {
            TileProcess = new BackgroundWorker();
            TileProcess.DoWork +=
                new DoWorkEventHandler(TileBackground_DoWork);
            TileProcess.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            TileBackground_RunWorkerCompleted);
            //backgroundWork.ProgressChanged +=
            //    new ProgressChangedEventHandler(
            //backgroundWorker1_ProgressChanged);

            //TileNatProcess = new BackgroundWorker();
            //TileNatProcess.DoWork +=
            //    new DoWorkEventHandler(TileNatBackground_DoWork);
            //TileNatProcess.RunWorkerCompleted +=
            //    new RunWorkerCompletedEventHandler(
            //TileNatBackground_RunWorkerCompleted);

            MosiacProcess = new BackgroundWorker();
            MosiacProcess.DoWork += new DoWorkEventHandler(MosiacBackground_DoWork);
            MosiacProcess.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MosiacBackground_RunWorkerCompletes);
            MosiacProcess.ProgressChanged += new ProgressChangedEventHandler(MosiacBackground_ProgressChanges);

            MatLabProcess = new BackgroundWorker();
            MatLabProcess.DoWork += new DoWorkEventHandler(MatLabBackground_DoWork);
            MatLabProcess.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MatLabBackground_RunWorkerCompletes);

            MatLabProcess.RunWorkerAsync();
        }

       

        private void MatLabBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            matlab = new MLApp.MLApp();
        }

        private void MatLabBackground_RunWorkerCompletes(object sender, RunWorkerCompletedEventArgs e)
        {
            TargetBtn.Enabled = true;
        }

        
        private void MosiacBackground_ProgressChanges(object sender, ProgressChangedEventArgs e)
        {
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    ImageProgressBar.Value = e.ProgressPercentage;
            //    pers.Text =(e.ProgressPercentage.ToString() + "%");
            //}));
            ImageBox.Image = tmpOut;
            ImageProgressBar.Value = e.ProgressPercentage;
            pers.Text = (e.ProgressPercentage.ToString() + "% of the Mosaic Created...");
        }

        private void MosiacBackground_RunWorkerCompletes(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MosiacImgDneTxt.Text = "Cancelled!";
            }
            else
            {
                ImageProgressBar.Value = 100;
                MosiacImgDneTxt.Text = "Mosiac Created at, Desktop as \"output.jpg\"";
                pers.Text = ("Done!");
                Console.WriteLine("Processing All files - Done!!!");
            }
        }

        private void MosiacBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            processTagetImage((Bitmap)e.Argument);
        }

        //private void Tile_nat_Btn_Click(object sender, EventArgs e)
        //{
        //    Tile_nat_DneTxt.Text = "Please Select Natural Images Folder...";
        //    FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
        //    DialogResult result = folderBrowser.ShowDialog();

        //    if (result == DialogResult.OK)
        //    {
        //        Tile_nat_DneTxt.Text = "Please Wait...";
        //        folderPath = folderBrowser.SelectedPath;
        //        //if ((Tile_man_DneTxt.Text == "Please Wait...") && (Tile_nat_DneTxt.Text == "Please Wait..."))
        //        //{
        //        //    tileSize.Enabled = true;
        //        //}
        //        //ProcessDirectory(folderPath);
        //        //TileManProcess.RunWorkerAsync(folderPath);
        //        TileNatProcess.RunWorkerAsync(folderPath);
                
        //    }
        //    else
        //    {
        //        Tile_nat_DneTxt.Text = "Please Select Natural Images Folder...";
        //        tileSize.Enabled = false;
        //    }
        //}

        private void Tile_Brws_Btn_Click(object sender, EventArgs e)
        {
            Tile_man_DneTxt.Text = "Please Select Manmade Images Folder...";
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                Tile_man_DneTxt.Text = "Please Wait...";
                folderPath = folderBrowser.SelectedPath;
                //if ((Tile_man_DneTxt.Text == "Please Wait...") && (Tile_nat_DneTxt.Text == "Please Wait..."))
                //{
                //    tileSize.Enabled = true;
                //}
                //ProcessDirectory(folderPath);
                TileProcess.RunWorkerAsync(folderPath);
                
            }
            else
            {
                Tile_man_DneTxt.Text = "Please Select Manmade Images Folder...";
                tileSize.Enabled = false;
            }
        }


        private void TileBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            ProcessDirectory((string)e.Argument);
        }

        private void TileBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                Tile_man_DneTxt.Text = "Cancelled!";
            }
            else
            {
                Tile_man_DneTxt.Text = "Done!";
                Console.WriteLine("Processing All files - Done!!!");
                tileSize.Enabled = true;
            }
        }

        //private void TileNatBackground_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    BackgroundWorker worker = sender as BackgroundWorker;

        //    ProcessDirectory((string)e.Argument);
        //}

        //private void TileNatBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Error != null)
        //    {
        //        MessageBox.Show(e.Error.Message);
        //    }
        //    else if (e.Cancelled)
        //    {
        //        Tile_nat_DneTxt.Text = "Cancelled!";
        //    }
        //    else
        //    {
        //        Tile_nat_DneTxt.Text = "Done!";
        //        Console.WriteLine("Processing All files - Done!!!");
        //        if ((Tile_man_DneTxt.Text == "Done!") && (Tile_nat_DneTxt.Text == "Done!"))
        //        {
        //            tileSize.Enabled = true;
        //        }
        //    }
        //}

        private void TargetBtn_Click(object sender, EventArgs e)
        {

            TrgtImgDneTxt.Text = "Plaese Select a Target Image...";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;

            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                TrgtImgDneTxt.Text = "Please Wait...";
                string imagePath = fileDialog.FileName;
                TargetImage = new Bitmap(imagePath);
                TimageFormat = TargetImage.PixelFormat;

                Catogary = ClassifyImage(imagePath);

                if (Catogary == "Man")
                {
                    TilesFolder = Manmade;
                }
                else if (Catogary == "Nat")
                {
                    TilesFolder = Natural;
                }

                TrgtImgDneTxt.Text = "Done!";
                ImageBox.Image = TargetImage;
                Tile_Brws_Btn.Enabled = true;
                tileSize.Enabled = true;
                //Tile_nat_Btn.Enabled = true;
            }
            else
            {
                TrgtImgDneTxt.Text = "Plaese Select a Target Image...";
                ImageBox.Image = null;
                Tile_Brws_Btn.Enabled = false;
                tileSize.Enabled = false;
               // Tile_nat_Btn.Enabled = false;
            }

            
            
        }

        private void MosiacBtn_Click(object sender, EventArgs e)
        {
            // processTagetImage(TargetImage);
            HighestPerc = 0;
            MosiacImgDneTxt.Text = "Mosiac Creating, Please Wait...";
            MosiacProcess.RunWorkerAsync(TargetImage);
        }


        public void ProcessDirectory(String DirectoryPath)
        {

            List<Image_mos> test = new List<Image_mos>();
            string[] files = Directory.GetFiles(DirectoryPath);
            if (files.Length != 0)
            {
                createJson(files, DirectoryPath);
            }
            else
                Console.WriteLine("No Files in this Directory!");
            string[] SubDirectoryPaths = Directory.GetDirectories(DirectoryPath);
            foreach (string subDirect in SubDirectoryPaths)
            {
                ProcessDirectory(subDirect);
            }


        }

        public List<Image_mos> getImages(string[] files)
        {
            List<Image_mos> imageList = new List<Image_mos>();
            int i = 1;
            foreach (string file in files)
            {
                //if (Catogary == ClassifyImage(file))
                //{
                using (Bitmap image = new Bitmap(file))
                {
                    Image_mos imageInfo = getImageAvgs(image, file);
                    imageList.Add(imageInfo);
                }
                //}

                Console.WriteLine(i + " " + file);
                i++;

            }
            return imageList;
        }

        public Image_mos getImageAvgs(Bitmap imagefile, string filePath)
        {

            //Color avgClr = getAvgClr(imagefile);
            Color avgClr = getAverageColour(imagefile);

            Image_mos image = new Image_mos { filepath = filePath, red = avgClr.R, green = avgClr.G, blue = avgClr.B };

            return image;
        }

        public Color getAvgClr(Bitmap imagefile)
        {

            List<Image_mos> images = new List<Image_mos>();
            //Bitmap image1 = image;

            long red = 0;
            long green = 0;
            long blue = 0;

            long total = 0;

            for (int x = 0; x < imagefile.Width; x++)
            {
                for (int y = 0; y < imagefile.Height; y++)
                {
                    Color clr = imagefile.GetPixel(x, y);

                    red += clr.R;
                    green += clr.G;
                    blue += clr.B;

                    total++;
                }
            }

            red /= total;
            green /= total;
            blue /= total;

            Color AvgClr = Color.FromArgb((int)red, (int)green, (int)blue);

            return AvgClr;
        }

        public void createJson(string[] files, string DirectoryPath)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            if (checkJsonExist(DirectoryPath))
            {
                // get the list of image information. 

                string json = File.ReadAllText(DirectoryPath + @"\ImagesInfo.json");

                List<Image_mos> ImageAvgList = serializer.Deserialize<List<Image_mos>>(json);
                
                foreach(Image_mos image in ImageAvgList)
                {
                    //if (Catogary == ClassifyImage(image.filepath))
                    //{
                        TileImageList.Add(image);
                    //}
                }
                //TileImageList.AddRange(ImageAvgList);

                int a = 1;
            }
            else
            {
                TileImageList = getImages(files);
                string imagesJson = serializer.Serialize(TileImageList);

                File.WriteAllText(DirectoryPath + @"\ImagesInfo.json", imagesJson);
                Console.WriteLine("Json created on " + DirectoryPath);
            }

            //foreach (Image_mos img in TileImageList)
            //{
            //    string filepath = img.filepath;
            //    Color clr = Color.FromArgb(img.red, img.green, img.blue);
            //    AvgClrList.Add(clr);
            //}
        }

        public bool checkJsonExist(string directoryPath)
        {
            bool fileExist = File.Exists(directoryPath + @"\ImagesInfo.json");
            return fileExist;
        }

        Bitmap tmpOut;
        public void processTagetImage(Bitmap Timage)
        {

            int nextX = 1;
            int nextY = 1;

            string[] files = Directory.GetFiles(TilesFolder);
            createJson(files, TilesFolder);

            foreach (Image_mos img in TileImageList)
            {
                string filepath = img.filepath;
                Color clr = Color.FromArgb(img.red, img.green, img.blue);
                AvgClrList.Add(clr);
            }

            Bitmap resizedTimage = ImageResize(Timage, tilePixSize);

            tmpOut = new Bitmap(resizedTimage.Width, resizedTimage.Height, resizedTimage.PixelFormat);
            Graphics g = Graphics.FromImage(tmpOut);

            List<KeyValuePair<string, Bitmap>> usedTiles = new List<KeyValuePair<string, Bitmap>>();
            int numOfPixels = 0;
            int percentage = 0;
            for (int x = 0; x < resizedTimage.Width; x += tilePixSize)
            {
                for (int y = 0; y < resizedTimage.Height; y += tilePixSize)
                {

                    Rectangle tileRect = new Rectangle(x, y, tilePixSize, tilePixSize);
                    Bitmap tile = resizedTimage.Clone(tileRect, TimageFormat);

                    Color clr = getAverageColour(tile);

                    int closestcolrIndex = closestColor(AvgClrList, clr);
                    Image_mos tileImageinfo = TileImageList.ElementAt(closestcolrIndex);

                    Rectangle destRct = new Rectangle(x, y, tilePixSize, tilePixSize);
                    Rectangle srcRct = new Rectangle(0, 0, tilePixSize, tilePixSize);

                    if (isTileExist(usedTiles, tileImageinfo.filepath))
                    {
                        g.DrawImage(usedtempTile, destRct, srcRct, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        using (Image tileImg = Image.FromFile(tileImageinfo.filepath))
                        {
                            Bitmap tileimage = new Bitmap(tileImg, tilePixSize, tilePixSize);

                            usedTiles.Add(new KeyValuePair<string, Bitmap>(tileImageinfo.filepath, tileimage));

                            g.DrawImage(tileimage, destRct, srcRct, GraphicsUnit.Pixel);
                        }
                    }

                    numOfPixels++;


                    percentage = Convert.ToInt32((((float)(x * resizedTimage.Height) + y) / (float)(resizedTimage.Width * resizedTimage.Height)) * 100);
                    //(int)((float)(numOfPixels*(tilePixSize*tilePixSize)) / (float)(resizedTimage.Width * resizedTimage.Height))*100;

                    if (percentage > HighestPerc)
                    {
                        HighestPerc = percentage;
                        MosiacProcess.ReportProgress(percentage);
                    }

                }
            }

            Image outputImage = tmpOut;
            Bitmap output = new Bitmap(outputImage, Timage.Size);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            output.Save(desktopPath + @"\output.jpg", ImageFormat.Jpeg);

            TargetImage = null;
            TimageFormat = new PixelFormat();
            TileImageList = new List<Image_mos>();
            AvgClrList = new List<Color>();
            usedtempTile = null;
        }

        // distance in RGB space
        int ColorDiff(Color c1, Color c2)
        {
            return (int)Math.Sqrt((c1.R - c2.R) * (c1.R - c2.R)
                                   + (c1.G - c2.G) * (c1.G - c2.G)
                                   + (c1.B - c2.B) * (c1.B - c2.B));
        }

        // closed match in RGB space
        int closestColor(List<Color> colors, Color target)
        {
            var colorDiffs = colors.Select(n => ColorDiff(n, target)).Min(n => n);
            return colors.FindIndex(n => ColorDiff(n, target) == colorDiffs);
        }

        public static Color getAverageColour(Bitmap bmp)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
            //lock bits from image into rectangle and into bitmapdata
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
            long red = 0; //ints that hold the total of each colour in the image
            long green = 0;
            long blue = 0;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    int position = (y * bmpData.Stride) + (x * System.Drawing.Image.GetPixelFormatSize(bmpData.PixelFormat) / 8);
                    blue += rgbValues[position];
                    green += rgbValues[position + 1];
                    red += rgbValues[position + 2];
                }
            }
            bmp.UnlockBits(bmpData);
            long divider = bmp.Width * bmp.Height;
            Color avgColor = Color.FromArgb((int)(red / divider), (int)(green / divider), (int)(blue / divider));
            //int[] average = new int[] { blue / divider, green / divider, red / divider };
            return avgColor;
        }


        public Bitmap ImageResize(Bitmap TImage, int tilePixSize)
        {
            Image img = TImage;

            int width = img.Width;
            int height = img.Height;

            if (width % tilePixSize != 0)
            {
                while (width % tilePixSize != 0)
                {
                    if ((width % tilePixSize) > (tilePixSize / 2))
                    {
                        width++;
                    }
                    else
                    {
                        width--;
                    }
                }
            }
            if (height % tilePixSize != 0)
            {
                while (height % tilePixSize != 0)
                {
                    if ((height % tilePixSize) > (tilePixSize / 2))
                    {
                        height++;
                    }
                    else
                    {
                        height--;
                    }
                }
            }

            return new Bitmap(img, width, height);
        }

        public bool isTileExist(List<KeyValuePair<string, Bitmap>> usedTileList, string tilePath)
        {
            usedtempTile = null;
            foreach (KeyValuePair<string, Bitmap> keyValue in usedTileList)
            {
                if (keyValue.Key == tilePath)
                {
                    usedtempTile = keyValue.Value;
                    return true;
                }
            }


            return false;
        }


        private string ClassifyImage(string ImagePath)
        {
            try
            {
                matlab.Execute(@"cd C:\Users\MatlabFiles\");
            }
            catch (Exception e)
            {

            }
            object result = null;

            matlab.Feval("ClassifyImage", 1, out result, ImagePath);

            object[] res = result as object[];
            object[,] cat = res[0] as object[,];
            string Class = cat[0, 0] as string;


            return Class;

        }

        private void tileSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tileSizeIndex = tileSize.SelectedIndex;
            if (tileSizeIndex >= 0)
            {
                switch(tileSizeIndex){
                    case 0:
                        tilePixSize = 5;
                        break;
                    case 1:
                        tilePixSize = 10;
                        break;
                    case 2:
                        tilePixSize = 25;
                        break;
                    case 3:
                        tilePixSize = 50;
                        break;
                    case 4:
                        tilePixSize = 75;
                        break;
                    case 5:
                        tilePixSize = 100;
                        break;
                }

                MosaicBtn.Enabled = true;
               
            }
            else
            {
                MosaicBtn.Enabled = false;
            }
        }

    }
} 