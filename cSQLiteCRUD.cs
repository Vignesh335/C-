// class SQLite which connects to database and do mysql operations

using System;
using System.IO;
using System.Data.SQLite;
using NSiCRUD;
using System.Data;

namespace NSClass
{
	public class cSQLiteCRUD : NSiCRUD.iCRUD
	{
	    public SQLiteConnection dbConnection;
		public SQLiteCommand command;
	    public cSQLiteCRUD()
	    {
	    	try
			{
				SQLiteConnection dbConnection = new SQLiteConnection("Data Source=Students.db;");
				dbConnection.Open();
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
	    }

		private string ReadPin()
		{
			Console.WriteLine("Enter Pin: ");
			string Pin = Console.ReadLine();
			return Pin;
		}

		private string ReadName()
		{
			Console.WriteLine("Enter Name: ");
			string Name = Console.ReadLine();
			return Name;
		}

		private string ReadBranch()
		{
			Console.WriteLine("Enter Branch: ");
			string Branch = Console.ReadLine();
			return Branch;
		}

		private void DrawLine()
		{
		    Console.WriteLine("------------------------------------------------------------");
		}

		string TableName = "Students";
		public void AddStudent()
		{
			try
			{
				string Pin = ReadPin();
				string Name = ReadName();
				string Branch = ReadBranch();
	            string InsertQuery = "INSERT INTO " + TableName + "(Pin, Name, Branch) VALUES ('" + Pin + "','" + Name + "','" + Branch + "')";
				command = new SQLiteCommand(InsertQuery, dbConnection);
				command.ExecuteReader();
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public void ShowStudents()
		{
		    try
		    {
		        command = new SQLiteCommand("SELECT * FROM Students", dbConnection);
		        SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM Students", dbConnection);
		        DataTable table = new DataTable();
		        adapter.Fill(table);
		        foreach (DataRow row in table.Rows)
		        {
		        	Console.WriteLine("{0} {1} {2}", row[0], row[1], row[2]);
		        }
		    }
		    catch (Exception e)
		    {
		        Console.WriteLine(e);
		    }
		}

		public void UpdateStudent()
		{
			string Pin = ReadPin();
			string UpdatedName = ReadName();
			try
			{
				String UpdateQuery = "Update " + TableName + " SET Name = '" + UpdatedName + "' where Pin = '" + Pin +"'";
				command = new SQLiteCommand(UpdateQuery, dbConnection);
				command.ExecuteReader();
		    }
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public void DeleteStudent()
		{
			string Pin = ReadPin();
			try
			{
				String RemoveStudentQuery = "Delete from " + TableName + " where Pin = '" + Pin + "'";
				command = new SQLiteCommand(RemoveStudentQuery, dbConnection);
				command.ExecuteReader();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public void Exit()
		{
			try 
			{
				Console.WriteLine("Thank You!");
				dbConnection.Close();
				// exit();
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}