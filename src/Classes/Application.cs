public class Application
{
    private IConfig _config;
    private ISelector _selector;
    private Seed itemToExtract = null;
    private Character[] _characters = null;

    private Human[] _gardeners;

    private Human _selectedGardener;

    public Application(IConfig config, ISelector selector)
    {
        _config = config;
        _selector = selector;
    }


    private void Prepare()
    {
        _characters = _config.Characters.ToArray();

        Human[] _gardeners = Array.FindAll(_config.Characters, character => character is Human).Cast<Human>().ToArray();       
        if (_gardeners.Length == 0)
        {
           Console.WriteLine("Please set CanPlant to true for one of the characters in the config file.");
           return;
        }

        _selector.DisplaySelectOptions("Choose gardener:", _gardeners.Select(gardener =>
        (gardener.Name, (Action)(() => { _selectedGardener = gardener; })
        )).ToArray());

        _selector.DisplaySelectOptions("Choose item to extract:", _config.Items.Select(item =>
        (item.Name, (Action)(() => { itemToExtract = new Seed(item.RequiredPowerToExtract, item.Name); })
        )).ToArray());
    }

    private void Execute()
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

    public void Run()
    {
        this.Prepare();
        this.Execute();
    }
}