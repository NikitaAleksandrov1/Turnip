public class Item {
    public float RequiredPowerToExtract {get; set; }
    public string Name { get; }

    public Item(float power, string name)
    {
        this.RequiredPowerToExtract = power;
        this.Name = name;
    }

    public bool IsExtractable(float power)
    {
        return power >= RequiredPowerToExtract;
    }

    public void Plant()
    {
        Console.WriteLine("The seed has been planted.");
    }
}