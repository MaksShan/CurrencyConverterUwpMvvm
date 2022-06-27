using System;
using System.Collections.Generic;

namespace ConverterApp.Models
{
    class CurrencyModel
    {
        public class Currency
        {
            public string ID { get; set; }
            public string NumCode { get; set; }
            public string CharCode { get; set; }
            public int Nominal { get; set; }
            public string Name { get; set; }
            public decimal Value { get; set; }
            public decimal Previous { get; set; }

            public Currency(string charCode, string name, decimal value)
            {
                CharCode = charCode;
                Name=name;
                Value = value;
            }
        }
        public class Root
        {
            public DateTime Date { get; set; }
            public DateTime PreviousDate { get; set; }
            public string PreviousURL { get; set; }
            public DateTime Timestamp { get; set; }
            public Dictionary<string, Currency> Valute { get; set; }
        }
    }
}
