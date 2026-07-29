using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Meyn.Utilities.Extensions
{
	public static class HttpContextExtensions
	{
		public static string? GetPublicIP(this HttpContext context)
		{
			string? ip = context.Request.Headers["CF-Connecting-IP"];
			if (string.IsNullOrEmpty(ip))
			{
				ip = context.Request.Headers["X-Forwarded-For"];
			}
			if (string.IsNullOrEmpty(ip))
			{
				ip = context.Connection.RemoteIpAddress?.ToString();
			}
			if (string.IsNullOrEmpty(ip))
			{
				return null;
			}
			return ip
				.Split(',')
				.Select(part => part.Trim())
				.FirstOrDefault(part => !part.Equals("::1") && !part.Equals("127.0.0.1"));
		}
	}
}
