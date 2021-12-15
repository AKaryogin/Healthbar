using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _health;
    [SerializeField] private float _heal;
    [SerializeField] private float _damage;

    private Coroutine _currentCoroutine;
    private bool _isHeal = false;

    public void Heal()
    {
        if(_currentCoroutine != null && _isHeal == false)
        {
            StopCoroutine(_currentCoroutine);
            _isHeal = true;
        }

        if(_health.value < 100)
            _currentCoroutine = StartCoroutine(SetHealthUp(_heal));
    }

    public void Damage()
    {
        if(_currentCoroutine != null && _isHeal)
        {
            StopCoroutine(_currentCoroutine);
            _isHeal = false;
        }

        if(_health.value > 0)
            _currentCoroutine = StartCoroutine(SetHealthDown(_damage));
    }

    private IEnumerator SetHealthUp(float amountHealthPoint)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        for(int i = 0; i < amountHealthPoint; i++)
        {            
            _health.value += 1;
            yield return waitForSeconds;
        }
    }

    private IEnumerator SetHealthDown(float amountHealthPoint)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        for(int i = 0; i < amountHealthPoint; i++)
        {            
            _health.value -= 1;
            yield return waitForSeconds;
        }
    }
}
