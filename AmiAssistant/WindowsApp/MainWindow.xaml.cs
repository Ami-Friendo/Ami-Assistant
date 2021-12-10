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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
        public MainWindow()
        {
            InitializeComponent();
            ni.Icon = new System.Drawing.Icon("1.ico");
        }
        private void Hidden_BTN_Click(object sender, RoutedEventArgs e)
        {
            ni.Visible = true;
            ni.DoubleClick += (sndr, args) =>
            {
                this.Show();
                WindowState = WindowState.Normal;
            };
            this.Hide();
        }   
        private void Close_BTN_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void FullScreen_BTN_Click(object sender, RoutedEventArgs e)
        {
            // add fullscreen func
        }

        private void Theme_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Setting_BTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Voice_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    #region Hide Button Click
    /*
     
    
        public MainWindow()
        {
            InitializeComponent();
            ni.Icon = new System.Drawing.Icon("111.ico");
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            
            Hide();
        }

     */
    #endregion
}
