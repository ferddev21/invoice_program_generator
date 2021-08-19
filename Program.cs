using System;

namespace invoice_program
{
    class Program
    {
        // Todo
        //  1. FORMAT : INV/202108/TH/XIX/XXI/10983
        //  2. INV => STATIS
        //  3. 202108, 2021 Tahun sekarang; 08 Bulan Sekarang, (agustus 8 => 08, december 12 => 12)
        //  4. TH, Hari THURSDAY, 2 Karakter TH
        //  5. XIX, 19 Tanggal Romawi
        //  6. XXI, 2021, tahun belakang 21 Romawi
        //  7. 10983, counter

        static void Main(string[] args)
        {
            Console.Clear();

            int counter = 10982;
            string output = GenerateInvoice(counter);

            System.Console.WriteLine(output);  //INV/202108/TH/XIX/XXI/10983

        }

        static string GenerateInvoice(int counter)
        {
            DateTime tempDate = DateTime.Now;

            string segment1 = "INV";
            string segment2 = tempDate.ToString("yyyyMM"); //202108
            string segment3 = GetDayName(tempDate); //TH = Thursday
            string segment4 = GetRoman(Convert.ToInt32(tempDate.ToString("dd"))); //XIX = 19
            string segment5 = GetRoman(Convert.ToInt32(tempDate.ToString("yy"))); //XXI = 21
            string segment6 = Convert.ToString(counter + 1);

            //String interpolation;
            return ($"{segment1}/{segment2}/{segment3}/{segment4}/{segment5}/{segment6}");
        }

        static string GetDayName(DateTime tempDate)
        {
            var day = tempDate.ToString("dddd");
            var splitDay = day.Substring(0, 2); //Th
            var toUpperCase = splitDay.ToUpper(); //TH

            return Convert.ToString(toUpperCase);
        }

        static string GetRoman(int number)
        {
            int[] nums = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] rum = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            string value = "";
            for (int i = 0; i < nums.Length && number != 0; i++)
            {
                while (number >= nums[i])
                {
                    number -= nums[i];
                    value += rum[i];
                }
            }
            return value;
        }

    }
}
