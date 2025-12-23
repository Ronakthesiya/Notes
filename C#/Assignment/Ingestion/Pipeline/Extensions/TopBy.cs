using Ingestion.Pipeline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Extensions
{
    public static class BookEnumerableExtensions
    {
        /// <summary>
        /// Return the top <paramref name="n"/> books sorted by a key selector.
        /// </summary>
        public static IEnumerable<Book> TopBy<TValue>(
            this IEnumerable<Book> books,
            Func<Book, TValue> keySelector,
            int n)
        {
            return books
                .OrderByDescending(keySelector)
                .Take(n);
        }
        /// <summary>
        /// Count how many books exist for each condition category.
        /// </summary>
        public static IEnumerable<ConditionCount> ToConditionCounts(
            this IEnumerable<Book> books)
        {
            return books
                .GroupBy(b => b.Condition)
                .Select(g => new ConditionCount(g.Key, g.Count()));
        }
    }

    public sealed class ConditionCount {
        string Condition;
        int Count;

        public ConditionCount()
        {
        }

        public ConditionCount(string a,int b)
        {
            Condition = a;
            Count = b;
        }
    }

}
