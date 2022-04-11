using System;
using System.Net;
using System.Threading.Tasks;
using VisualHttpServer.Core;

namespace VisualHttpServer
{
	public interface IHttpServer
	{
		bool IsStarted { get; }
		bool StartEnabled { get; }
		bool StopEnabled { get; }
		RouteCollection Routes { get; }
		InteractionCollection HandledInteractions { get; }
		InteractionCollection UnhandledInteractions { get; }
		event EventHandler StatusChanged;

		/// <exception cref="InvalidOperationException"></exception>
		Task StartAsync(IPAddress address, int port);

		/// <exception cref="InvalidOperationException"></exception>
		Task StopAsync();
	}
}