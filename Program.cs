using System;

class Hello
{
    static void Main()
    {
        Config config = new Config("config.json");
        Selector selector = new Selector();

        Application app = new Application(config, selector);
        app.Run();
    }
}
