using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS_Plus.Classes.Editors
{
    internal class numbersToStrings
    {
        public numbersToStrings(decimal sum)
        {
            this.sum = sum;
            Propisi();
        }
        
        static Dictionary<int, string> monthNames = new Dictionary<int, string>
        {
            {1,"января" },
            {2,"февраля" },
            {3,"марта" },
            {4,"апреля" },
            {5,"мая" },
            {6,"июня" },
            {7,"июля" },
            {8,"августа" },
            {9,"сентября" },
            {10,"октября" },
            {11,"ноября" },
            {12,"декабря" }
        };

        private static readonly string[] units = { "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
        private static readonly string[] teens = { "", "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
        private static readonly string[] tens = { "", "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
        private static readonly string[] hundreds = { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
        private static readonly string[] thousands = { "", "тысяча", "тысячи", "тысяч" };
        private static readonly string[] millions = { "", "миллион", "миллиона", "миллионов" };


        private decimal sum;
        public decimal Sum {  get { return sum; } set { sum = value; } }

        private string propis;
        public string Propis { get { return propis; }}
        
        public void Propisi()
        {
            propis = ToWords(sum);
        }

public static string ToWords(decimal number)
        {
            if (number < 0 || number >= 100000000m)
            {
                return "Число вне допустимого диапазона (0 - 999999,99)";
            }

            int rubles = (int)number;
            int kopecks = (int)((number - rubles) * 100);

            string rublesWords = ConvertToWords(rubles);
            string kopecksWords = ConvertToWords(kopecks);


            string result = rublesWords;
            if (!string.IsNullOrEmpty(kopecksWords))
            {
                result += " рублей " + kopecksWords + " копеек";
            }
            else
            {
                result += " рублей";
            }

            return result;
        }
        private static string ConvertToWords(int number)
        {
            if (number == 0) return "ноль";
            if (number < 0) return "отрицательное число";


            string words = "";

            if (number >= 1000000)
            {
                words += ConvertToWords(number / 1000000) + " " + GetMillionEnding(number / 1000000) + " ";
                number %= 1000000;
            }
            if (number >= 1000)
            {
                words += ConvertToWords(number / 1000) + " " + GetThousandEnding(number / 1000) + " ";
                number %= 1000;
            }
            if (number >= 100)
            {
                words += hundreds[number / 100] + " ";
                number %= 100;
            }
            if (number >= 20)
            {
                words += tens[number / 10] + " ";
                number %= 10;
            }
            else if (number >= 10)
            {
                words += teens[number - 9] + " ";
                number = 0;
            }
            if (number > 0)
            {
                words += units[number] + " ";
            }

            return words.Trim();
        }
        private static string GetThousandEnding(int number)
        {
            int lastDigit = number % 10;
            int lastTwoDigits = number % 100;

            if (lastDigit == 1 && lastTwoDigits != 11) return thousands[1];
            if (lastDigit >= 2 && lastDigit <= 4 && (lastTwoDigits < 10 || lastTwoDigits > 20)) return thousands[2];
            return thousands[3];
        }
        private static string GetMillionEnding(int number)
        {
            int lastDigit = number % 10;
            int lastTwoDigits = number % 100;

            if (lastDigit == 1 && lastTwoDigits != 11) return millions[1];
            if (lastDigit >= 2 && lastDigit <= 4 && (lastTwoDigits < 10 || lastTwoDigits > 20)) return millions[2];
            return millions[3];
        }
    }
}
