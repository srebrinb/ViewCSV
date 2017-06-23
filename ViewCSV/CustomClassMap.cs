using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewCSV
{
    public sealed class CustomClassMap : CsvClassMap<IDRow>
    {
        public CustomClassMap()
        {
            Map(m => m.Фамилия).Name("Фамилия");
            Map(m => m.Име).Name("Име");
            Map(m => m.Презиме).Name("Презиме");
            Map(m => m.Националност).Name("Националност");
            Map(m => m.Дата_на_раждане).Name("Дата на раждане");
            Map(m => m.Валидност).Name("Валидност");
            Map(m => m.Място_на_раждане).Name("Място на раждане");
            Map(m => m.Област).Name("Област");
            Map(m => m.Община).Name("Община");
            Map(m => m.Адрес).Name("Адрес");
            Map(m => m.Издаден_от).Name("Издаден от");
            Map(m => m.Издаден_на).Name("Издаден на");
            Map(m => m.Номер_на_карта).Name("Номер на карта");
            Map(m => m.ЕГН).Name("ЕГН");
        }

    }
}
