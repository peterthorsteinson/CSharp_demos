using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp; //needs ref to System.Runtime.Remoting.dll
using System.Net.Sockets; //just for the SocketException class
//needs to add a ref to RemoteObject.dll

namespace MyRemoting
{
    public class RemotingClient
    {
        public static void Main(string[] args)
        {
            RemotingConfiguration.Configure(
                "RemotingClient.config", false);

            RemoteObject obj = new MyRemoting.RemoteObject();
/*
            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel, false);
            RemoteObject obj = (RemoteObject)Activator.GetObject(
                typeof(MyRemoting.RemoteObject),
                "tcp://localhost:8123/RemotingHost/RemoteObjectSingleton.rem");
 */ 
            if (obj == null)
            {
                System.Console.WriteLine("Error: could not access remote server!");
                return;
            }
            try
            {
                Console.WriteLine(obj.Method1("Hello"));

                MySerializableClass msc = new MySerializableClass();
                msc.x = 10;
                msc.y = 20;
                Console.WriteLine(obj.Method2(msc));
            }
            catch (SocketException e)
            {
                System.Console.WriteLine(e.Message);
            }

            System.Console.WriteLine("\nHit any key to exit...");
            Console.ReadLine();
        }
    }
}