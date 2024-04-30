using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Config: IConfig
{
    public Item[] Items { get; set; }
    public Character[] Characters { get; set; }

    private string _jsonFilePath;

    public Config(string jsonFilePath)
    {
        _jsonFilePath = jsonFilePath;
        CreateConfig();
    }
    private void CreateConfig()
    {
        var json = File.ReadAllText(_jsonFilePath);

        var configData = JsonConvert.DeserializeObject<ConfigData>(json);

        Items = configData.Items;

        var characterList = new List<Character>();

        foreach (var characterJson in configData.JsonCharacters)
            {
            string characterJsonString = JsonConvert.SerializeObject(characterJson);

            JObject character = JObject.Parse(characterJsonString);

            if (character["CanPlant"].ToObject<bool>())
            {
                characterList.Add(character.ToObject<Human>());
            }
            else
            {
                characterList.Add(character.ToObject<Animal>());
            }
        }

        Characters = characterList.ToArray();
}
}

