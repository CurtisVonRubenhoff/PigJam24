using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    [SerializeField] private Button button;

    private Entity usingEntity;

    private Ability _ability;
    // Start is called before the first frame update

    public void Setup(Ability i_ability, Entity i_entity)
    {
        label.text = i_ability.AbilityName;
        usingEntity = i_entity;
        _ability = i_ability;

        button.onClick.AddListener(UseAbility);
    }

    public void UseAbility()
    {
        if (usingEntity is PlayerEntity playerEntity)
        {
            playerEntity.AbilitySelected.Invoke(_ability);
        }
}

}
