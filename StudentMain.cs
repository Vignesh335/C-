// Program on CRUD operations on Bank Domain

using System;
using System.IO;
using System.Reflection;
using NSiCRUD;

class cStudentMain
{
    public static void Main(string[] args)
    {
        string className;
        using (var reader = new StreamReader("ClassName.cfg"))
        {
            className = reader.ReadLine();
        }
        Assembly myAssembly = Assembly.LoadFile(@"D:\Training\C#\"+className+".dll");
        Type myType = myAssembly.GetType("NSClass." + className);
        object myObject = Activator.CreateInstance(myType);
        NSiCRUD.iCRUD oMySQLCRUD = (NSiCRUD.iCRUD)myObject;
        int choice;
        while (true)
        {
            Console.WriteLine("-----MENU-----\n1. Add Student\n2. Show Students\n3. Update Name of Student\n4. Remove Student\n5. Exit");
            Console.WriteLine("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    oMySQLCRUD.AddStudent();
                    break;
                case 2:
                    oMySQLCRUD.ShowStudents();
                    break;
                case 3:
                    oMySQLCRUD.UpdateStudent();
                    break;
                case 4:
                    oMySQLCRUD.DeleteStudent();
                    break;
                case 5:
                    oMySQLCRUD.Exit();
                    break;
                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }
}