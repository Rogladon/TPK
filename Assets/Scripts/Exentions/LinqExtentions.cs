using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class LinqExtentions {
	public async static Task ForEachAsync<T>(this IEnumerable<T> e, Func<T, Task> action) {
		foreach(var i in e) {
			await action(i);
		}
	}
	public static IEnumerable<T> ForEach<T>(this IEnumerable<T> e, Action<T> action) {
		foreach (var i in e) {
			action(i);
		}
		return e;
	}
}
