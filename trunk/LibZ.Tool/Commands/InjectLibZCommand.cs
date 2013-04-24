﻿using System.Collections.Generic;
using LibZ.Tool.Tasks;
using ManyConsole;

namespace LibZ.Tool.Commands
{
	public class InjectLibZCommand: ConsoleCommand
	{
		private string _mainFileName;
		private List<string> _libzFileNames = new List<string>();
		private bool _move;
		private string _keyFileName;
		private string _keyFilePassword;

		public InjectLibZCommand()
		{
			IsCommand("inject-libz", "Injects .libz file into assembly as resource");
			HasRequiredOption("a|assembly=", "main file name (.exe or .dll)", s => _mainFileName = s);
			HasRequiredOption("l|libz=", ".libz file name", s => _libzFileNames.Add(s));
			HasOption("move", "move files (remove when added)", _ => _move = true);
			HasOption("k|key=", "key file name", s => _keyFileName = s);
			HasOption("p|password=", "password for password protected key file", s => _keyFilePassword = s);
		}

		public override int Run(string[] remainingArguments)
		{
			var task = new InjectLibZTask();
			task.Execute(_mainFileName, _libzFileNames.ToArray(), _keyFileName, _keyFilePassword, _move);
			return 0;
		}
	}
}
