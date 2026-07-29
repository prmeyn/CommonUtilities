using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Utilities
{
	public static class CryptoUtils
	{
		public static string GetRandomNumber(int numberOfDigits)
		{
			var builder = new StringBuilder(numberOfDigits);
			for (int i = 0; i < numberOfDigits; i++)
			{
				// GetInt32 draws uniformly from [0, 10), avoiding the modulo
				// bias that byte % 10 introduces (0-5 would occur more often).
				builder.Append(RandomNumberGenerator.GetInt32(10));
			}
			return builder.ToString();
		}
		public static string ComputeSha512Hash(string rawData)
		{
			// Create a SHA512   
			using (var sha512Hash = SHA512.Create())
			{
				// ComputeHash - returns byte array  
				byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

				// Convert byte array to a string   
				StringBuilder builder = new();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				return builder.ToString();
			}
		}

		// Encode string to Base64
		public static string ToBase64(string plainText)
		{
			var bytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(bytes);
		}
		
		// Decode Base64 to string
		public static string FromBase64(string base64String)
		{
			var bytes = Convert.FromBase64String(base64String);
			return Encoding.UTF8.GetString(bytes);
		}
	}
}
