using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private Light flashlightLight;
    [SerializeField] private float minIntensity = 0.1f;
    [SerializeField] private float maxIntensity = 1f;
    [SerializeField] private float minDelay = 0.1f;
    [SerializeField] private float maxDelay = 1f;

    private bool isFlashing = false;

    void Start()
    {
        // Запускаем мигание при старте скрипта
        StartFlashing();
    }

    void Update()
    {
        // Проверяем, мигает ли фонарь
        if (isFlashing)
        {
            // Изменяем интенсивность света фонаря для создания эффекта мигания
            flashlightLight.intensity = Random.Range(minIntensity, maxIntensity);
        }
    }

    IEnumerator Flash()
    {
        while (isFlashing)
        {
            // Включаем фонарь
            flashlightLight.enabled = true;
            // Ждем случайное время
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            // Выключаем фонарь
            flashlightLight.enabled = false;
            // Ждем еще некоторое случайное время
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }

    public void StartFlashing()
    {
        // Включаем мигание
        isFlashing = true;
        // Запускаем корутину мигания
        StartCoroutine(Flash());
    }

    public void StopFlashing()
    {
        // Отключаем мигание
        isFlashing = false;
        // Возвращаем стандартную интенсивность света
        flashlightLight.intensity = maxIntensity;
    }
}
