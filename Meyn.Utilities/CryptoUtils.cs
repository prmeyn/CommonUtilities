using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common.Utilities
{
	public static class CryptoUtils
	{
		private static readonly RandomNumberGenerator RandomNumberGenerator = RandomNumberGenerator.Create();

		public static string GetRandomNumber(int numberOfDigits)
		{
			var bytes = new byte[numberOfDigits];
			RandomNumberGenerator.GetBytes(bytes);
			return string.Join(string.Empty, bytes.Select(b => b % 10));
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
/*
		public static string Base64Encode(string plainText)
		{
			try
			{
				if (string.IsNullOrEmpty(plainText))
				{
					return "";
				}
				var plainTextBytes = Encoding.GetEncoding(28591).GetBytes(plainText);
				return System.Convert.ToBase64String(plainTextBytes);
			}
			catch{}
			return "";
		}

		public static string Base64Decode(string base64EncodedData)
		{
			try
			{
				if (string.IsNullOrEmpty(base64EncodedData))
				{
					return "";
				}
				var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
				return Encoding.GetEncoding(28591).GetString(base64EncodedBytes);
			}
			catch{}
			return base64EncodedData;
		}
*/
	}
}
