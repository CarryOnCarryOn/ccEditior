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
    /// Interaction logic for Data.xaml
    /// </summary>
    public partial class Data : Window
    {
        public Data()
        {
            InitializeComponent();
        }
       
        private void EditorButton_Click(object sender, RoutedEventArgs e)
        {
            Editor_Mode openEditorMode = new Editor_Mode();
            openEditorMode.Show();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow backToStart = new MainWindow();
            backToStart.Show();
            this.Close();
        }

        public Data(string strTextBox)
        {
            InitializeComponent();
            TitleName.Content = strTextBox;
        }

    }
}
