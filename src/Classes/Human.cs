class Human : Character, ICanPlant {
    public bool CanPlant { get; set; }
    public void Plant(Seed Plantable) {
        if (Plantable is IPlantable) {
            IPlantable plantable = (IPlantable)Plantable;
            Console.WriteLine($"{Name} planting the seed.");
            plantable.Plant();
        } else {
            Console.WriteLine("This item is not plantable.");
        }
    }

    public Human(string name, float power, bool canPlant) : base(name, power) {
        CanPlant = canPlant;
    }
}