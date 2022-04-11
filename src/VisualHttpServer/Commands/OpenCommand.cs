using System;
using System.Linq;
using System.Windows.Input;
using Microsoft.Win32;
using VisualHttpServer.Core;
using VisualHttpServer.Model;

namespace VisualHttpServer.Commands
{
	public class OpenCommand : ICommand
	{
		private readonly IHttpServer _httpServer;
		private readonly IMessageViewer _messageViewer;
		private readonly RouteUICollection _routes;

		public OpenCommand(IHttpServer httpServer, RouteUICollection routes, IMessageViewer messageViewer)
		{
			_httpServer = httpServer;
			_routes = routes;
			_messageViewer = messageViewer;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			if (_httpServer.IsStarted)
			{
				_messageViewer.View("Can't open a file", "Please stop the server before open a file.");
				return;
			}

			var dialog = new OpenFileDialog
			{
				DefaultExt = ".json",
				Filter = "JSON files (.json)|*.json"
			};

			if (dialog.ShowDialog() == true)
			{
				var project = new ServerProject();

				project.Load(dialog.FileName);

				ConnectionSettings connectionSettings = ConnectionSettingsCache.ConnectionSettings;
				connectionSettings.Host = project.Connection.Host;
				connectionSettings.Port = project.Connection.Port.ToString();

				_routes.Init(project.Routes.Select(route => route.Convert()));
				ServerProjectOpened?.Invoke(this, EventArgs.Empty);
			}
		}

		public event EventHandler CanExecuteChanged;

		internal event EventHandler ServerProjectOpened;
	}
}