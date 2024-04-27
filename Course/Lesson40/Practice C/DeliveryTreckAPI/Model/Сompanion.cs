namespace DeliveryTreckAPI;
public class Companion
{
    [StringLength(255)]
    public string Name { get; set; }
    public string Date { get; set; }
    public string Reward { get; set; }

    public Companion(string name, string date, string reward)
    {
        Name = name;
        Date = date;
        Reward = reward;
    }
    public Product() {}

}