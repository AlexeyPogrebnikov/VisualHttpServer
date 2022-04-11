using System;
using System.Windows.Input;
using VisualHttpServer.Model;
using VisualHttpServer.Windows;

namespace VisualHttpServer.Commands
{
	public class EditRouteCommand : ICommand
	{
		private readonly IMainWindowViewModel _mainWindowViewModel;

		public EditRouteCommand(IMainWindowViewModel mainWindowViewModel)
		{
			_mainWindowViewModel = mainWindowViewModel;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			var route = (RouteUI) parameter;

			EditRouteWindow window = new();
			var viewModel = (EditRouteWindowViewModel) window.DataContext;
			viewModel.SetMainWindowViewModel(_mainWindowViewModel);
			viewModel.SetInitialRoute(route);
			window.ShowDialog();
		}

		public event EventHandler CanExecuteChanged;
	}
}