namespace Common.Extensions
{
	using System.Collections.Generic;

	public static class EnumerableExtensions
	{
		public static IEnumerable<T> AsSingleEnumerable<T>(this T obj)
		{
			yield return obj;
		}
	}
}