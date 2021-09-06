using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace FibonaciNumbers {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private double number1 = 1;
        private double number2 = 1;

        public MainWindow() {
            InitializeComponent();
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e) {
            Number1.Text = number1.ToString();
            Number2.Text = number2.ToString();
            double res = number1 + number2;
            Result.Text = (res/number1).ToString();
            number2 = number1;
            number1 = res;

            try {
                Number2.FontSize = Number1.FontSize = 100 - number1.ToString().Length * 5;
            } catch {
                Number2.FontSize = Number1.FontSize = 30;
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                DispatcherTimer dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = TimeSpan.FromSeconds(0.2);
                dispatcherTimer.Tick += dispatcherTimer_Tick;
                dispatcherTimer.Start();
            }
        }
    }
}
