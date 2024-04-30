public class Selector : ISelector {
    public void DisplaySelectOptions(string message, (string Name, Action Function)[] options)
    {
        Console.WriteLine(message);
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i].Name}");
        }

        string userInput = Console.ReadLine();
        int selection = int.Parse(userInput) - 1;

        if (selection >= 0 && selection < options.Length)
        {
            options[selection].Function();
        }
        else
        {
            Console.WriteLine("Invalid selection");
        }
    }
}