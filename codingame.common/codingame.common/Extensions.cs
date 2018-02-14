namespace codingame.common
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public static class Extensions
	{
		public static string Join(this IEnumerable<string> array, string separator)
		{
			return string.Join(separator, array);
		}

		public static TValue GetMethodAttributeValue<TAttribute, TValue>(this Action action, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
		{
			var methodInfo = action.Method;
			var attr = methodInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
			return attr != null ? valueSelector(attr) : default(TValue);
		}
	}
}
