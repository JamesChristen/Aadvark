namespace Common.Extensions
{
	using System;

	public static class EnumExtensions
	{
		public static TEnum ParseEnum<TEnum>(this object input)
			where TEnum : struct, IComparable
		{
			if (!typeof(TEnum).IsEnum)
			{
				throw new ArgumentException($"{typeof(TEnum).Name} is not an enum type!");
			}

			if (input is int)
			{
				return (TEnum)input;
			}

			return input.ToString().ParseEnum<TEnum>();
		}

		public static TEnum ParseEnum<TEnum>(this string input)
			where TEnum : struct, IComparable
		{
			if (!typeof(Enum).IsEnum)
			{
				throw new ArgumentException($"{typeof(TEnum).Name} is not an enum type!");
			}

			return (TEnum)Enum.Parse(typeof(TEnum), input);
		}
	}
}