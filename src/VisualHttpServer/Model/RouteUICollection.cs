using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VisualHttpServer.Core;

namespace VisualHttpServer.Model
{
	public class RouteUICollection : IEnumerable<RouteUI>
	{
		private readonly ObservableCollection<RouteUI> _collection = new();
		private readonly IHttpServer _httpServer;

		public RouteUICollection(IHttpServer httpServer)
		{
			_httpServer = httpServer;
		}

		public IEnumerator<RouteUI> GetEnumerator()
		{
			return _collection.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		internal ObservableCollection<RouteUI> AsObservable()
		{
			return _collection;
		}

		internal void Update(RouteUI target, RouteUI source)
		{
			target.Update(source);
			UpdateServerRoutes();
		}

		internal void Add(RouteUI route)
		{
			_collection.Add(route);
			UpdateServerRoutes();
		}

		internal void Remove(RouteUI route)
		{
			_collection.Remove(route);
			UpdateServerRoutes();
		}

		internal void Clear()
		{
			_collection.Clear();
			UpdateServerRoutes();
		}

		internal void Init(IEnumerable<RouteUI> routes)
		{
			_collection.Clear();
			foreach (RouteUI route in routes)
				_collection.Add(route);
			UpdateServerRoutes();
		}

		private void UpdateServerRoutes()
		{
			IEnumerable<Route> routes = _collection
				.Select(rt => new Route
				{
					Method = rt.Method,
					Path = rt.Path,
					Response = ConvertResponse(rt.Response)
				});

			_httpServer.Routes.Init(routes.ToArray());
		}

		private static Response ConvertResponse(ResponseUI response)
		{
			if (response == null)
				return null;

			return new Response
			{
				StatusCode = response.StatusCode,
				Body = response.Body
			};
		}
	}
}