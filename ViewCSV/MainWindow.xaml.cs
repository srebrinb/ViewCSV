using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using CsvHelper;
using System.IO;

namespace ViewCSV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] LastRow;
        string filename;
        IEnumerable<IDRow> rowsList;
        public MainWindow()
        {
            IEnumerable<string> allValues;

            InitializeComponent();
            String[] arguments = Environment.GetCommandLineArgs();
            this.FileName.Content = String.Join(", ", arguments);
            filename = arguments[1];
            using (TextReader fileReader = File.OpenText(arguments[1]))
            {
                //                var csv = new CsvReader(fileReader);
                //csv.Configuration.HasHeaderRecord = false;
                //               allValues = csv.GetRecords<string>();
                //              this.Tname.Text =  allValues.get .First<string>();
               
               var csv = new CsvReader(fileReader);
                csv.Configuration.Delimiter = ",";
                csv.Configuration.HasHeaderRecord = true;
                var parser = new CsvParser(fileReader);
                parser.Configuration.Delimiter = ",";
                parser.Configuration.HasHeaderRecord = true;
                rowsList = csv.GetRecords<IDRow>();
                foreach(IDRow row in rowsList)                
                {
                    //     var Номер_на_карта = csv.GetField<string>("Номер на карта");
                    //     var Презиме = csv.GetField<string>("Презиме");
                    //     var boolField = csv.GetField<string>(2);
                    //     this.Tname.Text = Номер_на_карта + Презиме + boolField;
                    
                    try {
                        this.Фамилия.Text = row.Фамилия;
                        this.Име.Text = row.Име;
                        this.Презиме.Text = row.Презиме;
                        this.Националност.Text = row.Националност;
                        this.Дата_на_раждане.Text = row.ДатаНаРаждане;
                        this.Валидност.Text = row.Валидност;
                        this.Място_на_раждане.Text = row.Място_на_раждане;
                        this.Област.Text = row.Област;
                        this.Община.Text = row.Община;
                        this.Адрес.Text = row.Адрес;
                        this.Издаден_от.Text = row.Издаден_от;
                        this.Издаден_на.Text = row.Издаден_на;
                        this.Номер_на_карта.Text = row.Номер_на_карта;
                        this.ЕГН.Text = row.ЕГН;
                        
                    }
                    catch (CsvMissingFieldException c) { }

                }
            }
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            using (var csv = new CsvWriter(new StreamWriter(filename)))
            {
                csv.WriteRecords(LastRow);
            }

            Environment.Exit(1);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
