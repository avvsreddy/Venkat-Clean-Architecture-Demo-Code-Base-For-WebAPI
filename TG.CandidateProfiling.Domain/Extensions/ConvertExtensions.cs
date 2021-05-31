/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2022
 * Email: venkat@pratian.com
 */


using System.Collections.Generic;
using System.Linq;
using TG.CandidateProfiling.Domain.Converters;

namespace TG.CandidateProfiling.Domain.Extensions
{
    public static class ConvertExtensions
    {
        public static IEnumerable<TTarget> ConvertAll<TSource, TTarget>(
            this IEnumerable<IConvertModel<TSource, TTarget>> values) 
            => values.Select(value => value.Convert());
    }
}