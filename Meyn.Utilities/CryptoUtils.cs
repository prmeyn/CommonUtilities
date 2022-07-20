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
		public static string ComputeSha256Hash(string rawData)
		{
			// Create a SHA256   
			using (var sha256Hash = SHA256.Create())
			{
				// ComputeHash - returns byte array  
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

				// Convert byte array to a string   
				StringBuilder builder = new();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				return builder.ToString();
			}
		}
	}
}
