/* Класс, заполняющий файл учениками вида: Фамилия - [A-Z][a-z]{2,9}
 *                                         Имя  - [A-Z][a-z]{2,9}
 *                                         Департамент - [A-Z][a-z]{6,12}
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMatveevLesson5
{
    static class MegaGenerator
    {
        static Random random = new Random();
        static string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static string GetEmployeeName()
        {
            string str;

            str = StrGenerator(1, random);
            str = str + StrGenerator(random.Next(2, 9), random);
            return str;
        }

        public static string GetEmployeeLastname()
        {
            string str;

            str = StrGenerator(1, random);
            str = str + StrGenerator(random.Next(2, 9), random);
            return str;
        }

        public static string GetDepartamentName()
        {
            string str;

            str = StrGenerator(1, random);
            str = str + StrGenerator(random.Next(6, 12), random);
            return str;
        }

        private static string StrGenerator(int length, Random random)
        {
            
            StringBuilder result = new StringBuilder(length);
            if (length == 1)
            {
                characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                result.Append(characters[random.Next(characters.Length)]);

            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    characters = "abcdefghijklmnopqrstuvwxyz";
                    result.Append(characters[random.Next(characters.Length)]);
                }
            }
            return result.ToString();
        }

    }
}