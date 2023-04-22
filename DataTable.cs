// Test DataTable

using System;  
using System.Collections.Generic;  
using System.Data;  

public class DataTableForm 
{  
    public static void Main(String[] args)
    {
       DataTableForm.Page_Load();
    }
    void Page_Load()  
    {  
        DataTable table = new DataTable();  
        table.Columns.Add("ID");  
        table.Columns.Add("Name");  
        table.Columns.Add("Email");  
        table.Rows.Add("101", "Rameez","rameez@example.com");  
        table.Rows.Add("102", "Sam Nicolus", "sam@example.com");  
        table.Rows.Add("103", "Subramanium", "subramanium@example.com");  
        table.Rows.Add("104", "Ankur Kumar", "ankur@example.com");  
    }  
}  