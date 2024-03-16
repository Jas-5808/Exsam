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
        // ��������� ������� ��� ������ �������
        StartFlashing();
    }

    void Update()
    {
        // ���������, ������ �� ������
        if (isFlashing)
        {
            // �������� ������������� ����� ������ ��� �������� ������� �������
            flashlightLight.intensity = Random.Range(minIntensity, maxIntensity);
        }
    }

    IEnumerator Flash()
    {
        while (isFlashing)
        {
            // �������� ������
            flashlightLight.enabled = true;
            // ���� ��������� �����
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            // ��������� ������
            flashlightLight.enabled = false;
            // ���� ��� ��������� ��������� �����
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }

    public void StartFlashing()
    {
        // �������� �������
        isFlashing = true;
        // ��������� �������� �������
        StartCoroutine(Flash());
    }

    public void StopFlashing()
    {
        // ��������� �������
        isFlashing = false;
        // ���������� ����������� ������������� �����
        flashlightLight.intensity = maxIntensity;
    }
}
