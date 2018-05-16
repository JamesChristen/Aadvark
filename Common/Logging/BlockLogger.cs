namespace Common.Logging
{
	using System;
	using System.Collections.Generic;

	public class BlockLogger : IBlockLogger
	{
		private IConcurrentLogger master;
		private List<LogItem> logs;

		public BlockLogger(IConcurrentLogger master)
		{
			this.master = master;
			this.logs = new List<LogItem>();
		}

		public void Debug(string message = "", Exception ex = null, object sender = null)
			=> this.Log(LogLevel.Debug, message, ex, sender);

		public void Info(string message = "", Exception ex = null, object sender = null)
			=> this.Log(LogLevel.Debug, message, ex, sender);

		public void Warn(string message = "", Exception ex = null, object sender = null)
			=> this.Log(LogLevel.Debug, message, ex, sender);

		public void Error(string message = "", Exception ex = null, object sender = null)
			=> this.Log(LogLevel.Debug, message, ex, sender);

		public void Fatal(string message = "", Exception ex = null, object sender = null)
			=> this.Log(LogLevel.Debug, message, ex, sender);

		public void Log(LogLevel level, string message = "", Exception ex = null, object sender = null)
		{
			LogItem log = new LogItem(level, message, ex, sender);
			this.logs.Add(log);
		}

		public void Dispose()
		{
			this.master.AcceptLogs(this.logs);
			this.logs.Clear();
			this.master = null;
		}
	}
}