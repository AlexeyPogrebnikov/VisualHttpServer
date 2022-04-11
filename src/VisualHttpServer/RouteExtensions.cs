using VisualHttpServer.Core;
using VisualHttpServer.Model;

namespace VisualHttpServer
{
	internal static class RouteExtensions
	{
		internal static RouteUI Convert(this Route route)
		{
			return new RouteUI
			{
				Method = route.Method,
				Path = route.Path,
				Response = new ResponseUI
				{
					StatusCode = route.Response.StatusCode,
					Body = route.Response.Body
				}
			};
		}
	}
}