using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Healthbar _healthbar;

    private void Start()
    {
        _healthbar.SetHealthPoint(_health);
    }

    public void ApplyHeal(float heal = 10)
    {
        if(_health < 100)
        {
            _health += heal;
            _healthbar.SetHealthPoint(_health);
        }
    }

    public void ApplyDamage(float damage = 10)
    {
        if(_health > 0)
        {
            _health -= damage;
            _healthbar.SetHealthPoint(_health);
        }
    }
}
