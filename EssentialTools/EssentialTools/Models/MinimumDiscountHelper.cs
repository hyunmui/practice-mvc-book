using System;

namespace EssentialTools.Models
{
    /// <summary>
    ///  클래스 구현 목표
    ///  1. 합계가 $100을 초과하면 10% 할인율 적용
    ///  2. 합계가 $10에서 $100 사이면 $5의 할인율 적용
    ///  3. 합계가 $10 미만이면 할인율 미적용
    ///  4. 합계가 $0보다 작으면 ArgumentOutOfRangeException 예외 발생
    /// </summary>
    public class MinimumDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            if (totalParam < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (totalParam > 100)
            {
                return totalParam * 0.9M;
            }
            else if (totalParam >= 10 && totalParam <= 100)
            {
                return totalParam - 5;
            }
            else
            {
                return totalParam;
            }
        }
    }
}