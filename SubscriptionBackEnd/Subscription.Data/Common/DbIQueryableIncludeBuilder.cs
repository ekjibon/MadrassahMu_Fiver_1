using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Data.Common
{
    public static class DbIQueryableIncludeBuilder
    {
        public static IQueryable<T> WithIncludes<T>(this IQueryable<T> sequence,  List<string> includes)
        {
            {
                foreach (string include in includes)
                {
                    sequence = sequence.Include(include);
                }
            }
            return sequence;
        }
    }
}
