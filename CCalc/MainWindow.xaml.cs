using System.Collections.Generic;
using System.Windows;

namespace Credit_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Credit ipoteca;
        public MainWindow()
        {
            InitializeComponent();
           
            ipoteca = new Credit();
            DataContext = ipoteca;
            ipoteca.GetOverSet();
        }
        private void MenuItem_Insert(object sender, RoutedEventArgs e)
        {
            List<int> indexes = new List<int>();
            foreach (Payment p in ListView1.SelectedItems) { indexes.Add(p.Month - 1); }

            EnterWindow win = new EnterWindow();

            if (win.ShowDialog() == true)
            {
                foreach (int i in indexes)
                {
                    if ((bool)win.CheckBox_FixPay.IsChecked) ipoteca.Payments[i].OverPay = win.Overpay - ipoteca.Payments[i].Pay;
                    else ipoteca.Payments[i].OverPay = win.Overpay;
                    ipoteca.Payments[i].PayType = win.PayType;
                    ipoteca.GetOverSet();
                }
            }
        }

        private void MenuItem_Clear(object sender, RoutedEventArgs e)
        {
            List<int> indexes = new List<int>();
            foreach (Payment p in ListView1.SelectedItems) { indexes.Add(p.Month - 1); }

            foreach (int i in indexes)
            {
                ipoteca.Payments[i].OverPay = 0;
                ipoteca.Payments[i].PayType = OverPayType.None;
            }

            ipoteca.GetOverSet();
        }

        private void MenuItem_OverPayTypeChange(object sender, RoutedEventArgs e)
        {
            List<int> indexes = new List<int>();
            foreach (Payment p in ListView1.SelectedItems) { indexes.Add(p.Month - 1); }

            foreach (int i in indexes)
            {
                if (ipoteca.Payments[i].PayType == OverPayType.Amount) ipoteca.Payments[i].PayType = OverPayType.Time;
                else if (ipoteca.Payments[i].PayType == OverPayType.Time) ipoteca.Payments[i].PayType = OverPayType.Amount;
            }

            ipoteca.GetOverSet();
        }

        private void MenuItem_ClearAll(object sender, RoutedEventArgs e)
        {
            foreach (Payment p in ipoteca.Payments)
            {
                p.OverPay = 0;
                p.PayType = OverPayType.None;
            }

            ipoteca.GetOverSet();
        }

        private void MenuItem_Export1(object sender, RoutedEventArgs e)
        {
            Export.ExportExcel(ipoteca.Payments);
        }

        private void MenuItem_Export2(object sender, RoutedEventArgs e)
        {
            Export.ExportTXT(ipoteca.Payments);
        }

        private void MenuItem_Export3(object sender, RoutedEventArgs e)
        {
            Export.ExportCSV(ipoteca.Payments);
        }
    }
}
