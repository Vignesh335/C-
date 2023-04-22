// Temperature of a city using API

using System;
using System.Net;
using System.IO;

class CityTemperature
{
	public static void Main(String[] args)
	{
        Console.Write("Which city temperature do you want? ");
        string CityName = Console.ReadLine();
        string URL = "https://api.openweathermap.org/data/2.5/weather?q=" + CityName + "&appid=6e118f70895b47b898b7dbf17b053599&units=metric";
        WebRequest Request = HttpWebRequest.Create(URL);
        WebResponse Responce = Request.GetResponse();
        StreamReader Reader = new StreamReader(Responce.GetResponseStream());
        string WeatherReport = Reader.ReadLine().ToString();
        string[] tokens = WeatherReport.Split(',');
        foreach (var token in tokens)
        {
            string[] set = token.Split(':');
            foreach (var value in set)
            {
                if (value == "{\"temp\"")
                {
                    Console.WriteLine("Temperature of " + CityName + " is " + set[2]);
                }
            }
        }
    }
}