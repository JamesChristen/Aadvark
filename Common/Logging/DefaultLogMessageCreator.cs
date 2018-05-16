namespace Common.Logging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class DefaultLogMessageCreator : ILogMessageCreator
	{
		public int ExceptionDepth { get; set; }
		public Func<Exception, string> ExceptionFormat { get; set; }

		/// <param name="exceptionLogDepth">Depth of exceptions to log. Greater than or equal to 1 for specific depth, -1 for full</param>
		public DefaultLogMessageCreator(int exceptionLogDepth = 1)
		{
			if (exceptionLogDepth == 0 || exceptionLogDepth < -1)
			{
				throw new ArgumentException($"exceptionLogDepth must be greater than or equal to 1, or -1");
			}
			this.ExceptionDepth = exceptionLogDepth;
			this.ExceptionFormat = ex => $"{ex.Message} - {ex.StackTrace}";
		}

		public string Create(LogLevel level, string message = "", Exception ex = null, object sender = null)
		{
			string leadingLine = $"{level.ToString()} ({DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}): ";
			if (sender != null)
			{
				leadingLine += $"({sender.ToString()}) ";
			}
			leadingLine += message;

			List<string> exceptionLines = this.GetExceptionLines(ex).ToList();

			StringBuilder builder = new StringBuilder();
			builder.AppendLine(leadingLine);
			exceptionLines.ForEach(x => builder.AppendLine(x));
			return builder.ToString();
		}

		private IEnumerable<string> GetExceptionLines(Exception ex)
		{
			if (ex == null)
			{
				return new List<string>();
			}

			List<string> lines = new List<string>();
			if (this.ExceptionDepth == -1) // Load all the exceptions
			{
				do
				{
					lines.Add(this.ExceptionFormat(ex));
					ex = ex.InnerException;
				}
				while (ex != null);
			}
			else
			{
				int remainingLines = this.ExceptionDepth;
				while (remainingLines > 0 && ex != null)
				{
					lines.Add(this.ExceptionFormat(ex));
					ex = ex.InnerException;
					remainingLines--;
				}
			}
			return lines;
		}
	}
}