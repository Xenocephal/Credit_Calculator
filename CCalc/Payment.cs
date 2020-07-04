using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Credit_Calc {
    // Тип досрочного погашения
    public enum OverPayType { Time, Amount, None };

    public class Payment : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        // Номер месяца
        private int month;
        public int Month {
            get => month;
            set {
                month = value;
                OnPropertyChanged("Month");
            }
        }

        // Сумма платежа, руб
        private double pay;
        public double Pay {
            get { return pay; }
            set {
                if (value >= 0) pay = value;
                else pay = 0;
                OnPropertyChanged("Pay");
            }
        }

        // Сумма по процентам в платеже, руб
        private double percents;
        public double Percents {
            get { return percents; }
            set {
                if (value >= 0) percents = value;
                else percents = 0;
                OnPropertyChanged("Percents");
            }
        }

        // Остаток по кредиту
        private double last;
        public double Last {
            get { return last; }
            set {
                if (value >= 0) last = value;
                else last = 0;
                OnPropertyChanged("Last");
            }
        }

        // Сумма досрочного погашения
        private double overPay = 0;
        public double OverPay {
            get { return overPay; }
            set {
                if (value >= 0 & value <= Last) overPay = value;
                else if (value > Last) overPay = Last;
                OnPropertyChanged("OverPay");
            }
        }

        // Тип досрочного погашения
        private OverPayType payType = OverPayType.None;
        public OverPayType PayType {
            get => payType;
            set {
                if (Last == 0) payType = OverPayType.None;
                else payType = value;
                OnPropertyChanged("PayType");
            }
        }
    }
}
