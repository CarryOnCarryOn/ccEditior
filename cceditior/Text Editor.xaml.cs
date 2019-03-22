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
using CheckBox = System.Windows.Controls.CheckBox;
using Label = System.Windows.Controls.Label;

namespace cceditior
{
    /// <summary>
    /// Text_Editor.xaml 的交互逻辑
    /// </summary>
    public partial class Text_Editor : Window
    {
        public static List<CheckBox> mybox = new List<CheckBox>();
        public static List<Label> mylabel = new List<Label>();
        Data sdn = new Data();
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
            sdn.ChangeTitleName(nameOftitle.Text);
            sdn.Show();
            this.Close();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
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
                System.Windows.Controls.CheckBox checkBox = new System.Windows.Controls.CheckBox();
                System.Windows.Controls.Label label = new System.Windows.Controls.Label();

                checkBox.Content = item.Name.ToString();
               label.Content = item.UnlockRequirement.ToString();
               label.Content = item.Description.ToString();
               sdn.ItemNameStackPanel.Margin = new Thickness(0, 0, 0, 0);
               sdn.ItemDataStackPanel.Margin = new Thickness(0, 0, 0, 0);
               sdn.ItemNameStackPanel.Children.Add(checkBox);
               sdn.ItemDataStackPanel.Children.Add(label);
               mybox.Add(checkBox);
               //mylabel.Add(label);
            }
        }
    }
}
