using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class Ability
    {
        public string AbilityName;
        public List<Effect> _effects = new List<Effect>();

        public float GetEffect()
        {
            return _effects.Sum(effect => effect._potency);
        }
    }
}