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
    /// Interaction logic for Editor_Mode.xaml
    /// </summary>
    public partial class Editor_Mode : Window
    {
        public Editor_Mode()
        {
            InitializeComponent();
        }

        private void TextMode_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //show button
            TextEditor.Visibility = Visibility.Visible;
            //collapse buttons
            AddCharacterImage.Visibility = Visibility.Collapsed;
            AddBackgroundImage.Visibility = Visibility.Collapsed;
            Tips.Visibility = Visibility.Collapsed;
        }

        private void ImageMode_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //show button
            AddCharacterImage.Visibility = Visibility.Visible;
            AddBackgroundImage.Visibility = Visibility.Visible;
            //collapse buttons
            TextEditor.Visibility = Visibility.Collapsed;
            Tips.Visibility = Visibility.Collapsed;
        }

        private void ShowTips_Click(object sender, RoutedEventArgs e)
        {
            //show tips
            Tips.Visibility = Visibility.Visible;
            //unChecked
            TextMode.IsChecked = false;
            ImageMode.IsChecked = false;
            //collapse buttons
            TextEditor.Visibility = Visibility.Collapsed;
            AddCharacterImage.Visibility = Visibility.Collapsed;
            AddBackgroundImage.Visibility = Visibility.Collapsed;
        }

        private void TextEditor_Click(object sender, RoutedEventArgs e)
        {
            //switch window
            Text_Editor openTextEditor = new Text_Editor();
            openTextEditor.Show();
            this.Close();
        }
    }
}
