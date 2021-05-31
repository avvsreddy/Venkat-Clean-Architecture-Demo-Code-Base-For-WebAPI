/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2022
 * Email: venkat@pratian.com
 */

namespace TG.CandidateProfiling.Domain.Converters
{
    public interface IConvertModel<TSource, TTarget>
    {
        TTarget Convert();
    }
}