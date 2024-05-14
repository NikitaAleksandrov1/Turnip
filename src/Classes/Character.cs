 public abstract class Character
    {
        public string Name { get; set; }
        private float Power { get; set; }

        public Character(string name, float power)
        {
            Name = name;
            Power = power;
        }

        public float Pull(Character human) {
            Console.WriteLine($"{Name} is pulling for {human.Name}.");
            return Power;
        }

        public void Call(Character character) {
            Console.WriteLine($"{Name} is calling for {character.Name}");
        }
        public float Pull(Fruit fruit)
        {
            Console.WriteLine($"{Name} is pulling {fruit.Name}.");
            return Power;
        }
    }