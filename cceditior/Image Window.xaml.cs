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
    /// Interaction logic for Image_Editor.xaml
    /// </summary>
    public partial class Image_Window : Window
    {
        public Image_Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Editor_Mode openEditorMode = new Editor_Mode();
            openEditorMode.Show();
            this.Close();
        }
    }
}
