class Human : Character {
    public bool CanPlant { get; set; }
    public void Plant(Item Plantable) {
        Console.WriteLine($"{Name} planting the seed.");
        Plantable.Plant();
    }

    public Human(string name, float power, bool canPlant) : base(name, power) {
        CanPlant = canPlant;
    }
}