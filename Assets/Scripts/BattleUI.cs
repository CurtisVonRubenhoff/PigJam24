using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class BattleUI : MonoBehaviour
    {
        private List<GameObject> _spawnedButtons = new List<GameObject>();
        
        [SerializeField] private GameObject _playerAbilityButtonPrefab;
        [SerializeField] private Transform PlayerActionsParent;

        [SerializeField] private TMP_Text _textBox;

        public static UnityEvent<string> BattleTextEvent = new UnityEvent<string>();

        private void OnEnable()
        {
            BattleTextEvent.AddListener(HandleBattleTextUpdate);
        }

        private void HandleBattleTextUpdate(string arg0)
        {
            _textBox.text = arg0;
        }

        private void OnDisable()
        {
            BattleTextEvent.RemoveListener(HandleBattleTextUpdate);
        }

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
            foreach (var ability in _spawnedButtons)
            {
               ability.SetActive(false);
            }
        }
    }
}