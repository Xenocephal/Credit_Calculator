using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_Calc
{
    public class Export
    {
        public static void ExportCSV(ObservableCollection<Payment> Payments)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".csv";
            if (dlg.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(dlg.FileName, false, Encoding.UTF8))
                {
                    sw.WriteLine("Месяц;Платеж;Проценты;Остаток;Переплата;Тип платежа");
                    foreach (Payment p in Payments)
                    {
                        sw.WriteLine("{0};{1:F2};{2:F2};{3:F2};{4:F2};{5}",p.Month, p.Pay, p.Percents, p.Last, p.OverPay, p.PayType);
                    }
                };
            }
        }
        public static void ExportTXT(ObservableCollection<Payment> Payments)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".txt";
            if (dlg.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(dlg.FileName, false, Encoding.UTF8))
                {
                    sw.WriteLine("Месяц\tПлатеж\tПроценты\tОстаток\tПереплата\tТип платежа");
                    foreach (Payment p in Payments)
                    {
                        sw.WriteLine("{0}\t{1:F2}\t{2:F2}\t{3:F2}\t{4:F2}\t{5}", p.Month, p.Pay, p.Percents, p.Last, p.OverPay, p.PayType);
                    }
                };
            }
        }
        public static void ExportExcel(ObservableCollection<Payment> Payments)
        {
            // Создаём экземпляр нашего приложения
            Application excel = new Application();
            // Создаём экземпляр рабочий книги Excel
            Workbook book = excel.Workbooks.Add();
            // Создаём экземпляр листа Excel
            Worksheet sheet = (Worksheet)book.Worksheets.get_Item(1);

            sheet.Cells[1, 1] = "Месяц";
            sheet.Cells[1, 2] = "Платеж";
            sheet.Cells[1, 3] = "Проценты";
            sheet.Cells[1, 4] = "Остаток";
            sheet.Cells[1, 5] = "Переплата";
            sheet.Cells[1, 6] = "Тип платежа";

            for (int i = 0; i < Payments.Count; i++)
            {
                sheet.Cells[i + 2, 1] = Payments[i].Month;
                sheet.Cells[i + 2, 2] = String.Format("{0:F2}", Payments[i].Pay);
                sheet.Cells[i + 2, 3] = String.Format("{0:F2}", Payments[i].Percents);
                sheet.Cells[i + 2, 4] = String.Format("{0:F2}", Payments[i].Last);
                sheet.Cells[i + 2, 5] = String.Format("{0:F2}", Payments[i].OverPay);
                sheet.Cells[i + 2, 6] = Payments[i].PayType;
            }

            Range range = sheet.UsedRange;
            range.Cells.Font.Name = "Century Gothic";
            range.Cells.Font.Size = 10;

            range.VerticalAlignment = XlVAlign.xlVAlignCenter;
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            range.ColumnWidth = 12;
            range.Cells.Calculate();

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".xlsx";
            if (dlg.ShowDialog()==true)
            {
                book.SaveAs(dlg.FileName);                
            }
            book.Close();
        }
    }
}
