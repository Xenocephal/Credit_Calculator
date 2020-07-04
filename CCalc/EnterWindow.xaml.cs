using System;
using System.Windows;

namespace Credit_Calc {
    /// <summary>
    /// Interaction logic for EnterWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window {
        public EnterWindow() {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e) { this.DialogResult = true; }
        private double Pay { get; set; } = 25000;
        public double Overpay {
            get {
                if (double.TryParse(TextBox_Overpay.Text, out double pay)) return pay;
                else return 0;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ComboBox_PayType.Items.Add(OverPayType.Amount);
            ComboBox_PayType.Items.Add(OverPayType.Time);
        }
        public OverPayType PayType { get { return (OverPayType)ComboBox_PayType.SelectedItem; } }
        private void CheckBox_FixPay_Checked(object sender, RoutedEventArgs e) {
            if ((bool)CheckBox_FixPay.IsChecked) TextBox_Overpay.Text = String.Format($"{Overpay + Pay}");
        }
    }
}
