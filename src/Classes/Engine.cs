class Engine {
    private Fruit itemToExtract;
    private Character[] _characters;

    private Human _selectedGardener;

    public Engine(
        Fruit itemToExtract,
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
        itemToExtract.Grow();

        List<Character> activeCharacters = [];

        if (_characters.Length == 0)
        {
            Console.WriteLine("No characters to pull the item");
            return;
        }

        for (int i = 0; i < _characters.Length; i++)
        { 
            activeCharacters.Add(_characters[i]);
            bool result = TryToExtract(activeCharacters, itemToExtract);

            if (result) return;

            if (i + 1 == _characters.Length) {
                Console.WriteLine("THE END");
                return;
            }

            _characters[i].Call(_characters[i + 1]);
        }
    }

    private bool TryToExtract(List<Character> activeCharacters, Fruit itemToExtract)
    {
        float totalPower = 0;

        for (int i = activeCharacters.Count - 1; i >= 0; i--)
        {
           

            if (i == 0) {
                totalPower += activeCharacters[i].Pull(itemToExtract);
                 if (itemToExtract.IsExtractable(totalPower))
                {
                Console.WriteLine($"{itemToExtract.Name} has been extracted successfully");
                return true;
                }
                Console.WriteLine("Can't pull it");
                return false;
            }
                
            totalPower += activeCharacters[i].Pull(activeCharacters[i - 1]);
            
        }

        return false;
    }
}