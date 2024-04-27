namespace DeliveryTreckAPI;
using System;
using System.ComponentModel.DataAnnotations;
public class Companion
{
    [StringLength(255)]
    public string Name { get; set; }
    public string Date { get; set; }
    public int Reward { get; set; }

    public Companion(string name, string date, int reward)
    {
        Name = name;
        Date = date;
        Reward = reward;
    }
    public Product() {}

}