class Engine {
    private Item itemToExtract;
    private Character[] _characters;

    private Human _selectedGardener;

    public Engine(
        Item itemToExtract,
        Character[] characters,
        Human selectedGardener
    )
    {
        this.itemToExtract = itemToExtract;
        this._characters = characters;
        this._selectedGardener = selectedGardener;
    }

    public void Execute()
    {   
        _selectedGardener.Plant(itemToExtract);

        float totalPower = 0;

        for (int i = 0; i < _characters.Length; i++)
        {
            totalPower += _characters[i].Pull();


            string[] previousCharacters = [];

            for (int j = 0; j <= i; j++)
            {
                previousCharacters = previousCharacters.Concat(new[] { _characters[j].Name
                    }).ToArray();
            }
            string result = string.Join(" pulling for ", previousCharacters);
            Console.Write($"{result} are pulling {itemToExtract.Name} from the ground");

            if (itemToExtract.IsExtractable(totalPower) == false)
            {
                Console.WriteLine("\nCan't pull it");
            }
            else
            {
                Console.WriteLine($"\n{itemToExtract.Name} has been extracted successfully");
                return;
            }
        }
    }
}