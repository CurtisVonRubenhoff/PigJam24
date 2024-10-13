using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using DefaultNamespace;
using UnityEngine;

public class Battle : MonoBehaviour
{
    // Start is called before the first frame update

    public static Battle Instance;

    [SerializeField] private List<Entity> _playerUnits = new List<Entity>();
    [SerializeField] private List<Entity> _cpuUnits = new List<Entity>();

    private int currentPlayerUnitIndex = 0;
    private int currentCpuUnitIndex = 0;

    private bool battleRunning = false;

    public static List<Entity> PlayerUnits => Instance._playerUnits;

    public static List<Entity> CpuUnits => Instance._cpuUnits;

    void Start()
    {
        if (Battle.Instance is null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        var coinFlip = Random.Range(0, 1) > 0.5f;

        battleRunning = true;

        if (coinFlip)
        {
            PlayerGoesFirst();
        }

        {
            EnemyGoesFirst();
        }
    }

    private void EnemyGoesFirst()
    {
        currentCpuUnitIndex = 0;
        
        CpuTurn();
    }

    private void PlayerGoesFirst()
    {
        currentPlayerUnitIndex = 0;
        
        PlayerTurn();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ApplyAbility(Entity attacker, Entity i_target, Ability i_ability)
    {
        var amount = i_ability.GetEffect();
        
        i_target.TakeDamage(amount);
        attacker.EndTurn();
    }

    private void EndTurn(bool isCPU)
    {
        if (Instance.battleRunning)
        {
            if (isCPU)
            {
                currentCpuUnitIndex++;
                PlayerTurn();
            }
            else
            {
                currentPlayerUnitIndex++;
                CpuTurn();
            }
        }
        else
        {
            Debug.Log("Battle Ended");
        }
    }

    public static void EndUnitTurn(bool isCPU)
    {
        Instance.EndTurn(isCPU);
    }

    private void CpuTurn()
    {
        if (currentCpuUnitIndex > _cpuUnits.Count)
        {
            currentCpuUnitIndex = 0;
        }
        _cpuUnits[currentCpuUnitIndex].Activate();
    }

    private void PlayerTurn()
    {
        if (currentPlayerUnitIndex > _playerUnits.Count)
        {
            currentPlayerUnitIndex = 0;
        }

        var currentUnit = _playerUnits[currentPlayerUnitIndex];
        if (currentUnit.health < 1)
        {
            EndBattle();
            return;
        }
        _playerUnits[currentPlayerUnitIndex].Activate();
    }

    public static void UseAbilityOnTarget(Entity attacker, Entity i_target, Ability i_ability)
    {
        if (Instance == null)
        {
            Debug.LogError("Battle ain't around, buster.");
            return;
        }
        
        Debug.Log($"{attacker.name} used {i_ability.AbilityName} on {i_target.name}");
        Instance.ApplyAbility(attacker, i_target, i_ability);
    }

    public static void EndBattle()
    {
        Instance.battleRunning = false;
    }
}
