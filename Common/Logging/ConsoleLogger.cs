namespace Common.Logging
{
	using System;

	public class ConsoleLogger : AbstractLogger
	{
		public ConsoleLogger()
			: base(null) { }

		protected override void Log(string message) => Console.WriteLine(message);
	}
}