Console.WriteLine("Enter a search word:");
var word = Console.ReadLine().ToLower();

// if (argv.Length != 2)
// {
//     Console.WriteLine("Usage: dotnet run -- <word>");
//     return;
// }

var counter = 0;

using (StreamReader reader = File.OpenText("wordList.txt"))
{
    String line;
    while ((line = reader.ReadLine()) is not null)
    {
        // if (line == argv[0])
        // Console.WriteLine(line);
        if (line == word)
        {
            ++counter;
            // Console.WriteLine($"########counted########   {counter}");
        }
    }
}
// Console.WriteLine($"{argv[0]} found {counter} times.");
Console.WriteLine($"{word} found {counter} times.");
