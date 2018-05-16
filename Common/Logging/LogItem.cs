namespace Common.Logging
{
	using System;

	public class LogItem : ILogItem
	{
		public LogLevel Level { get; set; }
		public string Message { get; set; }
		public Exception Ex { get; set; }
		public object Sender { get; set; }

		public LogItem(LogLevel level, string message, Exception ex, object sender)
		{
			this.Level = level;
			this.Message = message;
			this.Ex = ex;
			this.Sender = sender;
		}
	}
}