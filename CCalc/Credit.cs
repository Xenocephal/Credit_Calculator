using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Credit_Calc
{
    public class Credit : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        // ----------------------------- ВХОДНЫЕ ДАННЫЕ ------------------------------
        // Стоимость кредита
        private double cost = 100000;
        public double Cost {
            get { return cost; }
            set { if (value >= 0) cost = value; GetOverSet(); }
        }

        // Процентная ставка    
        private double rate = 10;
        public double Rate {
            get { return rate; }
            set { if (value >= 0) rate = value; GetOverSet(); }
        }

        // Срок погашения   
        private int period = 12;
        public int Period {
            get { return period; }
            set {
                if (value >= 0) period = value;
                if (value > Payments.Count) 
                    for (int i = Payments.Count; i < Period; i++) Payments.Add(new Payment { Pay = 0, Month = i + 1, Percents = 0, Last = 0 });     
                else if (value < Payments.Count) for (int i = Payments.Count - 1; i >= value; i--) { Payments.RemoveAt(i); }
                GetOverSet();
            }
        }

        // ----------------------------- КОНСТРУКТОРЫ И КОЛЛЕКЦИИ ------------------------------
        public ObservableCollection<Payment> Payments { get; set; } = new ObservableCollection<Payment>();
        public ObservableCollection<Payment> PaymentList() {
            double P, P1, Sn;
            Sn = Cost;
            ObservableCollection<Payment> list = new ObservableCollection<Payment>();
            for (int i = 0; i < Period; i++) {
                P = GetPay(Sn, Rate / 12 / 100, Period - i);
                P1 = GetPercentPay(Sn, Rate / 12 / 100);
                Sn = GetLast(Sn, P, P1);
                Payment p = new Payment { Month = i + 1, Pay = P, Percents = P1, Last = Sn };
                list.Add(p);
            }
            return list;
        }

        public Credit() { Payments = PaymentList(); }
        public Credit(double Cost, double Rate, int Period) {
            this.Cost = Cost;
            this.Rate = Rate;
            this.Period = Period;
            Payments = PaymentList();
        }

        // ----------------------------- РЕЗУЛЬТАТЫ ВЫЧИСЛЕНИЙ ------------------------------

        // Начальная сумма платежа
        public double StartPay { get { return GetPay(Cost, Rate / 12 / 100, Period); } }

        private double fullCost = 0; // Полная стоимость кредита
        public double FullCost {  
            get { return fullCost; }
            set { fullCost = value; OnPropertyChanged("FullCost"); }
        }

        private double overpayment = 0; // Переплата по кредиту
        public double Overpayment {  
            get { return overpayment; }
            set { overpayment = value; OnPropertyChanged("Overpayment"); }
        }

        private double profit = 0; // Выгода с учетом досрочного погашения
        public double Profit {
            get { return profit; }
            set { profit = value; OnPropertyChanged("Profit"); }
        }

        // ----------------------------- ФУНКЦИИ И МЕТОДЫ РАСЧЕТА ------------------------------

        // S - остаточная стоимость кредита
        // i - 1/12 годовой процентной ставки
        // n - срок выплат
        // P - сумма платежа
        // P1 - сумма процентов в платеже 

        // Функция расчета платежа по кредиту где 
        readonly static Func<double, double, int, double> GetPay = (S, i, n) => S * (i + i / (Math.Pow(1 + i, n) - 1));

        // Функция расчета суммы процентов а платеже
        readonly static Func<double, double, double> GetPercentPay = (Sn, i) => Sn * i;

        // Функция расчета суммы остатка по кредиту
        readonly static Func<double, double, double, double> GetLast = (Sn, P, P1) => Sn - (P - P1);
       
        public void GetOverSet() { // Метод перерасчета платежей
            double P, P1, Sn;
            Sn = Cost;
            P = GetPay(Sn, Rate / 12 / 100, Period);
            P1 = GetPercentPay(Sn, Rate / 12 / 100);
            Sn = GetLast(Sn, P, P1);

            for (int i = 0; i < Payments.Count; i++) {
                Payments[i].Pay = P;
                Payments[i].Percents = P1;
                Payments[i].Last = Sn;

                if (Payments[i].OverPay > 0) { Sn = Sn - Payments[i].OverPay; }
                if (Payments[i].PayType == OverPayType.Amount) P = GetPay(Sn, Rate / 12 / 100, Period - i - 1);

                P1 = GetPercentPay(Sn, Rate / 12 / 100);

                if (P >= Sn + P1) P = P1 + Sn;
                else if (Sn == 0) { P = 0; P1 = 0; }

                Sn = GetLast(Sn, P, P1);
            }

            FullCost = GetFullCost();
            Overpayment = GetOverpayment();
            Profit = Period * StartPay - FullCost;
        }

        private double GetFullCost() { // Метод получения суммы платежей
            double sum = 0;
            foreach (Payment p in Payments) sum += p.Pay + p.OverPay;
            return sum;
        }

        private double GetOverpayment() { // Метод получения суммы переплат
            double sum = 0;
            foreach (Payment p in Payments) sum += p.Percents;
            return sum;
        }
    }
}
