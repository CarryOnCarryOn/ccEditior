using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Color = System.Drawing.Color;
using Rectangle = System.Drawing.Rectangle;
using System.Drawing.Imaging;
using System.Windows.Interop;

namespace cceditior
{
    /// <summary>
    /// Interaction logic for Image_Editior.xaml
    /// </summary>
    public partial class Image_Editior : Window
    {
        public Image_Editior()
        {
            InitializeComponent();
        }
        public System.Drawing.Image BGimg;
        public System.Drawing.Image CIimg;
        public Bitmap sheetCI;
        public Bitmap BitmapResult;
        public Bitmap sheetBG;
        public System.Drawing.Bitmap SmallPic(Bitmap strOldPic, int intWidth, int intHeight)
        {
            Bitmap objNewPic;
            try
            {
                objNewPic = new Bitmap(strOldPic, intWidth, intHeight);
                return objNewPic;
            }
            catch (Exception exp) { throw exp; }
        }

        public Bitmap JoinMImage(Bitmap sourceBitmap, Bitmap joinBitmap, Rectangle rc)
        {
            joinBitmap = SmallPic(joinBitmap, sourceBitmap.Width/2, sourceBitmap.Height/2);
            Bitmap TempsourceBitmap = sourceBitmap;
            Graphics gr = Graphics.FromImage(TempsourceBitmap);
            gr.DrawImage(joinBitmap, 50, 10, new RectangleF(rc.Left/2, rc.Top/2, (rc.Right - rc.Left)/2, (rc.Bottom - rc.Top)/2), GraphicsUnit.Pixel);
            gr.Dispose();
            return TempsourceBitmap;
        }

        public Bitmap JoinMImage(Bitmap sourceBitmap, Bitmap joinBitmap, Rectangle rc, int x, int y)
        {
            Bitmap TempsourceBitmap = sourceBitmap;
            Graphics gr = Graphics.FromImage(TempsourceBitmap);
            gr.DrawImage(joinBitmap, x, y, new RectangleF(rc.Left, rc.Top, rc.Right - rc.Left, rc.Bottom - rc.Top), GraphicsUnit.Pixel);
            gr.Dispose();
            return TempsourceBitmap;
        }

        private void ShowDialog_Input(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog SourceDialog = new System.Windows.Forms.FolderBrowserDialog();
            SourceDialog.RootFolder = Environment.SpecialFolder.Desktop;
            SourceDialog.Description = "     open     ";
            SourceDialog.ShowNewFolderButton = false;

            if (SourceDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InputPath_BG.Text = SourceDialog.SelectedPath;
            }
        }

        private void Combine_Image(object sender, RoutedEventArgs e)
        {
            string path = InputPath_BG.Text;
            int columns = 0;
            Int32.TryParse(NumOFClumns_BG.Text, out columns);

            if (!path.EndsWith(@"\")) path = path + @"\";

            string[] files = Directory.GetFiles(path, "*.png");
            int fileCount = files.Length;
            if (fileCount > 0)
            { 
                int maxWidth = 0;
                int maxHeight = 0;

                foreach (string f in files)
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromFile(f))
                    {
                        maxWidth = Math.Max(maxWidth, img.Width);
                        maxHeight = Math.Max(maxHeight, img.Height);
                    }

                }

                Console.WriteLine(" \n Largest input image is {0} x {1}.", maxWidth, maxHeight);
                if (fileCount < columns)
                {
                    Console.WriteLine("Single row, reducing column count to match file count.");
                    columns = fileCount;
                }
                int width = columns * maxWidth;
                int rows = (fileCount / columns) + ((fileCount % columns > 0) ? 1 : 0);
                int height = rows * maxHeight;

                Console.WriteLine("Output: {0} rows, {1} cols, {2} x {3} resolution.", rows, columns, width, height);
                Bitmap sheet = new Bitmap(width, height);
                
                using (Graphics gfx = Graphics.FromImage(sheet))
                {
                    int col = 0;
                    int row = 0;
                    foreach (string f in files)
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(f);
                        int x = (col * maxWidth) + (maxWidth / 2 - img.Width / 2);
                        int y = (row * maxHeight) + (maxHeight / 2 - img.Height / 2);
                        System.Drawing.Rectangle srcRect = new System.Drawing.Rectangle(0, 0, img.Width, img.Height);
                        System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x, y, img.Width, img.Height);
                        gfx.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
                        img.Dispose();
                        col++;
                        if (col == columns)
                        {
                            col = 0;
                            row++;
                        }
                    }
                }
                BGimg = (System.Drawing.Image)sheet;
                sheetBG = sheet;
               
            }
        }

        private void ShowCIInput(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog SourceDialog = new System.Windows.Forms.FolderBrowserDialog();
            SourceDialog.RootFolder = Environment.SpecialFolder.Desktop;
            SourceDialog.Description = "     open     ";
            SourceDialog.ShowNewFolderButton = false;

            if (SourceDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InputPath_CI.Text = SourceDialog.SelectedPath;
            }

        }

        private void CombineCIImage(object sender, RoutedEventArgs e)
        {
            string path = InputPath_CI.Text;
            int columns = 0;
            Int32.TryParse(NumOFClumns_CI.Text, out columns);

            if (!path.EndsWith(@"\")) path = path + @"\";

            string[] files = Directory.GetFiles(path, "*.png");
            int fileCount = files.Length;
            if (fileCount > 0)
            {
                int maxWidth = 0;
                int maxHeight = 0;

                foreach (string f in files)
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromFile(f))
                    {
                        maxWidth = Math.Max(maxWidth, img.Width);
                        maxHeight = Math.Max(maxHeight, img.Height);
                    }

                }

               
                if (fileCount < columns)
                {
                    
                    columns = fileCount;
                }
                int width = columns * maxWidth;
                int rows = (fileCount / columns) + ((fileCount % columns > 0) ? 1 : 0);
                int height = rows * maxHeight;
                Bitmap sheet = new Bitmap(width, height);
                using (Graphics gfx = Graphics.FromImage(sheet))
                {
                    int col = 0;
                    int row = 0;
                    foreach (string f in files)
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(f);
                        int x = (col * maxWidth) + (maxWidth / 2 - img.Width / 2);
                        int y = (row * maxHeight) + (maxHeight / 2 - img.Height / 2);
                        System.Drawing.Rectangle srcRect = new System.Drawing.Rectangle(0, 0, img.Width, img.Height);
                        System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x, y, img.Width, img.Height);
                        gfx.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
                        img.Dispose();
                        col++;
                        if (col == columns)
                        {
                            col = 0;
                            row++;
                        }
                    }
                }
                CIimg = (System.Drawing.Image)sheet;
                sheetCI = sheet;
            }
        }

        private void AddTxT(object sender, RoutedEventArgs e)
        {
          
            Color color=Color.LightSkyBlue;
            Bitmap TempsourceBitmap =sheetCI ;
             Font font = new Font("Times New Roman", 12.0f);
             int Width = CIimg.Width;
             int Height = CIimg.Height;
             float dpiX = CIimg.HorizontalResolution;
             float dpiY = CIimg.VerticalResolution;
                          
            Bitmap Bitmaptemp = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapResult = Bitmaptemp;
            BitmapResult.SetResolution(dpiX, dpiY);
                           
            Graphics Grp = Graphics.FromImage(BitmapResult);
            System.Drawing.Rectangle Rec = new System.Drawing.Rectangle(0, 0, Width, Height);
             
             Grp.DrawImage(CIimg, 0, 0, Rec, GraphicsUnit.Pixel);
             System.Drawing.Brush brush = System.Drawing.Brushes.Black;
             Grp.DrawString(InputTxT.Text,font, brush, 0, 0);
             Grp.ResetTransform();
             Grp.Dispose();
             GC.Collect();
             
                         

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Image_Window image_Window = new Image_Window();
            Rectangle rec = new Rectangle();
            rec.Width = (int)(image_Window.DisplayWindow.Width);
            rec.Height = (int)(image_Window.DisplayWindow.Height);
            Bitmap thismap;
            System.Drawing.Image thisimg;
            thismap= JoinMImage(sheetBG, BitmapResult, rec);
            thisimg = (System.Drawing.Image)thismap;
            BitmapSource bs = Imaging.CreateBitmapSourceFromHBitmap(thismap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            image_Window.imageShowing.Source = bs;
            image_Window.Show();
            this.Close();
        }


    }
}

