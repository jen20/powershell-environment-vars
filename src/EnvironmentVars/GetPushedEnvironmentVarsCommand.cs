using System.Collections.Generic;
using System.Management.Automation;

namespace EnvironmentBlocks
{
	[Cmdlet("Get", "PushedEnvironmentVars")]
	public sealed class GetPushedEnvironmentVarsCommand : Cmdlet
	{
		protected override void EndProcessing()
		{
			var environmentFrame = Context.EnvironmentStack.Peek();
			foreach (var key in environmentFrame.Variables.Keys)
			{
				WriteObject(new KeyValuePair<string, string>((string)key, (string)environmentFrame.Variables[key]));
			}
		}
	}
}