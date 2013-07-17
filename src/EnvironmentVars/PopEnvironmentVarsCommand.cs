using System;
using System.Management.Automation;

namespace EnvironmentBlocks
{
	[Cmdlet("Pop", "EnvironmentVars")]
	public sealed class PopEnvironmentVarsCommand : Cmdlet
	{
		protected override void EndProcessing()
		{
			var frame = Context.EnvironmentStack.Pop();

			if (frame == null)
				return;
			
			if (!String.IsNullOrEmpty(frame.Description))
				WriteVerbose("Restoring " + frame.Description);

			frame.Restore();
		}
	}
}