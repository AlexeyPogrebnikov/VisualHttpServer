using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VisualHttpServer.Commands;
using VisualHttpServer.Model;

namespace VisualHttpServer.Windows
{
	public class NewRouteWindowViewModel : INotifyPropertyChanged
	{
		private RouteUI _route;

		public NewRouteWindowViewModel()
		{
			var routes = ServiceLocator.Resolve<RouteUICollection>();
			var messageViewer = ServiceLocator.Resolve<IMessageViewer>();
			CreateRoute = new CreateRouteCommand(routes, messageViewer);
		}

		public CreateRouteCommand CreateRoute { get; }

		public RouteUI Route
		{
			get => _route;
			set
			{
				_route = value;
				OnPropertyChanged(nameof(Route));
			}
		}

		public IEnumerable<string> Methods => Constants.Methods;

		public IEnumerable<int> StatusCodes => Constants.StatusCodes;
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void SetCloseWindowAction(Action action)
		{
			CreateRoute.CloseWindowAction = action;
		}
	}
}