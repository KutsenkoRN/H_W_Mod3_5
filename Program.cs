namespace H_W_Mod3_5;

internal class Program
{
    static async Task Main(string[] args)
    {
        var concatenatedText = await ConcatenateTextAsync();
        Console.WriteLine(concatenatedText);
    }

    static async Task<string> ReadFileAsync(string filename)
    {
        using (var reader = new StreamReader(filename))
        {
            return await reader.ReadToEndAsync();
        }
    }

    static async Task<string> ConcatenateTextAsync()
    {
        var helloTask = ReadFileAsync("Hello.txt");
        var worldTask = ReadFileAsync("World.txt");

       var res = Task.WhenAll(helloTask, worldTask);
       return String.Join(" ", await res);
    }
}