namespace Credit_Calc
{
    // Тип досрочного погашения
    public enum OverPayType { Time, Amount, None };

    public class Payment
    {
        // Номер месяца
        public int MonthNum { get; set; } = 0;

        // Сумма платежа, руб
        private double pay;
        public double Pay
        {
            get { return pay; }
            set
            {
                if (value >= 0) pay = value;
                else pay = 0;
            }
        }

        // Сумма по процентам в платеже, руб
        private double percents;
        public double Percents
        {
            get { return percents; }
            set
            {
                if (value >= 0) percents = value;
                else percents = 0;
            }
        }

        // Остаток по кредиту
        private double last;
        public double Last
        {
            get { return last; }
            set
            {
                if (value >= 0) last = value;
                else last = 0;
            }
        }

        // Сумма досрочного погашения
        private double overPay = 0;
        public double OverPay
        {
            get { return overPay; }
            set
            {
                if (value >= 0 & value <= Last) overPay = value;
                else if (value > Last) overPay = Last;
            }
        }

        // Тип досрочного погашения
        public OverPayType PayType { get; set; } = OverPayType.None;
    }
}
