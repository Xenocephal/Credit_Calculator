using System;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListView1.Items.Clear();

            double.TryParse(TextBox_CreditCost.Text, out double creditCost);
            double.TryParse(TextBox_Percent.Text, out double rate);
            int.TryParse(TextBox_MonthCount.Text, out int monthCount);

            ipoteca = new Credit { Cost = creditCost, Rate = rate / 100, Period = monthCount };
            List<Payment> payments = ipoteca.Payments();
            foreach (Payment p in payments) { ListView1.Items.Add(p); }

            ShowResult(payments);
        }

        private void ShowResult(List<Payment> pays)
        {
            double fullCost = Credit.GetFullCost(ipoteca.Payments(pays));
            double overPayment = Credit.GetOverpayment(ipoteca.Payments(pays));

            Label_CreditCost.Content = String.Format("Полная стоимость кредита: {0:.00}", fullCost);
            Label_Overpay.Content = String.Format("Переплата: {0:.00}", overPayment);
            Label_Profit.Content = String.Format("Выгода: {0:0.00}", ipoteca.Overpayment - Credit.GetOverpayment(pays));
        }

        private void MenuItem_Insert(object sender, RoutedEventArgs e)
        {
            List<int> indexes = new List<int>();
            foreach (Payment p in ListView1.SelectedItems) { indexes.Add(p.MonthNum - 1); }

            EnterWindow win = new EnterWindow();

            if (win.ShowDialog() == true)
            {
                List<Payment> pays = new List<Payment>();
                foreach (Payment p in ListView1.Items) pays.Add(p);

                foreach (int i in indexes)
                {
                    if ((bool)win.CheckBox_FixPay.IsChecked)
                    {
                        pays[i].OverPay = win.Overpay - pays[i].Pay;
                        pays[i].PayType = win.PayType;
                    }
                    else
                    {
                        pays[i].OverPay = win.Overpay;
                        pays[i].PayType = win.PayType;
                    }
                    ListView1.Items.Clear();
                    foreach (Payment p in ipoteca.Payments(pays)) ListView1.Items.Add(p);
                }

                ShowResult(pays);
            }
        }

        private void MenuItem_Clear(object sender, RoutedEventArgs e)
        {
            List<int> indexes = new List<int>();
            foreach (Payment p in ListView1.SelectedItems) { indexes.Add(p.MonthNum - 1); }

            List<Payment> pays = new List<Payment>();
            foreach (Payment p in ListView1.Items) pays.Add(p);

            foreach (int i in indexes)
            {
                pays[i].OverPay = 0;
                pays[i].PayType = OverPayType.None;
            }

            ListView1.Items.Clear();
            foreach (Payment p in ipoteca.Payments(pays)) ListView1.Items.Add(p);

            ShowResult(pays);
        }

        private void MenuItem_OverPayTypeChange(object sender, RoutedEventArgs e)
        {
            List<int> indexes = new List<int>();
            foreach (Payment p in ListView1.SelectedItems) { indexes.Add(p.MonthNum - 1); }

            List<Payment> pays = new List<Payment>();
            foreach (Payment p in ListView1.Items) pays.Add(p);

            foreach (int i in indexes)
            {
                if (pays[i].PayType == OverPayType.Amount) pays[i].PayType = OverPayType.Time;
                else if (pays[i].PayType == OverPayType.Time) pays[i].PayType = OverPayType.Amount;
            }

            ListView1.Items.Clear();
            foreach (Payment p in ipoteca.Payments(pays)) ListView1.Items.Add(p);

            ShowResult(pays);
        }
    }
}
