using System;
using System.Management.Automation;

namespace EnvironmentVars
{
	[Cmdlet("Pop", "Environment")]
	public sealed class PopEnvironmentCommand : PSCmdlet
	{
		protected override void EndProcessing()
		{
			var frame = Frames.EnvironmentStack.Pop();

			if (frame == null)
				return;
			
			if (!String.IsNullOrEmpty(frame.Description))
				WriteVerbose("Restoring " + frame.Description);

			frame.Restore(Host);
		}
	}
}