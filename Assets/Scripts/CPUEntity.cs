using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class CPUEntity: Entity
    {
        //[SerializeField] private EnemyUI targetButton;

        public UnityEvent<float> EnemyHealthUpdated = new UnityEvent<float>();
        public override void Activate()
        {
            base.Activate();
            var abilityIndex = _abilities.GetRandomIndex();
            Debug.Log(abilityIndex);
            var ability = _abilities[abilityIndex];
            var playerUnits = Battle.PlayerUnits;

            var target = playerUnits[playerUnits.GetRandomIndex()];

            Battle.UseAbilityOnTarget(this, target, ability);
        }

        public override void TakeDamage(float i_damage)
        {
            base.TakeDamage(i_damage);
            
            EnemyHealthUpdated.Invoke(health);
        }

        public override void EndTurn()
        {
            Battle.EndUnitTurn(true);
        }
    }
}