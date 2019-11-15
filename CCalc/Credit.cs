using System;
using System.Collections.Generic;

namespace Credit_Calc
{
    public class Credit
    {
        // Стоимость кредита
        private double cost = 0;
        public double Cost
        {
            get { return cost; }
            set { if (value >= 0) cost = value; }
        }

        // Процентная ставка    
        private double rate = 0;
        public double Rate
        {
            get { return rate; }
            set { if (value >= 0) rate = value; }
        }

        // Срок погашения   
        private int period = 0;
        public int Period
        {
            get { return period; }
            set { if (value >= 0) period = value; }
        }

        // Начальная сумма платежа
        public double StartPay { get { return GetPay(Cost, Rate / 12, Period); } }

        // Полная стоимость кредита
        public double FullCost { get { return StartPay * Period; } }

        // Переплата по кредиту
        public double Overpayment { get { return FullCost - Cost; } }

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

        // Начальный лист платежей по кредиту
        public List<Payment> Payments()
        {
            double P, P1, Sn;

            Sn = Cost;

            // Объявляем массив платежей
            List<Payment> payments = new List<Payment>();

            for (int i = 0; i < Period; i++)
            {
                P = GetPay(Sn, Rate / 12, Period - i);
                P1 = GetPercentPay(Sn, Rate / 12);
                Sn = GetLast(Sn, P, P1);

                Payment p = new Payment { MonthNum = i+1, Pay = P, Percents = P1, Last = Sn };
                payments.Add(p);
            }

            return payments;
        }
        public List<Payment> Payments(List<Payment> pays)
        {
            double P, P1, Sn;
            Sn = Cost;
            P = GetPay(Sn, Rate / 12, Period);
            P1 = GetPercentPay(Sn, Rate / 12);
            Sn = GetLast(Sn, P, P1);

            for (int i = 0; i < pays.Count; i++)
            {
                pays[i].Pay = P;
                pays[i].Percents = P1;
                pays[i].Last = Sn;

                if (pays[i].OverPay > 0) { Sn = Sn - pays[i].OverPay; }
                if (pays[i].PayType == OverPayType.Amount) P = GetPay(Sn, Rate / 12, Period - i - 1);

                P1 = GetPercentPay(Sn, Rate / 12);

                if (P >= Sn + P1) P = P1 + Sn;
                else if (Sn == 0) { P = 0; P1 = 0; }

                Sn = GetLast(Sn, P, P1);
            }
            return pays;
        }

        public static double GetFullCost(List<Payment> paylist)
        {
            double sum = 0;
            foreach (Payment p in paylist) sum += p.Pay + p.OverPay;
            return sum;
        }

        public static double GetOverpayment(List<Payment> paylist)
        {
            double sum = 0;
            foreach (Payment p in paylist) sum += p.Percents;
            return sum;
        }
    }
}
