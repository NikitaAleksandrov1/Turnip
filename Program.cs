using System;

class Hello
{
    static void Main()
    {
        IConfig config = new Config("config.json");
        ISelector selector = new Selector();

        Application app = new Application(config, selector);
        app.Run();
    }
}
