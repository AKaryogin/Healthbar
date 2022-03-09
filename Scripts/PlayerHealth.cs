using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

    public event UnityAction<float> SetHealth;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    public void Heal(float heal = 10)
    {
        if(_health < 100)        
            _health += heal;

        if(_health > _maxHealth)
            _health = _maxHealth;

        SetHealth.Invoke(_health);
    }

    public void Damage(float damage = 10)
    {
        if(_health > 0)        
            _health -= damage;

        if(_health < 0)
            _health = 0;

        SetHealth.Invoke(_health);
    }
}
