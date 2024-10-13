using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class PlayerEntity: Entity
    {
        private Ability selectedAbility;

        public static UnityEvent<Ability> AbilitySelected = new UnityEvent<Ability>();
        public static UnityEvent<Entity> TargetSelected = new UnityEvent<Entity>();

        private BattleUI _battleUI;

        public static UnityEvent<float> PlayerHealthUpdated = new UnityEvent<float>();
        
        public override void Activate()
        {
            base.Activate();
            
            AbilitySelected.AddListener(OnAbilitySelected);
            _battleUI =  FindObjectOfType<BattleUI>();
            _battleUI.ShowPlayerActions(this);
        }

        public override void TakeDamage(float i_damage)
        {
            base.TakeDamage(i_damage);
            
            PlayerHealthUpdated.Invoke(health);
        }

        public override void EndTurn()
        {
            Battle.EndUnitTurn(false);
        }

        public void OnAbilitySelected(Ability i_ability)
        {
            Debug.Log($"Player Selected {i_ability.AbilityName}");
            selectedAbility = i_ability;
            _battleUI.HidePlayerActions(this);
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