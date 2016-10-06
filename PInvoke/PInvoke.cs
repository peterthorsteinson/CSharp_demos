//PInvoke.cs

using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

public class Test
{
	[DllImport("kernel32.dll", CharSet=CharSet.Ansi)]
	public static extern bool GetComputerName(StringBuilder name, out uint buffer);
	[DllImport("kernel32.dll")]
	public static extern uint GetLastError();

	public static int Main(string[] args)
	{
		bool result = true;
		uint error = 0;
		StringBuilder name = new StringBuilder(128);
		uint length = 128;
		Console.WriteLine(
			"Attempting to call GetComputerName");
		result = GetComputerName(name, out length);

		if (result == true)
			Console.WriteLine(
				"GetComputerName returned: " + 
				name);
		else
		{
			error = GetLastError();
			Console.WriteLine(
				"Error! GetComputerName  returned: " + 
				error);
		}

		Console.Write("Press Enter to exit...");
		Console.Read();
		return 0;
	}
}
