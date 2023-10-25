using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prakt05
{
    class Proper
    {
        //член класса
        private string text;
        private int price;

        //конструктор
        public Proper(string _text, int _price)
        {
            text = _text;
            if (_price < 0) {
                throw new ArgumentOutOfRangeException("У свойства не может быть отрицательной цены");
            }
            price = _price;
        }

        //Методы Get
        public string GetText()
        {
            return text;
        }

        public int GetPrice()
        {
            return price;
        }

        public override string ToString()
        {
            return text + " " + price; 
        }


    }

    class ProperList 
    {
        string name;
        private List<Proper> list;

        public ProperList(string _name, List<Proper> propers)
        {
            name = _name;
            list = propers;
        }

        //интерфейс взаимодействия с классом
        public List<Proper> GetPropers()
        {
            return list;
        }

        public string GetName()
        {
            return name;
        }
    }

    internal class Data
    {
        static public string resultString="";
        static public int resultPrice=0;

        static public List<ProperList> properList;
        static public void Init()
        {
            ProperList properList0 = new ProperList("Форма торта", new List<Proper>() { new Proper("Круг", 500),
                                                                   new Proper("Квадрат", 500),
                                                                   new Proper("Прямоугольник", 500),
                                                                   new Proper("Сердечко", 500)});
            ProperList properList1 = new ProperList("Размер торта", new List<Proper>() { new Proper("маленький", 500),
                                                                    new Proper("средний", 1000),
                                                                    new Proper("большой", 2000),
                                                                    new Proper("особый", 5000)});
            ProperList properList2 = new ProperList("Вкус коржей", new List<Proper>() { new Proper("ванильный", 300),
                                                                    new Proper("шоколадный", 400),
                                                                    new Proper("карамельный", 400),
                                                                    new Proper("ягодный", 500)});
            ProperList properList3 = new ProperList("Количество коржей", new List<Proper>() { new Proper("1 корж", 200),
                                                                    new Proper("2 коржа", 400),
                                                                    new Proper("3 коржа", 600),
                                                                    new Proper("4 коржа", 800)});
            ProperList properList4 = new ProperList("Глазурь", new List<Proper>() { new Proper("шоколад", 100),
                                                                    new Proper("крем", 200),
                                                                    new Proper("драже", 150),
                                                                    new Proper("ягоды", 400)});
            ProperList properList5 = new ProperList("Декор", new List<Proper>() { new Proper("шоколадная", 300),
                                                                    new Proper("ягодная", 600),
                                                                    new Proper("кремовая", 400),
                                                                    new Proper("карамельная", 500)});
            properList = new List<ProperList>();
            properList.Add(properList0);
            properList.Add(properList1);
            properList.Add(properList2);
            properList.Add(properList3);
            properList.Add(properList4);
            properList.Add(properList5);
        }

    }
}
