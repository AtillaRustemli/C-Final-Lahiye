using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BookShop.Enums;

namespace BookShop.Helper
{
    public static partial class Helper
    {

        public static T ReadEnum<T>(string caption)
            where T : Enum
        {


            foreach (var item in Enum.GetValues(typeof(T)))
            {



                Type uType = Enum.GetUnderlyingType(typeof(T));

                var id = Convert.ChangeType(item, uType);

                Console.WriteLine($"{id.ToString().PadLeft(2, '0')}.{item}");
            }

            string income;
        l1:
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = oldColor;

            income = Console.ReadLine();

            if (!Enum.TryParse(typeof(T), income, out object value) || !Enum.IsDefined(typeof(T), value))
            {

                goto l1;
            }

            return (T)value;








        }


    }
}
