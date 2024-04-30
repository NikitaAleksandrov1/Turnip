public class Seed : IExtractable, IPlantable
{
    private int requiredPowerToExtract;
    public string Name { get; }

    public Seed(int power, string name)
    {
        this.requiredPowerToExtract = power;
        this.Name = name;
    }

    public bool IsExtractable(float power)
    {
        return power >= requiredPowerToExtract;
    }

    public void Plant()
    {
        Console.WriteLine("The seed has been planted.");
    }
}