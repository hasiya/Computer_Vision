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

namespace Mosaic_Image
{
    public partial class Form1 : Form
    {
        Bitmap TargetImage;

        
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
            }

        }

        public void ProcessDirectory(String DirectoryPath)
        {

            List<Image> test = new List<Image>();
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

        public List<Image> getImages(string[] files)
        {
            List<Image> imageList = new List<Image>();
            int i = 1;
            foreach (string file in files)
            {
                Bitmap image = new Bitmap(file);
                Image imageInfo = getAvgClr(image, file);
                imageList.Add(imageInfo);
                Console.WriteLine(i + " " + file);
                i++;
            }
            return imageList;
        }

        public Image getAvgClr(Bitmap imagefile, string filePath)
        {

            List<Image> images = new List<Image>();
            //Bitmap image1 = image;
         
            int red = 0;
            int green = 0;
            int blue = 0;

            int total = 0;

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

            Image image = new Image { filepath= filePath, red = red, green = green, blue = blue };
            images.Add(image);

            return image;
        }

        public void createJson(string[] files, string DirectoryPath)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Image> imageInforList = new List<Image>();

            if (checkJsonExist(DirectoryPath))
            {
                // get the list of image information. 
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
            int tileSize = 100;
            for (int x = 0; x < Timage.Width; x++)
            {
                if (x <= tileSize)
                {
                    nextX++;
                }
                for (int y = 0; y < Timage.Height;y++)
                {


                    if (y <= tileSize)
                    {
                        nextY++;
                    }
                    Color clr = Timage.GetPixel((x + (nextX * tileSize)), (y + (nextY * tileSize)));
                }
            }
        }

    }
} 