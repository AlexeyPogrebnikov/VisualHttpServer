using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VisualHttpServer.Commands;
using VisualHttpServer.Model;

namespace VisualHttpServer.Windows
{
	public class EditRouteWindowViewModel : INotifyPropertyChanged
	{
		private RouteUI _route;

		public EditRouteWindowViewModel()
		{
			var routes = ServiceLocator.Resolve<RouteUICollection>();
			var messageViewer = ServiceLocator.Resolve<IMessageViewer>();
			SaveRoute = new SaveRouteCommand(routes, messageViewer);
		}

		public SaveRouteCommand SaveRoute { get; }

		public RouteUI Route
		{
			get => _route;
			set
			{
				_route = value;
				OnPropertyChanged(nameof(Route));
			}
		}

		public static IEnumerable<string> Methods => Constants.Methods;

		public static IEnumerable<int> StatusCodes => Constants.StatusCodes;
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void SetInitialRoute(RouteUI route)
		{
			SaveRoute.InitialRoute = route;
			Route = route.Clone();
		}

		public void SetCloseWindowAction(Action action)
		{
			SaveRoute.CloseWindowAction = action;
		}

		public void SetMainWindowViewModel(IMainWindowViewModel mainWindowViewModel)
		{
			SaveRoute.MainWindowViewModel = mainWindowViewModel;
		}
	}
}