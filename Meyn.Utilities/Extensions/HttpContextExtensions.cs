using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Linq;



namespace Meyn.Utilities.Extensions
{
	public static class HttpContextExtensions
	{
		public static string? GetPublicIP(this HttpContext context)
		{
			IServerVariablesFeature serverVariables = context.Features.Get<IServerVariablesFeature>();
			string ip = serverVariables?["HTTP_CF_Connecting_IP"];
			if (string.IsNullOrEmpty(ip))
			{
				ip = serverVariables?["HTTP_X_FORWARDED_FOR"];
			}
			if (string.IsNullOrEmpty(ip))
			{
				ip = serverVariables?["REMOTE_ADDR"];
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
