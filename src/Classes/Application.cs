public class Application
{
    private Config _config;
    private Selector _selector;

    private Fruit itemToExtract = null;
    private Character[] _characters = null;

    private Human _selectedGardener;


    public Application(Config config, Selector selector)
    {
        _config = config;
        _selector = selector;
    }

    

    private (Fruit, Character[], Human) GetUserInputs()
    {   
        Human selectedGardener = null;
        Fruit itemToExtract = null;
        _characters = _config.Characters.ToArray();

        Human[] _gardeners = Array.FindAll(_config.Characters, character => character is Human).Cast<Human>().ToArray();       

        if (_gardeners.Length == 0)
        {
           Console.WriteLine("Please set CanPlant to true for one of the characters in the config file.");
           return (null, null, null);
        }

        _selector.DisplaySelectOptions("Choose gardener:", _gardeners.Select(gardener =>
        (gardener.Name, (Action)(() => { selectedGardener = gardener; })
        )).ToArray());

        _selector.DisplaySelectOptions("Choose item to extract:", _config.Items.Select(item =>
        (item.Name, (Action)(() => { itemToExtract = new Fruit(item.RequiredPowerToExtract, item.Name); })
        )).ToArray());

        return (itemToExtract, _characters, selectedGardener);
    }

    public void Run()
    {
        (itemToExtract, _characters, _selectedGardener) = GetUserInputs();

        if (itemToExtract == null || _characters == null || _selectedGardener == null)
        {
            return;
        }

        Engine engine = new Engine(itemToExtract, _characters, _selectedGardener);
        engine.Execute();
    }
}