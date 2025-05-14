using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ComputerStore
{
    public class NumberToWordsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is int))
                return null;

            int number = (int)value;
            string result = ConvertirNombreEnLettres(number);
            // التعامل مع الحالات الخاصة المتعلقة بالعملة
            if (number == 0) return result;
            else if (number == 1) return result + " dinar algérien";
            else return result + " dinars algériens";
            
        }
     
        static string[] ones = { "", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix",
                            "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf" };

        static string[] tens = { "", "", "vingt", "trente", "quarante", "cinquante", "soixante", "soixante", "quatre-vingt", "quatre-vingt" };

        static string ConvertirCentaines(int n)
        {
            if (n == 0) return "";
            else if (n < 20) return ones[n];
            else if (n < 100)
            {
             if (n < 70)   return tens[n / 10] + (n % 10 != 0 ? (n % 10 == 1 ? " et un" : "-" + ones[n % 10]) : "");
             else if (n >= 70 && n < 80)  return "soixante-" + ones[n - 60];
             else if (n >= 80 && n < 90)  return tens[n / 10] + (n % 10 != 0 ? "-" + ones[n % 10] : "");
             else if (n >= 90)  return tens[n / 10] + "-" + ones[n - 80];
            }
            else
            {
                if (n % 100 == 0) return (n / 100 > 1 ? ones[n / 100] + " cent" : "cent");
                else return (n / 100 > 1 ? ones[n / 100] + " cent " : "cent ") + ConvertirCentaines(n % 100);
            }
            return "";
        }

        static string ConvertirMille(int n)
        {
            if (n == 0) return "";
            else if (n == 1) return "mille";
            else return ConvertirCentaines(n) + " mille";
        }

        static string ConvertirMillion(int n)
        {
            if (n == 0) return "";
            else if (n == 1) return "un million";
            else return ConvertirCentaines(n) + " millions";
        }

        static string ConvertirMilliard(int n)
        {
            if (n == 0) return "";
            else if (n == 1) return "un milliard";
            else return ConvertirCentaines(n) + " milliards";
        }

        static string ConvertirNombreEnLettres(int nombre)
        {
            if (nombre == 0) return "zéro";

            int milliards = nombre / 1000000000;
            int millions = (nombre % 1000000000) / 1000000;
            int milliers = (nombre % 1000000) / 1000;
            int centaines = nombre % 1000;

            string resultat = "";

            if (milliards > 0) resultat += ConvertirMilliard(milliards) + " ";
            if (millions > 0) resultat += ConvertirMillion(millions) + " ";
            if (milliers > 0) resultat += ConvertirMille(milliers) + " ";
            if (centaines > 0 || (milliards == 0 && millions == 0 && milliers == 0)) resultat += ConvertirCentaines(centaines);

            return resultat.Trim();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
