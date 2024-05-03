namespace BoraRachar.Domain.Utils;

public static class Helpers
{
    public static string randonName()
    {
        int tamanho = 6;
        var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var result = new string(
            Enumerable.Repeat(chars, tamanho)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        return result;
    }
    
}