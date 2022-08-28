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
        public float firstTimeValue = 0;
        public float secondTimeValue = 0;
        public float timeValue = 0;

        Stopwatch timer = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Count_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();

            // Calculating the time between 2 clicks
            if (countLbl.Content.ToString() != "0" && firstTimeValue != 0)
            {
                secondTimeValue = timer.ElapsedMilliseconds;
                timeValue = secondTimeValue - firstTimeValue;
                firstTimeValue = secondTimeValue;
            }
            // Check if the 1st run
            else
            {
                firstTimeValue = timer.ElapsedMilliseconds;
                timeValue = firstTimeValue;
            }

            // Adding the timeValue after calculating to get the true result
            countLbl.Content = clickCount++;
            timeLbl.Content = timeValue + " ms";

            // Show popup if value < 0.1s
            if (timeValue < 80 && timeLbl.Content.ToString() != "0 ms")
            {
                doubleLbl.Content = doubleClickCount++;
                MessageBox.Show("Double Clicked number " + (doubleClickCount - 1) + " at " + timeValue + " ms", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            // Reset variables to their 1st value
            clickCount = 1;
            doubleClickCount = 1;
            firstTimeValue = 0;
            secondTimeValue = 0;
            timeValue = 0;

            // Reset on UI
            timeLbl.Content = "0 ms";
            countLbl.Content = "0";
            doubleLbl.Content = "0";

            timer.Reset();
        }
    }
}
