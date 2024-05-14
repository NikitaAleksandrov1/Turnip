class Human : Character {
    public bool CanPlant { get; set; }
    public void Plant(Fruit plantable) {
        Console.WriteLine($"{Name} planting the {plantable.Name}.");
    }

    public Human(string name, float power, bool canPlant) : base(name, power) {
        CanPlant = canPlant;
    }
}