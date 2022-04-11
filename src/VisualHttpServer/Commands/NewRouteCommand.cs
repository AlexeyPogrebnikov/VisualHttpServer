using System;
using System.Windows.Input;
using VisualHttpServer.Core;
using VisualHttpServer.Model;
using VisualHttpServer.Windows;

namespace VisualHttpServer.Commands
{
	public class NewRouteCommand : ICommand
	{
		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			NewRouteWindow window = new();
			var newRouteWindowViewModel = (NewRouteWindowViewModel) window.DataContext;
			RouteUI route = new()
			{
				Response = new ResponseUI
				{
					StatusCode = 200
				}
			};

			if (parameter is Interaction interaction)
			{
				route.Method = interaction.Request.Method;
				route.Path = interaction.Request.Path;
			}

			newRouteWindowViewModel.Route = route;
			window.Show();
		}

		public event EventHandler CanExecuteChanged;
	}
}