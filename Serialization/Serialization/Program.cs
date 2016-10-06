using System;
using System.Collections; //.Generic
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap; //needs ref to System.Runtime.Serialization.Formatters.Soap

namespace MySerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            MySerializableClass msc = new MySerializableClass();
            msc.name = "Galileo Galilei";
            msc.id = 10;
            list.Add(msc);
            msc = new MySerializableClass();
            msc.name = "Isaac Newton";
            msc.id = 20;
            list.Add(msc);

            foreach (MySerializableClass y in list)
                Console.WriteLine(y.name + ": " + y.id);

            Console.WriteLine("Saving ArrayList");
            FileStream s = new FileStream(
                "MySerializableClass.txt", FileMode.Create);
            SoapFormatter f = new SoapFormatter();
            SaveFile(f, s, list);

            Console.WriteLine("Restoring ArrayList");
            s = new FileStream(
                "MySerializableClass.txt", FileMode.Open);
            f = new SoapFormatter();
            ArrayList list2 = (ArrayList)RestoreFile(f, s);
            foreach (MySerializableClass y in list2)
                Console.WriteLine(y.name + ": " + y.id);
        }
        public static void SaveFile(IFormatter f, Stream s, IList l)
        {
            f.Serialize(s, l);
            s.Close();
        }
        public static IList RestoreFile(IFormatter f, Stream s)
        {
            IList l = (IList)f.Deserialize(s);
            s.Close();
            return l;
        }
    }
    [Serializable]
    class MySerializableClass
    {
        public string name;
        public long id;
    }
}
