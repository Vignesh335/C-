// Create 2 classes and call a function of a class in another class to convert it into .exe file

using System;

class cGreeting1
{
	public static void Main(String[] args)
	{
		Console.WriteLine("Hi friends!");
		cGreeting2 oGreeting2 = new cGreeting2();
		oGreeting2.SayHello();
	}
}

class cGreeting2
{
	public void SayHello()
	{
		Console.WriteLine("Hello friends!");
	}
}