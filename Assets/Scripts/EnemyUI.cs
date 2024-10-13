using System.Collections;
using System.Collections.Generic;
using CleverCrow.Fluid.Dialogues.Actions.GameObjects;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private CPUEntity enemy;
    [SerializeField] private TMP_Text enemyHealth;

    
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnEnable()
    {
        enemy.EnemyHealthUpdated.AddListener(OnHealthUpdated);
        enemyHealth.text = $"{enemy.health}";
    }

    private void OnHealthUpdated(float arg0)
    {
        if (arg0 > 1)
        {
            enemyHealth.text = $"{arg0}";
        }
        else
        {
            enemyHealth.text = "DEAD";
        }
    }

    private void OnDisable()
    {
        enemy.EnemyHealthUpdated.RemoveListener(OnHealthUpdated);

    }
    public void SelectTarget()
    {
        PlayerEntity.TargetSelected.Invoke(enemy);
    }
}
