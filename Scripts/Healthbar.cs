using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _health;

    private Coroutine _currentCoroutine;
    private bool _isHeal = false;

    public void SetHealthPoint(float health)
    {
        float differenceHealth = health - _health.value;

        if(_currentCoroutine != null)
        {
            if(_isHeal)
            {
                StopCoroutine(_currentCoroutine);
                _isHeal = false;
            }
            else
            {
                StopCoroutine(_currentCoroutine);
                _isHeal = true;
            }
        }

        if(differenceHealth > 0)
        {
            _currentCoroutine = StartCoroutine(SetHealthUp(Mathf.Abs(differenceHealth)));
        }
        else
        {      
            _currentCoroutine = StartCoroutine(SetHealthDown(Mathf.Abs(differenceHealth)));
        }
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
