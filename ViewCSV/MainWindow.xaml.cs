﻿using System;
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
                csv.Configuration.RegisterClassMap<CustomClassMap>();
                rowsList = csv.GetRecords<IDRow>().ToList();

                var lastrow = rowsList.Last<IDRow>();

                //     var Номер_на_карта = csv.GetField<string>("Номер на карта");
                //     var Презиме = csv.GetField<string>("Презиме");
                //     var boolField = csv.GetField<string>(2);
                //     this.Tname.Text = Номер_на_карта + Презиме + boolField;

                try {
                        this.Фамилия.Text = lastrow.Фамилия;
                        this.Име.Text = lastrow.Име;
                        this.Презиме.Text = lastrow.Презиме;
                        this.Националност.Text = lastrow.Националност;
                        this.Дата_на_раждане.Text = lastrow.Дата_на_раждане;
                        this.Валидност.Text = lastrow.Валидност;
                        this.Място_на_раждане.Text = lastrow.Място_на_раждане;
                        this.Област.Text = lastrow.Област;
                        this.Община.Text = lastrow.Община;
                        this.Адрес.Text = lastrow.Адрес;
                        this.Издаден_от.Text = lastrow.Издаден_от;
                        this.Издаден_на.Text = lastrow.Издаден_на;
                        this.Номер_на_карта.Text = lastrow.Номер_на_карта;
                        this.ЕГН.Text = lastrow.ЕГН;
                        
                    }
                    catch (CsvMissingFieldException c) { }

                
            }
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var lastrow = rowsList.Last<IDRow>();
            lastrow.Фамилия = Фамилия.Text;
            lastrow.Име = Име.Text;
            lastrow.Презиме = Презиме.Text;
            lastrow.Националност = Националност.Text;
            lastrow.Дата_на_раждане = Дата_на_раждане.Text;
            lastrow.Валидност = Валидност.Text;
            lastrow.Място_на_раждане = Място_на_раждане.Text;
            lastrow.Област = Област.Text;
            lastrow.Община = Община.Text;
            lastrow.Адрес = Адрес.Text;
            lastrow.Издаден_от = Издаден_от.Text;
            lastrow.Издаден_на = Издаден_на.Text;
            lastrow.Номер_на_карта = Номер_на_карта.Text;
            lastrow.ЕГН = ЕГН.Text;
            File.Copy(filename, filename + ".bak",true);
            using (var csv = new CsvWriter(new StreamWriter(filename)))
            {
                csv.Configuration.RegisterClassMap<CustomClassMap>();
                csv.Configuration.Delimiter = ",";
                csv.Configuration.HasHeaderRecord = true;
                csv.WriteRecords(rowsList.ToList());
            }

            Environment.Exit(1);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Община_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
