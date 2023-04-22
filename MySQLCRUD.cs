// class MySql which connects to database and do mysql operations

using NSiCRUD;
using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace cMySQLCRUD
{
	public class cMySQLCRUD : NSiCRUD.iCRUD
	{
		MySqlConnection dbConnection;
		MySqlCommand command;
		MySqlDataReader reader;

	    public cMySQLCRUD()
	    {
	    	try
			{
				dbConnection = new MySqlConnection("server=138.68.140.83;user id=Vignesh;password=Vignesh@143;database=dbVignesh");
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
				command = new MySqlCommand(InsertQuery, dbConnection);
				reader = command.ExecuteReader();
				reader.Close();
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
				command = new MySqlCommand("SELECT * FROM Students", dbConnection);
				reader = command.ExecuteReader();
				while (reader.Read())
		        {
		            string id = reader.GetString("Pin");
		            string name = reader.GetString("Name");
		            string age = reader.GetString("Branch");
		            Console.WriteLine("ID: {0}, Name: {1}, Age: {2}", id, name, age);
		        }
		        reader.Close();
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
				command = new MySqlCommand(UpdateQuery, dbConnection);
				reader = command.ExecuteReader();
				reader.Close();
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
				command = new MySqlCommand(RemoveStudentQuery, dbConnection);
				reader = command.ExecuteReader();
				reader.Close();
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
				Exit();
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}