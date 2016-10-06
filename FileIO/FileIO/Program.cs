using System;
using System.Text;
using System.IO;

namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n*** General IO with File class ***\n");
            {
                string[] fileLines = { "Hello", "This is my text file", "Have a good day" };
                File.WriteAllLines("MyTextFile.txt", fileLines);
                string moreText = "I am writing this text to a file ...";
                File.AppendAllText("MyTextFile.txt", moreText);

                byte[] allBytes = File.ReadAllBytes("MyTextFile.txt");
                foreach (byte b in allBytes)
                {
                    Console.Write(b);
                }
                Console.Write("\n\n");

                string[] AllLines = File.ReadAllLines("MyTextFile.txt");
                foreach (string line in AllLines)
                {
                    Console.Write(line);
                    Console.Write("\n");
                }
                Console.Write("\n\n");

                string allText = File.ReadAllText("MyTextFile.txt");
                Console.Write(allText);
                Console.Write("\n\n");
            }

            Console.WriteLine("\n***Byte IO with BinaryWriter and BinaryReader classes ***\n");
            {
                byte[] bytes = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                FileStream fileStream = new FileStream("MyBinaryFile.bin", FileMode.Create);
                BinaryWriter writer = new BinaryWriter(fileStream);
                foreach (byte b in bytes)
                {
                    writer.Write(b);
                }
                writer.Close();
                fileStream.Close();
            }
            {
                FileStream fileStream = new FileStream("MyBinaryFile.bin", FileMode.Open);
                BinaryReader reader = new BinaryReader(fileStream);
                int position = 0;
                int length = (int)reader.BaseStream.Length;
                byte[] dataCollection = new byte[length];
                int returnedByte;
                while ((returnedByte = reader.Read()) != -1)
                {
                    dataCollection[position] = (byte)returnedByte;
                    position += sizeof(byte);
                }
                reader.Close();
                fileStream.Close();
                foreach (byte b in dataCollection)
                {
                    Console.Write(b);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n***CLR Data type IO with BinaryWriter and BinaryReader classes ***\n");
            {
                FileStream myDataStream = new FileStream("MyDataFile.dat", FileMode.Create);
                BinaryWriter writer = new BinaryWriter(myDataStream);
                bool boolValue = true;
                writer.Write(boolValue);
                byte byteValue = 42;
                writer.Write(byteValue);
                byte[] byteArrayValue = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                writer.Write(byteArrayValue);
                char charValue = 'a';
                writer.Write(charValue);
                writer.Close();
                myDataStream.Close();
            }
            {
                FileStream myDataStream = new FileStream("MyDataFile.dat", FileMode.Open);
                BinaryReader reader = new BinaryReader(myDataStream);
                bool boolValue = reader.ReadBoolean();
                Console.WriteLine(boolValue);
                byte byteValue = reader.ReadByte();
                Console.WriteLine(byteValue);
                byte[] byteArrayValue = reader.ReadBytes(10);
                foreach (byte b in byteArrayValue)
                {
                    Console.Write(b);
                }
                Console.WriteLine();
                char charValue = reader.ReadChar();
                Console.WriteLine(charValue);
                reader.Close();
                myDataStream.Close();
            }

            Console.WriteLine("\n***Text IO with StreamWriter and StreamReader classes ***\n");
            {
                FileStream fileStream = new FileStream("MyOtherTextFile.txt", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine("Hello, this will be written to the file");
                streamWriter.Close();
                fileStream.Close();
            }
            {
                FileStream fileStream = new FileStream("MyOtherTextFile.txt", FileMode.Open);
                StreamReader streamReader = new StreamReader(fileStream);
                StringBuilder fileContents = new StringBuilder();
                while (streamReader.Peek() != -1)
                {
                    fileContents.Append((char)streamReader.Read());
                }
                string data = fileContents.ToString();
                Console.WriteLine(data);
                streamReader.Close();
                fileStream.Close();
            }
        }
    }
}
