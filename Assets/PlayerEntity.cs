using UnityEngine.Events;

namespace DefaultNamespace
{
    public class PlayerEntity: Entity
    {
        private Ability selectedAbility;

        public UnityEvent<Ability> AbilitySelected;
        public UnityEvent<Entity> TargetSelected;
        public override void Activate()
        {
            base.Activate();
            
            AbilitySelected.AddListener(OnAbilitySelected);
            
        }

        public override void EndTurn()
        {
            Battle.EndUnitTurn(true);
        }

        public void OnAbilitySelected(Ability i_ability)
        {
            selectedAbility = i_ability;
            AbilitySelected.RemoveListener(OnAbilitySelected);
            TargetSelected.AddListener(OnTargetSelected);
        }

        private void OnTargetSelected(Entity i_target)
        {
            TargetSelected.RemoveListener(OnTargetSelected);

            Battle.UseAbilityOnTarget(this, i_target, selectedAbility);
        }
    }
}