namespace Common.Logging
{
	using Common.Extensions;
	using System.IO;

	public class FileLogger : AbstractLogger
	{
		private string filepath;

		public FileLogger(string filepath, ILogMessageCreator messageCreator = null)
			: base(messageCreator)
		{
			this.filepath = filepath;
		}

		protected override void Log(string message)
		{
			if (!File.Exists(this.filepath))
			{
				File.Create(this.filepath);
			}
			File.AppendAllLines(this.filepath, message.AsSingleEnumerable());
		}
	}
}