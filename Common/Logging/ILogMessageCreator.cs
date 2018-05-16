namespace Common.Logging
{
	using System;

	public interface ILogMessageCreator
	{
		string Create(LogLevel level, string message = "", Exception ex = null, object sender = null);
	}
}