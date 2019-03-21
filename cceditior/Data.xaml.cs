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
        public static List<Data> mydata = new List<Data>();

        public Data()
        {
            InitializeComponent();
        }
       
        private void EditorButton_Click(object sender, RoutedEventArgs e)
        {
            Editor_Mode openEditorMode = new Editor_Mode();
            openEditorMode.Show();
            this.Close();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow backToStart = new MainWindow();
            backToStart.Show();
            this.Close();
        }

        public void ChangeTitleName(string name)
        {
            TitleName.Content = name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mydata.Add(this);
            Data openData = new Data();
            openData.Show();
            this.Close();
        }
    }
}
