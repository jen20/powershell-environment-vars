using System.Collections.Generic;

namespace EnvironmentBlocks
{
	public sealed class Context
	{
		private static Stack<EnvironmentFrame> _environment;

		internal static Stack<EnvironmentFrame> EnvironmentStack
		{
			get { return _environment ?? (_environment = new Stack<EnvironmentFrame>()); }
		}
	}
}