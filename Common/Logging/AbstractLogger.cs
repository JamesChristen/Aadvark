namespace Common.Logging
{
	using System;

	public abstract class AbstractLogger : ILogger
	{
		protected ILogMessageCreator messageCreator;

		public AbstractLogger(ILogMessageCreator messageCreator = null)
		{
			this.messageCreator = messageCreator ?? new DefaultLogMessageCreator();
		}

		public virtual void Debug(string message = "", Exception ex = null, object sender = null)
			=> this.Log(LogLevel.Debug, message, ex, sender);

		public virtual void Info(string message = "", Exception ex = null, object sender = null)
			=> this.Log(LogLevel.Debug, message, ex, sender);

		public virtual void Warn(string message = "", Exception ex = null, object sender = null)
			=> this.Log(LogLevel.Debug, message, ex, sender);

		public virtual void Error(string message = "", Exception ex = null, object sender = null)
			=> this.Log(LogLevel.Debug, message, ex, sender);

		public virtual void Fatal(string message = "", Exception ex = null, object sender = null)
			=> this.Log(LogLevel.Debug, message, ex, sender);

		public virtual void Log(LogLevel level, string message = "", Exception ex = null, object sender = null)
		{
			string logMessage = this.messageCreator.Create(level, message, ex, sender);
			this.Log(logMessage);
		}

		protected abstract void Log(string message);
	}
}