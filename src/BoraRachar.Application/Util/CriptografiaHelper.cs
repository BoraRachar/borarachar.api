﻿using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BoraRachar.Application.Util;

public static class CriptografiaHelper
{
	const string encryptionKey = "Um9kcmlnbyBZb3NoaWthenUgU2FoYXJh"; //Coloque aqui uma chave única
	public static string EncryptQueryString(string clearText)
	{
		byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
		using (Aes encryptor = Aes.Create())
		{
			var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
			encryptor.Key = pdb.GetBytes(32);
			encryptor.IV = pdb.GetBytes(16);
			using (var ms = new MemoryStream())
			{
				using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
				{
					cs.Write(clearBytes, 0, clearBytes.Length);
					cs.Close();
				}
				clearText = Convert.ToBase64String(ms.ToArray());
			}
		}
		return clearText;
	}

	public static string DecryptQueryString(string cipherText)
	{
		cipherText = cipherText.Replace(" ", "+");
		byte[] cipherBytes = Convert.FromBase64String(cipherText);
		using (Aes encryptor = Aes.Create())
		{
			var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
			encryptor.Key = pdb.GetBytes(32);
			encryptor.IV = pdb.GetBytes(16);
			using (var ms = new MemoryStream())
			{
				using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
				{
					cs.Write(cipherBytes, 0, cipherBytes.Length);
					cs.Close();
				}
				cipherText = Encoding.Unicode.GetString(ms.ToArray());
			}
		}

		return cipherText;
	}

	public static bool VerifyEmail(string email)
	{
		try
		{
			MailAddress m = new MailAddress(email);

			return true;
		}
		catch (FormatException)
		{
			return false;
		}
	}
}
