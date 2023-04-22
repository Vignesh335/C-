using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Assembly myAssembly = Assembly.LoadFile(@"D:\Training\C#\Test1.dll");
        Type myType = myAssembly.GetType("MyLib1.Greeting");
        object myObject = Activator.CreateInstance(myType);
        myType.GetMethod("SayHello").Invoke(myObject, null);
        Console.ReadLine();
    }
}
