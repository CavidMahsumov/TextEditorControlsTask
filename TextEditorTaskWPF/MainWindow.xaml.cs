using OpenQA.Selenium;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Keys = System.Windows.Forms.Keys;

namespace TextEditorTaskWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush Off = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        SolidColorBrush On = new SolidColorBrush(Color.FromRgb(240, 222, 45));
        public IWebElement txtProductSearch1 = null;
        public string FileName { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Bu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Bu.Toggled1==true)
            {
                SaveFileDialog save = new SaveFileDialog();
                if (FileName != null)
                {
                    using (StreamWriter streamWriter = new StreamWriter(FileName))
                    {
                        streamWriter.Write(MainTxtBox.Text);
                    }
                }
                //Light.Fill = On;


            }
            else
            {

                //Light.Fill = Off;
            }


        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
    

            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

        
            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                using (StringReader reader = new StringReader(openFileDlg.FileName))
                {
                    PathLabel.Content = reader.ReadToEnd();
                    FileName = openFileDlg.FileName;
                    MainTxtBox.Text = File.ReadAllText(PathLabel.Content.ToString());




                }
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            using (StreamWriter streamWriter = new StreamWriter(FileName))
            {
                streamWriter.Write(MainTxtBox.Text);
            }
        }

        private void MainTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Bu.Toggled1 == true)
            {
                SaveFileDialog save = new SaveFileDialog();

                using (StreamWriter streamWriter = new StreamWriter(FileName))
                {
                    streamWriter.Write(MainTxtBox.Text);
                }
            }
            else
            {

            }
        }

        private void CutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainTxtBox.Text != null)
            {
                MainTxtBox.Cut();
            }
        }

        private void CopyBnt_Click(object sender, RoutedEventArgs e)
        {
            if (MainTxtBox.Text != null)
            {
                MainTxtBox.Copy();
            }

        }

        private void PasteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainTxtBox.Text != null)
            {
                MainTxtBox.Paste();
            }
        }

        private void SelectAllBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainTxtBox.Text != null)
            {

                MainTxtBox.SelectAll();
                e.Handled = true;
                MainTxtBox.Focus();
            }
        }


    }
}
