using System.IO;
using System.Text;
using NUnit.Framework;

namespace VisualHttpServer.Core.Tests
{
	[TestFixture]
	public class ResponseTests
	{
		[Test]
		public void Write_Body_is_not_null()
		{
			Encoding encoding = Encoding.UTF8;

			Response res = new()
			{
				StatusCode = 404,
				Body = "foo"
			};

			using MemoryStream stream = new();
			res.Write(stream);
			string response = encoding.GetString(stream.ToArray());
			Assert.AreEqual("HTTP/1.1 404 OK\r\nContent-Length: 3\r\n\r\nfoo\r\n", response);
		}

		[Test]
		public void Write_Body_is_null()
		{
			Encoding encoding = Encoding.UTF8;

			Response res = new()
			{
				StatusCode = 200,
				Body = null
			};

			using MemoryStream stream = new();
			res.Write(stream);
			string response = encoding.GetString(stream.ToArray());
			Assert.AreEqual("HTTP/1.1 200 OK\r\nContent-Length: 0\r\n\r\n", response);
		}
	}
}