using System;
using System.Drawing;
using System.IO;
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

    public static bool IsBase64Image(string base64Str)
    {
        if(base64Str.Contains(','))
        {
            base64Str = base64Str.Split(',')[1];
        }
        try
        {
            byte[] imageBytes = Convert.FromBase64String(base64Str);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return true;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
}