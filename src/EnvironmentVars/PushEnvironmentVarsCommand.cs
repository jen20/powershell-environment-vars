using System.Management.Automation;

namespace EnvironmentBlocks
{
	[Cmdlet("Push", "EnvironmentVars")]
	public sealed class PushEnvironmentVarsCommand : Cmdlet
	{
		public string Description { get; set; }

		protected override void EndProcessing()
		{
			var environmentFrame = new EnvironmentFrame(Description);
			Context.EnvironmentStack.Push(environmentFrame);
		}
	}
}