// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace polyglots.practice._2022
// {
//     public class RatioStrategy : IStrategy
//     {
//         int ratio;

//         public RatioStrategy(int ratio)
//         {
//             this.ratio = ratio;
//         }
//         public string GetPizza(CustomerDictionary customerDictionary)
//         {
//             var onlyLikes = customerDictionary.ToppingsRatio(ratio);

//             return $"{onlyLikes.Count()} {string.Join(' ', onlyLikes)}";
//         }
//     }
// }