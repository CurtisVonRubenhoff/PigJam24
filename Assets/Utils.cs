using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Utils
    {
        public static int GetRandomIndex(this ICollection i_list)
        {
            return Random.Range(0, i_list.Count);
        }
    }
}