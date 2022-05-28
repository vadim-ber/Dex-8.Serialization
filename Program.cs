using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Dex_8.Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Example[] ex = new Example[3];

            
            //Бинарная сериализация
            string pathToFile1 = @"C:\exampledata.txt";

            for(int i = 0; i < 3; i++)
            {
                ex[i] = new Example("Пример" + i, "Пример" + i*i);
            }

            BinaryFormatter bf = new BinaryFormatter();
            using(FileStream fs = new FileStream(pathToFile1, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, ex);
            }

            Example[] deserializeExample1;
            using(FileStream fs = new FileStream(pathToFile1, FileMode.OpenOrCreate))
            {
                deserializeExample1 = (Example[])bf.Deserialize(fs);
            }

            foreach(Example e in deserializeExample1)
            {
                Console.WriteLine(" Строка 1: {0} Строка 2: {1} Дата: {2} Obj: {3}", e.exampleString1, e.exampleString2, e.exampleTime, e.obj);
            }

            
        }
    }

    [Serializable]
    public class Example
    {
        public string exampleString1 { get; set; }
        public string exampleString2 { get; set; }
        public DateTime exampleTime { get; set; }

        public Object obj = 3;

        //public Example ex = new Example("dewr", "wweq"); Stack Overflow

        public Example(string a, string b)
        {
            exampleString1 = a;
            exampleString2 = b;
            exampleTime = DateTime.Today;            
        }
    }
}
