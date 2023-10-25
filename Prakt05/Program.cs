using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Prakt05
{
    class Menu
    {

        static void ShowArrow(int position,int shiftY)
        {
            Console.SetCursorPosition(0, position +shiftY);
            Console.WriteLine("->");
        }

 
        static public void ShowMenu1()
        {
            int position = 0;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();

                Console.WriteLine("");
                Console.WriteLine("Выберите пункт меню");
                Console.WriteLine("----------------------");

                for (int i = 0; i < Data.properList.Count; i++)
                    Console.WriteLine("   " + Data.properList[i].GetName());
                Console.WriteLine("Цена:" + Data.resultPrice);
                Console.WriteLine(Data.resultString);
                ShowArrow(position, 3);

                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (position > 0)
                        position--;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (position < Data.properList.Count - 1)
                        position++;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    
                    ShowMenu2(position);
                }
                if (key.Key == ConsoleKey.Escape)
                    break;
            }
            while (true);
            Console.WriteLine("Good bye!");
        }

        static public void ShowMenu2(int propN)
        {
            int position = 0;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в кондитерскую");
                Console.WriteLine("Выберите пункт меню для заказа");
                Console.WriteLine("----------------------");

                for (int i = 0; i < Data.properList[propN].GetPropers().Count; i++)
                Console.WriteLine("   " + Data.properList[propN].GetPropers()[i]);
                Console.WriteLine("Цена:"+Data.resultPrice);
                Console.WriteLine(Data.resultString);
                ShowArrow(position, 3);

                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (position > 0)
                        position--;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (position < Data.properList[propN].GetPropers().Count - 1)
                        position++;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Data.resultString += Data.properList[propN].GetPropers()[position].ToString()+";";
                    Data.resultPrice += Data.properList[propN].GetPropers()[position].GetPrice();
                }
                if (key.Key == ConsoleKey.Escape)
                    return;                
            }
            while (true);
            
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string yn = "";
            Data.Init();
            do
            {
                Data.resultPrice = 0;
                Data.resultString = "";
                Menu.ShowMenu1();
                Console.Clear();
                string text = "Заказ от <" + DateTime.Now.ToShortDateString() + ">\nЗаказ:<" + Data.resultString + ">\nЦена:<" + Data.resultPrice + ">";
                Console.WriteLine(text);
                System.IO.File.AppendAllText("zakaz.txt", text);
                Console.WriteLine("Data saved");
                Console.WriteLine("Сделать еще один заказ(Yes,No)?");
                yn=Console.ReadLine();

            }
            while (Char.ToLower(yn[0]) == 'y');

            
        }
    }
}
