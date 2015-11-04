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

namespace Mosaic_Image
{
    public partial class Form1 : Form
    {
        Bitmap TargetImage;
        PixelFormat TimageFormat;
        List<Image_mos> TileImageList = new List<Image_mos>();
        List<Color> AvgClrList = new List<Color>();
        Bitmap usedtempTile;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void TileBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser  =new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                string folderPath = folderBrowser.SelectedPath;
                ProcessDirectory(folderPath);

                foreach (Image_mos img in TileImageList)
                {
                    string filepath = img.filepath;
                    Color clr = Color.FromArgb(img.red, img.green, img.blue);
                    AvgClrList.Add(clr);
                }

                Console.WriteLine("Processing All files - Done!!!");
            }
        }

        private void TargetBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;

            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string imagePath = fileDialog.FileName;
                TargetImage = new Bitmap(imagePath);
                TimageFormat = TargetImage.PixelFormat;
            }

        }

        private void MosiacBtn_Click(object sender, EventArgs e)
        {
            processTagetImage(TargetImage);
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
            string [] SubDirectoryPaths = Directory.GetDirectories(DirectoryPath);
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
                Bitmap image = new Bitmap(file);
                Image_mos imageInfo = getImageAvgs(image, file);
                imageList.Add(imageInfo);
                Console.WriteLine(i + " " + file);
                i++;
            }
            return imageList;
        }

        public Image_mos getImageAvgs(Bitmap imagefile, string filePath)
        {

            List<Image_mos> images = new List<Image_mos>();

            //Color avgClr = getAvgClr(imagefile);
            Color avgClr = getAverageColour(imagefile);

            Image_mos image = new Image_mos { filepath= filePath, red = avgClr.R, green = avgClr.G, blue = avgClr.B };
            images.Add(image);

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
            List<Image_mos> imageInforList = new List<Image_mos>();

            if (checkJsonExist(DirectoryPath))
            {
                // get the list of image information. 

                string json = File.ReadAllText(DirectoryPath+@"\ImagesInfo.json");

                List<Image_mos> ImageAvgList = serializer.Deserialize<List<Image_mos>>(json);
                TileImageList.AddRange(ImageAvgList);
              
                int a = 1;
            }
            else
            {
                imageInforList = getImages(files);
                string imagesJson = serializer.Serialize(imageInforList);

                File.WriteAllText(DirectoryPath + @"\ImagesInfo.json", imagesJson);
                Console.WriteLine("Json created on " + DirectoryPath);
            }
        }

        public bool checkJsonExist(string directoryPath)
        {
            bool fileExist = File.Exists(directoryPath + @"\ImagesInfo.json");
            return fileExist;
        }

        public void processTagetImage(Bitmap Timage)
        {
            int nextX = 1;
            int nextY = 1;
            int tileSize = 5;

            Bitmap resizedTimage = ImageResize(Timage,tileSize);

            Bitmap tmpOut = new Bitmap(resizedTimage.Width, resizedTimage.Height, resizedTimage.PixelFormat);
            Graphics g = Graphics.FromImage(tmpOut);

            List<KeyValuePair<string,Bitmap>> usedTiles = new List<KeyValuePair<string,Bitmap>>();

            for (int x = 0; x < resizedTimage.Width; x += tileSize)
            {
                for (int y = 0; y < resizedTimage.Height; y += tileSize)
                {
                    Rectangle tileRect = new Rectangle(x, y, tileSize, tileSize);
                    Bitmap tile = resizedTimage.Clone(tileRect, TimageFormat);

                    Color clr = getAverageColour(tile);

                    int closestcolrIndex = closestColor(AvgClrList, clr);
                    Image_mos tileImageinfo = TileImageList.ElementAt(closestcolrIndex);

                    Rectangle destRct = new Rectangle(x, y, tileSize, tileSize);
                    Rectangle srcRct = new Rectangle(0, 0, tileSize, tileSize);

                    if(isTileExist(usedTiles,tileImageinfo.filepath))
                    {
                        g.DrawImage(usedtempTile, destRct, srcRct, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        using (Image tileImg = Image.FromFile(tileImageinfo.filepath))
                        {
                            Bitmap tileimage = new Bitmap(tileImg, tileSize, tileSize);
                        
                            usedTiles.Add(new KeyValuePair<string,Bitmap>(tileImageinfo.filepath,tileimage));

                            g.DrawImage(tileimage, destRct, srcRct, GraphicsUnit.Pixel);
                        }
                    
                    }

                    //Bitmap mosiac = 

                }
            }

            Image outputImage = tmpOut;
            Bitmap output = new Bitmap(outputImage, Timage.Size);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            output.Save(desktopPath+@"\output.jpg", ImageFormat.Jpeg);
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


        public Bitmap ImageResize(Bitmap TImage, int tileSize)
        {
            Image img = TImage;

            int width = img.Width;
            int height =img.Height;

            if (width % tileSize != 0)
            {
                while (width % tileSize != 0)
                {
                    if((width%tileSize)>(tileSize/2))
                    {
                        width++;
                    }
                    else
                    {
                        width--;
                    }
                }
            }
            if (height % tileSize != 0)
            {
                while (height % tileSize != 0)
                {
                    if((height%tileSize)>(tileSize/2))
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
            foreach(KeyValuePair<string, Bitmap> keyValue in usedTileList){
                if (keyValue.Key == tilePath)
                {
                    usedtempTile = keyValue.Value;
                    return true;
                }                
            }


            return false;
        }

    }
} 