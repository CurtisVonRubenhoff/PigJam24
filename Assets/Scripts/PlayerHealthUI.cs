using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    // Start is called before the first frame update
    void Start()
    {
        PlayerEntity.PlayerHealthUpdated.AddListener(OnPlayerHealthUpdated);
    }

    private void OnPlayerHealthUpdated(float arg0)
    {
        if (arg0 >= 1.0f)
        {
            _text.text = $"{arg0}";
        }
        else
        {
            _text.text = "DEAD";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
