using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _health;
    [SerializeField] private PlayerHealth _playerHealth;

    private Coroutine _currentCoroutine;    

    private void OnEnable()
    {
        _playerHealth.SetHealth += OnSetHealth;
        _health.maxValue = _playerHealth.MaxHealth;
        _health.value = _playerHealth.Health;
    }

    private void OnDisable()
    {
        _playerHealth.SetHealth -= OnSetHealth;
    }

    public void OnSetHealth(float health)
    {
        if(_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(SetHealth(health));
    }

    private IEnumerator SetHealth(float healthPoint)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
        float differenceHealth = Mathf.Abs(_health.value - healthPoint);        

        for(int i = 0; i < differenceHealth; i++)
        {
            _health.value = Mathf.MoveTowards(_health.value, healthPoint, 1);            
            yield return waitForSeconds;
        }
    }

}
