// class MySql which connects to database and do mysql operations

using System;
using System.IO;
using MySql.Data.MySqlClient;
using NSiCRUD;
using NSCRUD;

namespace NSMySQLCRUD
{
	public class cMySQLCRUD : NSCRUD.cCRUD, NSiCRUD.iCRUD
	{
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
	}
}