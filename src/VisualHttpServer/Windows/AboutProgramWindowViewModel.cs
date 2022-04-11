using System.ComponentModel;
using VisualHttpServer.Core;

namespace VisualHttpServer.Windows
{
	public class AboutProgramWindowViewModel : INotifyPropertyChanged
	{
		public string Version => VersionHelper.GetCurrentAppVersion();

		public string Author => "Alexey Pogrebnikov";

		public event PropertyChangedEventHandler PropertyChanged;
	}
}