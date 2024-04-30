 public class Character: ICanPull
    {
        public string Name { get; set; }
        private float Power { get; set; }

        public Character(string name, float power)
        {
            Name = name;
            Power = power;
        }

        public float Pull()
        {
            Console.WriteLine($"{Name} is pulling.");
            return Power;
        }
    }