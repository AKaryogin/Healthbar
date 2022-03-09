using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _health;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _duration;

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

        _currentCoroutine = StartCoroutine(SetHealth(health, _duration));
    }

    private IEnumerator SetHealth(float healthPoint, float duration)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(duration);
        float differenceHealth = Mathf.Abs(_health.value - healthPoint);        

        for(int i = 0; i < differenceHealth; i++)
        {
            _health.value = Mathf.MoveTowards(_health.value, healthPoint, 1);            
            yield return waitForSeconds;
        }
    }

}
