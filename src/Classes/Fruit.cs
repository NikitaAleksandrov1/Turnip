public class Fruit {
    public float RequiredPowerToExtract {get; set; }
    public string Name { get; }

    public Fruit(float power, string name)
    {
        this.RequiredPowerToExtract = power;
        this.Name = name;
    }

    public bool IsExtractable(float power)
    {
        return power >= RequiredPowerToExtract;
    }

    public void Grow()
    {
        Console.WriteLine($"{Name} has grown.");
    }
}