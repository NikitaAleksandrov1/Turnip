public interface ISelector
{
    void DisplaySelectOptions(string message, (string Name, Action Function)[] options);
}