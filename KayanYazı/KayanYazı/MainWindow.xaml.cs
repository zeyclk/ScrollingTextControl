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
using System.Windows.Threading;

namespace KayanYazı
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        DispatcherTimer tm;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tm = new DispatcherTimer();
            tm.Interval = TimeSpan.FromMilliseconds(0.5);//Saniyenin 10 binde biri olan ms ataması
            tm.Tick += tm_Tick;
            tm.Start();

            t1.BorderThickness = new Thickness(0); //texbox çercevesinin kaldırılması
        }

        //Atanan milisaniyede ne yapılması gerektiğini yazacağız. 
        private void tm_Tick(object sender, EventArgs e)
        {
            double x = Canvas.GetLeft(t1);//texboxın Canvas içerisinde soldan konumunun ataması
            
            if (x < -t1.Width) 
            {
                x = this.Width;
            }

            Canvas.SetLeft(t1, x-3); //elementin Canvasın soluna göre 3 birim eksiğine göre pozisyonlandırılması 
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tm.Stop();
        }

       
      
      
        private void t1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (t1.Text == string.Empty)
                t1.Text = "Metninizi giriniz";
        }

        private void t1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (t1.Text == "Metninizi giriniz")
                t1.Text = string.Empty;
        }
    }
}
