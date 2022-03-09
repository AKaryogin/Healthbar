using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

    private const float MinHealth = 0;

    public event UnityAction<float> SetHealth;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    public void Heal(float heal = 10)
    {
        if(_health < _maxHealth)        
            _health += heal;

        if(_health > _maxHealth)
            _health = _maxHealth;

        SetHealth.Invoke(_health);
    }

    public void Damage(float damage = 10)
    {
        if(_health > MinHealth)        
            _health -= damage;

        if(_health < MinHealth)
            _health = MinHealth;

        SetHealth.Invoke(_health);
    }
}
