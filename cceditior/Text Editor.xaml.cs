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
    /// Text_Editor.xaml 的交互逻辑
    /// </summary>
    public partial class Text_Editor : Window
    {
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
            CheckBox checkBox = new CheckBox();
            Label label = new Label();

            ItemReader itemreader = new ItemReader();
            ItemList mylist= itemreader.Load("Item.xml");
            foreach (Item item in mylist.items)
            {
                switch (item.Name.ToString())
                {
                    case "Name":

                        break;
                    case "UnlockRequirement":

                        break;
                    case "Description":

                        break;
                    case "Effect":
                        break;
                }

                label.Content = item.Description;

                Data dataWindow = Application.Current.MainWindow as Data;
                dataWindow.ItemNameStackPanel.Children.Add(checkBox);
                dataWindow.ItemDataStackPanel.Children.Add(label);
                //Todo:ADD THE ITEM to somewhere
            }
        }
    }
}
