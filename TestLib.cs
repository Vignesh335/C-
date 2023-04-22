// Test dll

using System;
using MyLib;

class cTestdll
{
	public static void Main(String[] args)
	{
		MyLib.cGreeting oGreeting = new MyLib.cGreeting();
		oGreeting.SayHi();
	}
}