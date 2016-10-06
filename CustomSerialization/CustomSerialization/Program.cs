using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap; //not needed if using Binary formatter
//using System.Runtime.Serialization.Formatters.Binary;

public class CustomSerialization 
{
    public static void Main()  
    {
        CustomSerializedClass obj = new CustomSerializedClass();

        Console.WriteLine("\nBefore serialization the object contains: ");
        obj.DisplayMembers();

        // Open file and serialize object in binary format
        Stream stream = File.Open("DataFile.dat", FileMode.Create);
        SoapFormatter formatter = new SoapFormatter();

        try
        {
            formatter.Serialize(stream, obj);
            
            //Display the object again to see the effect of the 
            //OnSerializedAttribute
            Console.WriteLine("\nAfter serialization the object contains: ");
            obj.DisplayMembers();

            // Set the original variable to null
            obj = null;
            stream.Close();  

            // Open the file "DataFile.dat" and deserialize the object from it
            stream = File.Open("DataFile.dat", FileMode.Open);

            // Deserialize the object from the data file.
            obj = (CustomSerializedClass)formatter.Deserialize(stream);

            Console.WriteLine("\nAfter deserialization the object contains: ");
            obj.DisplayMembers();
        }
        catch (SerializationException se)
        {
            Console.WriteLine("Failed to serialize. Reason: " + se.Message);
            throw;
        }
        catch (Exception exc)
        {
            Console.WriteLine("An exception occurred. Reason: " + exc.Message);
            throw;
        }
        finally
        {
            stream.Close();
            obj = null;
            formatter = null;
        }
        Console.ReadLine();
    }
}

// Custom serialization without implementing ISerializable
[Serializable()]        
public class CustomSerializedClass  
{
    // serialized and deserialized with no change
    public int member1;

    // set and reset during and after serialization
    private string member2;

    // not serialized, OnDeserializedAttribute  used to set value after serialization
    [NonSerialized()] 
    public string member3; 

    // initially set to null but set after deserialization
    private string member4;

    // Constructor for the class.
    public CustomSerializedClass() 
    {
        member1 = 10;
        member2 = "Hello";
        member3 = "This is a nonserialized value";
        member4 = null;
    }

    public void DisplayMembers() 
    {
        Console.WriteLine("member1 = '{0}'", member1);
        Console.WriteLine("member2 = '{0}'", member2);
        Console.WriteLine("member3 = '{0}'", member3);
        Console.WriteLine("member4 = '{0}'", member4);
    }

    [OnSerializing()]
    internal void OnSerializingMethod(StreamingContext context)
    {
        member2 = "This string assigned to member2 in OnSerializing";
    }

    [OnSerialized()]
    internal void OnSerializedMethod(StreamingContext context)
    {
        member2 = "This string assigned to member2 in OnSerialized";
    }

    [OnDeserializing()]
    internal void OnDeserializingMethod(StreamingContext context)
    {
        member3 = "This string assigned to member3 in OnDeserializing";
    }

    [OnDeserialized()]
    internal void OnDeserializedMethod(StreamingContext context)
    {
        member4 = "This string assigned to member4 in OnDeserialized";
    }    
}
