using WindowsInput;
using WindowsInput.Native;

namespace keyemulator_service;

internal static class KeyEmulator
{
    private static readonly InputSimulator InputSimulator = new InputSimulator();
    private static readonly Random Random = new Random();

    private static void Main(string[] args)
    {
        Console.WriteLine("The program has started working.");

        while (true)
        {
            var randomChar = GetRandomChar();

            Console.WriteLine($"The key is pressed: {randomChar}");

            SimulateKeyPress(randomChar);

            Thread.Sleep(10000);
        }
    }

    private static string GetRandomChar()
    {
        const string validChars = "abcdefghijklmnopqrstuvwxyz0123456789";
        var index = Random.Next(validChars.Length);
        return validChars.Substring(index, 1);
    }

    private static void SimulateKeyPress(string key)
    {
        var virtualKeyCode = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), $"VK_{key.ToUpper()}");
        InputSimulator.Keyboard.KeyPress(virtualKeyCode);
    }
}