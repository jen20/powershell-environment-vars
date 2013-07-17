using System.Collections.Generic;
using System.Management.Automation;

namespace EnvironmentBlocks
{
	[Cmdlet("Get", "CurrentEnvironmentVars")]
	public sealed class GetCurrentEnvironmentVarsCommand : Cmdlet
	{
		protected override void EndProcessing()
		{
			var environmentFrame = new EnvironmentFrame("");
			foreach (var key in environmentFrame.Variables.Keys)
			{
				WriteObject(new KeyValuePair<string,string>((string)key, (string)environmentFrame.Variables[key]));
			}
		}
	}
}