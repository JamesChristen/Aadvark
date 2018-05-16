namespace Common.Logging
{
	using System;
	using System.Collections.Generic;

	public class ConcurrentLogger : IConcurrentLogger
	{
		protected ILogger logger;
		protected readonly object loggerLock = new object();

		public ConcurrentLogger(ILogger logger)
		{
			this.logger = logger;
		}

		public IBlockLogger CreateLogger()
			=> new BlockLogger(this);

		public void AcceptLogs(IEnumerable<ILogItem> logs)
		{
			lock (this.loggerLock)
			{
				foreach (ILogItem log in logs)
				{
					this.logger.Log(log.Level, log.Message, log.Ex, log.Sender);
				}
			}
		}

		public void Debug(string message = "", Exception ex = null, object sender = null)
			=> this.logger.Debug(message, ex, sender);

		public void Error(string message = "", Exception ex = null, object sender = null)
			=> this.logger.Error(message, ex, sender);

		public void Fatal(string message = "", Exception ex = null, object sender = null)
			=> this.logger.Fatal(message, ex, sender);

		public void Info(string message = "", Exception ex = null, object sender = null)
			=> this.logger.Info(message, ex, sender);

		public void Log(LogLevel level, string message = "", Exception ex = null, object sender = null)
			=> this.logger.Log(level, message, ex, sender);

		public void Warn(string message = "", Exception ex = null, object sender = null)
			=> this.logger.Warn(message, ex, sender);
	}
}