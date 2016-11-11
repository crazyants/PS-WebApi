﻿using DataBooster.PSWebApi;

namespace PSWebApi.OwinSample
{
	public class CmdArgumentResolver
	{
		private readonly string _fileExtension;

		public CmdArgumentResolver(string fileExtension)
		{
			_fileExtension = (fileExtension == null) ? string.Empty : fileExtension.Trim().ToUpperInvariant();
		}

		public string Quote(string rawArg, bool forceQuote = false)
		{
			if (string.IsNullOrWhiteSpace(rawArg))
				return "\"" + (rawArg ?? string.Empty) + "\"";

			switch (_fileExtension)
			{
				case ".EXE": return CmdArgumentsBuilder.QuoteExeArgument(rawArg, forceQuote);
				case ".BAT": return CmdArgumentsBuilder.QuoteBatArgument(rawArg, forceQuote);
				default: return rawArg;
			}
		}
	}
}