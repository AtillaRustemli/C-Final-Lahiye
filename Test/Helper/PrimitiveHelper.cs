﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Helper
{
    public static partial class Helper
    {
        public static string ReadString(string caption,bool allowIsNullOrEmpty=false)
        {
            string income;
        l1:
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = oldColor;

            income=Console.ReadLine();

            if (allowIsNullOrEmpty == false && string.IsNullOrEmpty(income))
            {

                goto l1;
            }

            return income;
        }

        public static int ReadInt(string caption, int min=0,int max=0)
        {
            string income;
        l1:
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
           
            
            if(min==max&&max==0)
            {
                Console.WriteLine($"{caption}:"); 
            }
            else
            {
                Console.WriteLine($"{caption}  [{min},{max}]:");
            }
            
            Console.ForegroundColor = oldColor;
            income = Console.ReadLine();

            

            if (!int.TryParse(income,out int value)||(min!=0&&max!=0&&(value < min || value > max)))
            {

                goto l1;
            }

            return value;
        }
       
    }
}