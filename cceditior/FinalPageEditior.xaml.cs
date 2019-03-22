using System;
using System.Collections.Generic;
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

namespace cceditior
{
    /// <summary>
    /// Interaction logic for FinalPageEditior.xaml
    /// </summary>
    public partial class FinalPageEditior : Window
    {
        public static FinalPage myfpage = new FinalPage();
        public FinalPageEditior()
        {
            InitializeComponent();
            
        }

        private void Showinput(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog SourceDialog = new System.Windows.Forms.FolderBrowserDialog();
            SourceDialog.RootFolder = Environment.SpecialFolder.Desktop;
            SourceDialog.Description = "     open     ";
            SourceDialog.ShowNewFolderButton = false;

            if (SourceDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                inputpath.Text = SourceDialog.SelectedPath;
            }
            myfpage.characterimage.Source= (new ImageSourceConverter()).ConvertFromString(inputpath.Text) as ImageSource;

        }

        private void save(object sender, RoutedEventArgs e)
        {
            myfpage.Information.Text = bginfo.Text;
        }

        private void CheckcheckboxInventory()
        {
            foreach(CheckBox box in Text_Editor.mybox)
            {

                if(box.IsChecked==true)
                {
                    CheckBox tempbox=new CheckBox();
                    tempbox.Content = box.Content;
                    myfpage.namepanel.Children.Add(tempbox);
                }
            }
            
        }

        private void Done(object sender, RoutedEventArgs e)
        {
            CheckcheckboxInventory();
            myfpage.Show();
            this.Close();
        }
    }
}
