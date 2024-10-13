using UnityEngine;

namespace DefaultNamespace
{
    public class CPUEntity: Entity
    {
        //[SerializeField] private EnemyUI targetButton;
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

        public override void EndTurn()
        {
            Battle.EndUnitTurn(true);
        }
    }
}