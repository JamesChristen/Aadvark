namespace Common.Logging
{
	using System.Collections.Generic;

	public interface IConcurrentLogger : ILogger
	{
		IBlockLogger CreateLogger();
		void AcceptLogs(IEnumerable<ILogItem> logs);
	}
}