public class Application
{
    private IConfig _config;
    private ISelector _selector;

    private Item itemToExtract = null;
    private Character[] _characters = null;

    private Human _selectedGardener;


    public Application(IConfig config, ISelector selector)
    {
        _config = config;
        _selector = selector;
    }

    

    private (Item, Character[], Human) GetUserInputs()
    {   
        Human selectedGardener = null;
        Item itemToExtract = null;
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
        (item.Name, (Action)(() => { itemToExtract = new Item(item.RequiredPowerToExtract, item.Name); })
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