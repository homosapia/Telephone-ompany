using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TelephoneСompany.Models
{
    public class CsvExporter
    {
        public void ExportToCsv(ObservableCollection<AbonentTableModel> abonents)
        {
            if (abonents == null || abonents.Count == 0)
            {
                MessageBox.Show("Коллекция не может быть null или пустой.");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                DefaultExt = ".csv"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csvBuilder = new StringBuilder();

                csvBuilder.AppendLine("ФИО,Улица,Дом,Домашный телефон,Рабочий телефон,Мобильный телефон");

                foreach (var abonent in abonents)
                {
                    csvBuilder.AppendLine($"{abonent.NameAbonent},{abonent.Street},{abonent.HouseNumber},{abonent.HomePhone},{abonent.WorkPhone},{abonent.MobilePhone}");
                }

                File.WriteAllText(saveDialog.FileName, csvBuilder.ToString(), Encoding.UTF8);
            }
        }
    }
}
