using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float health;
    public string name;
    
    public int strength = 0;
    public int wisdom = 0;
    public int endurance = 0;
    public int luck = 0;

    [SerializeField] protected List<Ability> _abilities = new List<Ability>();

    public List<Ability> Abilities => _abilities;

    public void TakeDamage(float i_damage)
    {
        Debug.Log($"{name} takes {i_damage} damage");
        health -= i_damage;

        Debug.Log($"Current health is {health}");
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{name} has died");
    }

    public virtual void Activate()
    {
        
    }

    public virtual void EndTurn()
    { 
    }
}
