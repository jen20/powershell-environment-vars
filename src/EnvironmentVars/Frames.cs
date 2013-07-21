using System.Collections.Generic;

namespace EnvironmentVars
{
	public sealed class Frames
	{
		private static Stack<EnvironmentFrame> _environment;

		internal static Stack<EnvironmentFrame> EnvironmentStack
		{
			get { return _environment ?? (_environment = new Stack<EnvironmentFrame>()); }
		}
	}
}