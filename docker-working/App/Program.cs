// Originally I was going to take the word as a command line arg but
// decided to change it to user input instead as that would be easier
// for the end user to setup and use.
Console.WriteLine("Enter a search word:");
var searchTerm = Console.ReadLine().ToLower();

var count = 0;

// This assumes the file is laid out with one word per line.
// count = File.ReadLines("wordList.txt")
//     .Count(line => line == searchTerm);

// This takes an unformated file and splits it into words which
// are then checked against the search term and counted.
count = File.ReadLines("wordList.txt")
    .SelectMany(line => line.Split(' '))
    .Select(word => word.ToLower())
    .Select(word => word.TrimEnd('.', ',', ';', ':', '?', '!'))
    .Where(word => word != string.Empty)
    .Count(word => word == searchTerm);

Console.WriteLine($"{searchTerm} found {count} times.");

