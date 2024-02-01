﻿using System.Text;
using System.Text.Json;

namespace Client;

[System.Serializable] public class User
{
    public string Login { get; set; }
    public string Password { get; set; }
    public bool IsAuthorized { get; set; }
    public User(){}
    public User(string Login, string Password)
    {
        this.Login = Login;
        this.Password = Password;
        this.IsAuthorized = false;
    }

    public void CreateDBUser()
    {
        string url = "http://localhost:5087/store/add_user";
        var user_to_send = new 
        {
            login = this.Login,
            Password = this.Password,
            IsAuthorized = false
        };
        var client = new HttpClient();
        var json = JsonSerializer.Serialize(user_to_send);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = client.PostAsync(url, content).Result;
        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(responseContent);
        }
        else{
            Console.WriteLine($"Error: {response.StatusCode}");
        }

    }
    public void Logining(string login, string password)
    {
        string url = "http://localhost:5087/store/logining_user";
        var user_to_send = new 
        {
            Login = login,
            Password = password
        };
        var client = new HttpClient();
        var json = JsonSerializer.Serialize(user_to_send);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = client.PostAsync(url, content).Result;
        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;
            this.IsAuthorized = true;
            Console.WriteLine(responseContent);
        }
        else{
            Console.WriteLine($"Error: {response.StatusCode}; {response.Content.ReadAsStringAsync().Result}");
        }
    }

}

class Program
{
    static void Main(string[] args)
    { 
        User user1 = new User("Petya", "012");
        user1.CreateDBUser();
        user1.Logining("Petya", "011");
        user1.Logining("Petya", "012");
    }
}
