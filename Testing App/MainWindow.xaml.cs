using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Testing_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int clickCount = 1;
        public int doubleClickCount = 1;
        public float firstValue = 0;
        public float secondValue = 0;
        public float timerValue = 0;

        Stopwatch sw = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Count_Click(object sender, RoutedEventArgs e)
        {
            sw.Start();

            if (clickLbl.Content.ToString() != "0" && firstValue != 0)
            {
                secondValue = sw.ElapsedMilliseconds;
                timerValue = secondValue - firstValue;
                firstValue = secondValue;
            }
            else
            {
                firstValue = sw.ElapsedMilliseconds;
                timerValue = firstValue;
            }

            // Adding the timeValue after calculating to get the true result
            clickLbl.Content = clickCount++;
            timeLbl.Content = timerValue + " ms";

            // Show popup if value < 0.1s
            if (timerValue < 100 && timeLbl.Content.ToString() != "0 ms")
            {
                doubleLbl.Content = doubleClickCount++;
                MessageBox.Show("Double clicked");
            }
        }

        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            clickCount = 1;
            doubleClickCount = 1;
            firstValue = 0;
            secondValue = 0;
            timerValue = 0;

            timeLbl.Content = "0 ms";
            clickLbl.Content = "0";
            doubleLbl.Content = "0";

            sw.Reset();
        }
    }
}
