using System;
using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class Effect
    {
        public enum EffectTarget
        {
            HEALTH
        }

        public EffectTarget _effectTarget;
        public float _potency;

    }
}