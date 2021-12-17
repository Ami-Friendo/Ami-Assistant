using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
using Microsoft.Win32;
using IWshRuntimeLibrary;
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
            //ni.Icon = Resource1.Hidden_Icon;

            //Form move
            MainBorder.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);


            // autorun
            SetAutorunValue(true);
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
            //await Listen.Speaker();
            //string res = Listen.respond;
            await Listen.Speaker_Talk("Hi");
            string res = "Hi";
            ContentControl Ami_bubble = new ContentControl();
            Ami_bubble.Content = res;
            Ami_bubble.Style = Resources["BubbleRightStyle"] as Style; ;
            Chat_Panel.Children.Add(Ami_bubble);
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                System.IO.File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = System.IO.Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = System.IO.Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        public bool SetAutorunValue(bool autorun)
        {
            const string name = "AmiAssistant";
            const string nameExe = "WindowsApp.exe";
            string ExePathSource = System.Windows.Forms.Application.StartupPath;
            var ExeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) 
                + System.IO.Path.DirectorySeparatorChar + name + System.IO.Path.DirectorySeparatorChar;
            

            if (System.Windows.Forms.Application.ExecutablePath == ExeDirectory + nameExe)
            {
                return true;
            }
                
            if (!Directory.Exists(ExeDirectory + name))
            {
                Directory.CreateDirectory(ExeDirectory);
            }

            //DirectoryCopy(ExePathSource, ExeDirectory, true);
            CopyFilesRecursively(ExePathSource, ExeDirectory);

            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                {
                    reg.SetValue(name, ExeDirectory + nameExe);

                    // create shortcut
                    WshShell shell = new WshShell();
                    string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\AmiAssistant.lnk";
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                    shortcut.Description = "Ярлык для AmiAssistant";
                    shortcut.TargetPath = ExeDirectory + nameExe;
                    shortcut.Save();
                }
                else
                {
                    reg.DeleteValue(name);
                }
                    
                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }

}
