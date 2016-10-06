using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp; //needs ref to System.Runtime.Remoting.dll

namespace MyRemoting
{
    public class RemoteObject : MarshalByRefObject
    {
        public RemoteObject()
        {
            Console.WriteLine("RemoteObject constructed");
        }
        public String Method1(String strParam)
        {
            Console.WriteLine("RemoteObject.Method1({0}) called", strParam);
            return "RemoteObject.Method1 returned " + strParam;
        }
        public String Method2(MySerializableClass msc)
        {
            Console.WriteLine("RemoteObject.Method2({0}) called", msc);
            return "RemoteObject.Method2 returned " + msc;
        }
    }

    [Serializable()]
    public class MySerializableClass
    {
        public int x;
        public int y;
        public override String ToString() //just for display purposes
        {
            return String.Format("SerializableClass x={0} y={1}", x, y);
        }
    }
}