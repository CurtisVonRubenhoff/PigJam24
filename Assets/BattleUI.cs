using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class BattleUI : MonoBehaviour
    {
        private List<GameObject> _spawnedButtons = new List<GameObject>();
        
        [SerializeField] private GameObject _playerAbilityButtonPrefab;
        [SerializeField] private Transform PlayerActionsParent;

        public void ShowPlayerActions(PlayerEntity i_player)
        {
            foreach (var ability in i_player.Abilities)
            {
                var button = Instantiate(_playerAbilityButtonPrefab, PlayerActionsParent);
                button.GetComponent<AbilityButton>().Setup(ability, i_player);
                _spawnedButtons.Add(button);
            }
        }

        public void HidePlayerActions(PlayerEntity i_player)
        {
            for (int i = i_player.Abilities.Count; i > 0; i--)
            {
                var button = _spawnedButtons[i];
                _spawnedButtons.Remove(button);
                Destroy(button);
            }
        }
    }
}