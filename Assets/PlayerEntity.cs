using UnityEngine.Events;

namespace DefaultNamespace
{
    public class PlayerEntity: Entity
    {
        private Ability selectedAbility;

        public UnityEvent<Ability> AbilitySelected;
        public UnityEvent<Entity> TargetSelected;

        private BattleUI _battleUI;
        
        public override void Activate()
        {
            base.Activate();
            
            AbilitySelected.AddListener(OnAbilitySelected);
            _battleUI =  FindObjectOfType<BattleUI>();
            _battleUI.ShowPlayerActions(this);
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
            _battleUI.HidePlayerActions(this);
        }

        private void OnTargetSelected(Entity i_target)
        {
            TargetSelected.RemoveListener(OnTargetSelected);

            Battle.UseAbilityOnTarget(this, i_target, selectedAbility);
        }
    }
}