using System.Management.Automation;

namespace EnvironmentVars
{
	[Cmdlet("Push", "Environment")]
	public sealed class PushEnvironmentCommand : PSCmdlet
	{
		public string Description { get; set; }

		protected override void EndProcessing()
		{
			var environmentFrame = new EnvironmentFrame(Description, Host);
			Frames.EnvironmentStack.Push(environmentFrame);
		}
	}
}