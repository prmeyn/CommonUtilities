using Microsoft.AspNetCore.Http;
using System.Linq;



namespace Meyn.Utilities.Extensions
{
	public static class HttpContextExtensions
	{
		public static string? GetPublicIP(this HttpContext context)
		{
			string ip = context.Request.Headers?["HTTP_CF_Connecting_IP"];
			if (string.IsNullOrEmpty(ip))
			{
				ip = context.Request.Headers?["HTTP_X_FORWARDED_FOR"];
			}
			if (string.IsNullOrEmpty(ip))
			{
				ip = context.Request.Headers?["REMOTE_ADDR"];
			}
			if (string.IsNullOrEmpty(ip))
			{
				ip = context.Connection.RemoteIpAddress.ToString();
			}
			ip = ip.Split(",").FirstOrDefault(ip => !ip.Equals("::1") && !ip.Equals("127.0.0.1"));
			return ip;
		}
	}
}
