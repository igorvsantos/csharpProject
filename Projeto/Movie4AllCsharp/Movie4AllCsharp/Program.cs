using System.IO;
using System.Text.Json;


namespace Movie4AllCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"c:\temp\movie4all.json";
            string json = string.Empty;

            Movie4All movie4all;

            // If file Exists
            if (File.Exists(path))
            {
                json = File.ReadAllText(path);
                movie4all = JsonSerializer.Deserialize<Movie4All>(json);
            }
            else
            {
                movie4all = new Movie4All();
            }

            Menu.Home(movie4all);
            
            var options = new JsonSerializerOptions() { WriteIndented = true };
            json = JsonSerializer.Serialize(movie4all, options);
            File.WriteAllText(path, json);
        }

    }
}
