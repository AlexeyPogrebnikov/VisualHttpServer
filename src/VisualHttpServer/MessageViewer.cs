using System.Windows;

namespace VisualHttpServer
{
	public class MessageViewer : IMessageViewer
	{
		public void View(string caption, string text)
		{
			MessageBox.Show(text, caption);
		}
	}
}