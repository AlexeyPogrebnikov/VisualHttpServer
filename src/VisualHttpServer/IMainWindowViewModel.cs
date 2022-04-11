using System.Collections.ObjectModel;
using VisualHttpServer.Core;

namespace VisualHttpServer
{
	public interface IMainWindowViewModel
	{
		ObservableCollection<Interaction> HandledRequests { get; }
		ObservableCollection<Interaction> UnhandledRequests { get; }
		void RefreshRouteListView();
	}
}