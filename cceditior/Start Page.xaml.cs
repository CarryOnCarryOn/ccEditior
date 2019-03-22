using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cceditior
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string InputPath;
        public MainWindow()
        {
            InitializeComponent();
        }

        //Create new editior window
      public void New_Button_Click(object sender, RoutedEventArgs e)
        {

            Data openData = new Data();
            openData.Show();
            this.Close();
        }
        // show screenshot of saved character sheet
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            System.Windows.Forms.FolderBrowserDialog SourceDialog = new System.Windows.Forms.FolderBrowserDialog();
            SourceDialog.RootFolder = Environment.SpecialFolder.Desktop;
            SourceDialog.Description = "     open     ";
            SourceDialog.ShowNewFolderButton = false;

            if (SourceDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InputPath = SourceDialog.SelectedPath;
            }
            string outputPath = InputPath + "\\" + "window" + ".png";
            if (File.Exists(outputPath))
            {
                FinalPage.Source = (new ImageSourceConverter()).ConvertFromString(outputPath) as ImageSource;
            }
            else
            {
                Console.WriteLine("File Doesn't exists.");
            }
        }
    }
}
