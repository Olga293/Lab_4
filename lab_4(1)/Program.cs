using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            var owner = new StringList.Owner("Olga Bryksa", 02072002, "BSTU", null);
            //DateTime date = DateTime.Now;
            Console.WriteLine($"Owener: {owner.name}\nPersonal ID: {owner.id}\nOrganization:  {owner.organization}\nDate: {owner.date}.");
            StringList list1 = new StringList();
            list1.Add("This");
            list1.Add("is");
            list1.Add("first");
            list1.Add("list");
            Console.WriteLine("\nList 1: ");
            list1.ListOut();

            StringList list2 = new StringList();
            list2.Add("This");
            list2.Add("is");
            list2.Add("DELETE ME");
            list2.Add("second");
            list2.Add("list");
            list2.Add(":)");
            Console.WriteLine("\nList 2: ");
            list2.ListOut();

            list2 = list2 >> 2;
            Console.WriteLine("\nElement 3 in list2 was deleted");
            list2.ListOut();

            Console.WriteLine(StatisticOperation.MaxElem(list2));
            Console.WriteLine(StatisticOperation.MinElem(list2));

            StatisticOperation.DelLast(list2);
            Console.WriteLine("\nLast element in list2 was deleted");
            list2.ListOut();

            StringList list3 = new StringList();
            list3.Add("And");
            list3.Add("this");
            list3.Add("is");
            list3.Add("third");
            list3.Add("list");
            Console.WriteLine();
            Console.WriteLine("List 3: ");
            list3.ListOut();

            list3 = list3 + 5;
            list3.ListOut();

            StringList list4 = new StringList();
            list4.Add("This");
            list4.Add("is");
            list4.Add("first");
            list4.Add("list");
            Console.WriteLine("\nList 4: ");
            list4.ListOut();

            Console.WriteLine("\nCompare lists 1 and 4:");
            Console.WriteLine(list1 != list4);
            Console.WriteLine(list1 == list4);

            Console.WriteLine("\nSize of list2: ");
            Console.WriteLine(StatisticOperation.Size(list2));

            Console.WriteLine("\nDifference between lenth of word in list2: ");
            Console.WriteLine(StatisticOperation.Difference(list2));
        }
    }
    public class StringList
    {
        List<string> list = new List<string>();
        public void Add(string value)
        {
            list.Add(value);
        }
        public void ListOut()
        {
            Console.WriteLine();
            foreach (string word in list)
            {
                Console.WriteLine(word);
            }
        }
        public void DeleteElem(int index)//удаление элемента в определенной позиции
        {
            list.RemoveAt(index);
        }
        public void AddElem(int index, string word)
        {
            list.Insert(index, word);
        }
        public static StringList operator >>(StringList list, int index)//удаление элемента в определенной позиции
        {
            list.DeleteElem(index);
            return list;
        }
        public string[] Array()
        {
            return list.ToArray();
        }
        public static StringList operator +(StringList list, int index)//добавление элемента в определенную позицию
        {
            Console.WriteLine("Enter word for insert: ");
            string word = Console.ReadLine();
            list.AddElem(index, word);
            return list;
        }
        public static bool operator ==(StringList list1, StringList list2)
        {
            string[] arr1 = list1.list.ToArray();
            string[] arr2 = list2.list.ToArray();
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] != arr2[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator !=(StringList list1, StringList list2)
        {
            string[] arr1 = list1.list.ToArray();
            string[] arr2 = list2.list.ToArray();
            if (arr1.Length != arr2.Length)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] != arr2[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public class Owner
        {
            public int id { get; set; }
            public string name { get; set; }
            public string organization { get; set; }
            public string date { get; set; }
            public Owner(string name, int id, string organization, string date)
            {
                this.name = name;
                this.id = id;
                this.organization = organization;
                this.date = Convert.ToString(DateTime.Now);
            }
        }
    }
    public static class StatisticOperation
    //1) Поиск самого длинного слова
    //2) Удаление последнего элемента
    {
        public static string MaxElem(StringList list)//Поиск самого длинного слова
        {
            string[] arr1 = list.Array();
            int max = 0;
            string str = "";
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i].Length > str.Length)
                {
                    max = arr1[i].Length;
                    str = arr1[i];
                }
            }
            return ("\nThe word with max length (" + str + ") has " + max + " letters");
        }
        public static string MinElem(StringList list1)//Поиск самого длинного слова
        {
            string[] arr1 = list1.Array();
            int min = 100;
            string str = "";
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i].Length < min)
                {
                    min = arr1[i].Length;
                    str = arr1[i];
                }
            }
            return ("\nThe word with min length (" + str + ") has " + min + " letters");
        }
        public static StringList DelLast(StringList list1)//Удаление последнего элемента
        {
            string[] arr1 = list1.Array();
            int last = arr1.Length - 1;
            list1.DeleteElem(last);
            return list1;
        }
        public static int Size(StringList list)
        {
            string[] arr1 = list.Array();
            int size = arr1.Length;
            return size;
        }
        public static int Difference(StringList list)
        {
            string[] arr1 = list.Array();
            int max = 0;
            string strmax = "";
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i].Length > strmax.Length)
                {
                    max = arr1[i].Length;
                    strmax = arr1[i];
                }
            }
            int min = 100;
            string strmin = "";
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i].Length < min)
                {
                    min = arr1[i].Length;
                    strmin = arr1[i];
                }
            }
            return (max - min);
        }
    }
}
