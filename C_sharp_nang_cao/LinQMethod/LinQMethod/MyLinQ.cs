using System;
using System.Collections.Generic;
using System.Text;

namespace LinQMethod
{
    public static class MyLinQ
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }
        
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item)) yield return item;
            }
        }

    }

}
