//when this host starts up in non-debug mode, you must configure
//your firewall to allow connections to RemotingHost.exe or the
//client application will get a SocketException with the message:
//"No connection could be made because the target machine actively refused it"

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp; //needs ref to System.Runtime.Remoting.dll
//need ref to RemoteObject.dll

namespace MyRemoting
{
    public class RemotingHost
    {
        public static void Main(string[] args)
        {
            RemotingConfiguration.Configure(
                "RemotingHost.config", false);
/*
             TcpChannel chan = new TcpChannel(8123);
             ChannelServices.RegisterChannel(chan, false);
             Type remotingtype = Type.GetType(
                "MyRemoting.RemoteObject,RemoteObject");
             RemotingConfiguration.RegisterWellKnownServiceType(
                remotingtype, "RemotingHost.rem", WellKnownObjectMode.Singleton);
*/
            System.Console.WriteLine("Hit any key to exit...\n");
            System.Console.ReadLine();
        }
    }
}