using System;
using System.Collections;
using System.Collections.Generic;

namespace EnvironmentBlocks
{
	public sealed class EnvironmentFrame
	{
		private readonly IDictionary _variables;

		public EnvironmentFrame(string description)
		{
			Timestamp = DateTime.Now;
			Description = description ?? String.Empty;
			var envvars = Environment.GetEnvironmentVariables();
			_variables = new SortedDictionary<string, string>();
			foreach (DictionaryEntry entry in envvars)
			{
				_variables.Add(entry.Key, entry.Value);
			}
		}

		public string Description { get; private set; }
		public DateTime Timestamp { get; private set; }
		public IDictionary Variables
		{
			get { return _variables; }
		}

		public void Restore()
		{
			// Delete environment variables that are in the current
			// environment but not in the one being restored.
			var currentVars = Environment.GetEnvironmentVariables();
			foreach (DictionaryEntry entry in currentVars)
			{
				if (!Variables.Contains(entry.Key))
				{
					Environment.SetEnvironmentVariable((string)entry.Key, null);
				}
			}

			// Now set all the environment variables defined in this frame
			foreach (DictionaryEntry entry in Variables)
			{
				var name = (string)entry.Key;
				var value = (string)entry.Value;
				Environment.SetEnvironmentVariable(name, value);
			}
		}
	}
}
