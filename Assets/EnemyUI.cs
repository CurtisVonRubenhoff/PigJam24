using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private CPUEntity enemy;

    
    // Start is called before the first frame update

    // Update is called once per frame
    public void SelectTarget()
    {
        PlayerEntity.TargetSelected.Invoke(enemy);
    }
}
