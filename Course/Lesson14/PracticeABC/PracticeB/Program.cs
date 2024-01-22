﻿namespace practiceb;
using System.Net;
using System.IO;
using System;
using System.Text.Json;


class Program
{

    public static string GetRequest(string url)
    {
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream(); 
        StreamReader streamReader = new StreamReader(dataStream); 
        string jsonResponse = streamReader.ReadToEnd(); 

        streamReader.Close();  
        response.Close();  
        return jsonResponse;  
    }


    static void Main(string[] args)
    {
        string firstURL = "https://randomuser.me/api/"; 
        string jsonFromFirstURL = GetRequest(firstURL); 
        string firstgender = "";
        Console.WriteLine(jsonFromFirstURL);
        int count = 0;
        for (int i = 0; i < jsonFromFirstURL.Length; i++)
        {
            if (jsonFromFirstURL[i] == '"') count++;
            if (count == 5)
            {
                for (int j = i + 1; j < i + 10; j++)
                {
                    if (jsonFromFirstURL[j] == '"')
                    {
                        firstgender = jsonFromFirstURL.Substring(i, j - i + 1);
                        break;
                    }
                }
            }
        }
        Console.WriteLine(firstgender);
        
        //RandomPeople response = JsonSerializer.Deserialize<RandomPeople>(jsonFromFirstURL);
        //Console.WriteLine(response);
        
        //string firstname = response.results[0].name.first;
        //string firstgender = response.results[0].gender;
//
        //string secondURL = $"https://api.genderize.io/?name={firstname}"; 
        //string jsonFromSecondURL = GetRequest(secondURL); 
        //
        //GenderPeopleTrue response2 = JsonSerializer.Deserialize<GenderPeopleTrue>(jsonFromSecondURL);
//
        //string secondgender = response2.gender;
        //Console.WriteLine(secondgender);
//
        //if (firstgender == secondgender)
        //{
        //    Console.WriteLine("Да");
        //} else
        //{
        //    Console.WriteLine("Нет");
        //}


    }
}