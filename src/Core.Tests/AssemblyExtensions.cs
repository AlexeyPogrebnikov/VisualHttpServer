using System.IO;
using System.Reflection;

namespace VisualHttpServer.Core.Tests
{
	internal static class AssemblyExtensions
	{
		internal static string GetEmbeddedResourceTextContent(this Assembly assembly, string resourceName)
		{
			using Stream stream = assembly.GetManifestResourceStream(resourceName);
			using var reader = new StreamReader(stream);
			return reader.ReadToEnd();
		}
	}
}