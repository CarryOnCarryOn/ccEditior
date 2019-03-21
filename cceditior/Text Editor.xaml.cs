using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cceditior
{
    /// <summary>
    /// Text_Editor.xaml 的交互逻辑
    /// </summary>
    public partial class Text_Editor : Window
    {
        Data dataWindow = new Data();
        public Text_Editor()
        {
            InitializeComponent();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            Editor_Mode backToMode = new Editor_Mode();
            backToMode.Show();
            this.Close();
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        { 
            Data sdn = new Data(nameOftitle.Text);
            sdn.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            System.Windows.Controls.CheckBox checkBox = new System.Windows.Controls.CheckBox();
            System.Windows.Controls.Label label = new System.Windows.Controls.Label();
            string InputPath="null";
            ItemReader itemreader = new ItemReader();
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (System.Windows.Forms.DialogResult.OK == dialog.ShowDialog())
                {
                   InputPath = /*System.IO.Path.GetDirectoryName(*/dialog.FileName/*)*/;

                }
            }
            ItemList mylist= itemreader.Load(InputPath);
            foreach (Item item in mylist.Items)
            {


                        checkBox.Content = item.Name.ToString();
                        label.Content = item.UnlockRequirement.ToString();
                        label.Content = item.Description.ToString();



                Thickness margin = dataWindow.ItemNameStackPanel.Margin;
                margin.Top = 10;
                dataWindow.ItemNameStackPanel.Children.Add(checkBox);
                dataWindow.ItemDataStackPanel.Children.Add(label);
                //Todo:ADD THE ITEM to somewhere
            }
        }
    }
}
