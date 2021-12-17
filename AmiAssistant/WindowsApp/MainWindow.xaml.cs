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
using Speaker_Engine;

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
            ni.Icon = Resource1.Hidden_Icon;

            //Form move
            MainBorder.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);

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

        //Form move
        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ContentControl User_Bubble = new ContentControl();
                User_Bubble.Content = User_Text.Text;
                User_Bubble.Style = Resources["BubbleLeftStyle"] as Style; ;
                Chat_Panel.Children.Add(User_Bubble);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Listen.Speaker();
            string res = Listen.respond;

            ContentControl Ami_bubble = new ContentControl();
            Ami_bubble.Content = res;
            Ami_bubble.Style = Resources["BubbleRightStyle"] as Style; ;
            Chat_Panel.Children.Add(Ami_bubble);
        }
    }

}
