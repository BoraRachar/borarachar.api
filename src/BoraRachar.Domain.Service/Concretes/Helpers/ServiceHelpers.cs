using BoraRachar.Domain.Entity.Enum;

namespace BoraRachar.Domain.Service.Concretes.Helpers;

public class ServiceHelpers
{
    
    public static TipoDivisao GetEnumValue(int tipo)
    {
        System.Enum.TryParse(tipo.ToString(), out TipoDivisao value);
   
        return value;
    }
    
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