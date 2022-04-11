using System;

namespace VisualHttpServer
{
	internal class EnvironmentWrapper : IEnvironmentWrapper
	{
		public string GetRoamingPath()
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		}
	}
}