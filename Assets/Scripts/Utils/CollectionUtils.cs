using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utils
{
    public static class CollectionUtils
    {
        public static T WeightedRandom<T>(this IEnumerable<T> enumerable, Func<T, float> weightSelector)
        {
            var random = Random.Range(0, (int) enumerable.Sum(weightSelector));
            var weightSum = 0f;
            foreach (var item in enumerable)
            {
                var add = weightSelector.Invoke(item);
                weightSum += add;
                if (weightSum >= random)
                {
                    return item;
                }
            }

            throw new ArgumentException("Impossible error!");
        }
    }
}