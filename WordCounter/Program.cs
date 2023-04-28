namespace WordCounter
{
    class WordCounter
    {
        static void Main(string[] args)
        {
            // Normally I would handle the exception here, but since we are dealing
            // with inputs this really needs to exit on a failure. Also I would
            // send the error to the log file and send an error message to the user.
            var (searchTerm, filePath) = GetInputs(args);

            // This takes an unformated file and splits it into words which are then
            // checked against the search term and counted. It assumes that the
            // words are space separated. If we have a specific format this could be
            // optimized and changed to fite the new format easily.
            var count = File.ReadLines("wordList.txt")
                .SelectMany(line => line.Split(' '))
                .Select(word => word.ToLower())
                .Select(word => word
                    .TrimEnd('.', ',', ';', ':', '?', '!')
                    .TrimStart('.', ',', ';', ':', '?', '!'))
                .Where(word => word != string.Empty)
                .Count(word => word == searchTerm);

            Console.WriteLine($"{searchTerm} found {count} times.");
        }

        static (string searchTerm, string filePath) GetInputs(string[] args)
        {
            string filePath = "wordList.txt";

            if (args.Length == 0)
            {
                // Use default file path and prompt user for search term.
                Console.WriteLine("Enter a search term: ");
                var term = Console.ReadLine();

                while (term == null)
                {
                    Console.WriteLine("You must enter a search term.");
                    Console.WriteLine("Enter a search term: ");
                    term = Console.ReadLine();
                }

                return (
                    term.ToLower(),
                    filePath
                );
            }
            else if (args.Length == 1)
            {
                // Use default file path and use arg as search term.
                return (
                    args[0].ToLower(),
                    filePath
                );
            }
            else if (args.Length == 2)
            {
                // Use args as search term and file path.
                return (
                    args[0].ToLower(),
                    args[1]
                );
            }
            else
            {
                // If we are here then the user has passed too many args or
                // tried to use it in a way that is not supported.
                Console.WriteLine("Usage: WordCounter");
                Console.WriteLine("Usage: WordCounter <searchTerm>");
                Console.WriteLine("Usage: WordCounter <searchTerm> <filePath>");
                throw new Exception("Unsupported usage");
            }
        }
    }
}