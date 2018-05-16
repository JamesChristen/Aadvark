namespace Common.Logging
{
	using System;

	public interface ILogger
	{
		void Log(LogLevel level, string message = "", Exception ex = null, object sender = null);
		void Debug(string message = "", Exception ex = null, object sender = null);
		void Info(string message = "", Exception ex = null, object sender = null);
		void Warn(string message = "", Exception ex = null, object sender = null);
		void Error(string message = "", Exception ex = null, object sender = null);
		void Fatal(string message = "", Exception ex = null, object sender = null);
	}
}