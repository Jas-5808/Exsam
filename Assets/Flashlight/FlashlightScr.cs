using UnityEngine;
using System.Collections;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] private Light flashlightLight;
    [SerializeField] private float minIntensity = 0.1f;
    [SerializeField] private float maxIntensity = 1f;
    [SerializeField] private float minOnTime = 0.1f;
    [SerializeField] private float maxOnTime = 1f;
    [SerializeField] private float minOffTime = 0.1f;
    [SerializeField] private float maxOffTime = 1f;
    [SerializeField] private float instability = 0.1f; // ƒобавлено значение нестабильности света

    private bool isFlashing = false;

    void Start()
    {
        StartFlashing();
    }

    void Update()
    {
        if (isFlashing)
        {
            // »змен€ем интенсивность света с учетом нестабильности
            float intensity = Random.Range(minIntensity, maxIntensity);
            intensity += Random.Range(-instability, instability);
            flashlightLight.intensity = Mathf.Clamp(intensity, minIntensity, maxIntensity);
        }
    }

    IEnumerator Flash()
    {
        while (isFlashing)
        {
            flashlightLight.enabled = true;
            yield return new WaitForSeconds(Random.Range(minOnTime, maxOnTime));
            flashlightLight.enabled = false;
            yield return new WaitForSeconds(Random.Range(minOffTime, maxOffTime));
        }
    }

    public void StartFlashing()
    {
        isFlashing = true;
        StartCoroutine(Flash());
    }

    public void StopFlashing()
    {
        isFlashing = false;
        flashlightLight.intensity = maxIntensity;
    }
}

