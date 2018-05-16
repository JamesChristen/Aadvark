namespace Common.Logging
{
	using System;

	public interface ILogItem
	{
		LogLevel Level { get; set; }
		string Message { get; set; }
		Exception Ex { get; set; }
		object Sender { get; set; }
	}
}