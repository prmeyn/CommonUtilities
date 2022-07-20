using System.Collections.Generic;
using System.Linq;

namespace Common.Utilities
{
	public static class Utils
	{
		public static string SubstituteTemplate(string template, Dictionary<string, string> args)
		{
			var result = string.IsNullOrWhiteSpace(template) ? string.Join("\n", args.Keys.Select(k => $"##{k}##")) : template;
			foreach (var arg in args)
			{
				result = result.Replace("##" + arg.Key + "##", arg.Value);
			}
			return result;
		}
	}
}
