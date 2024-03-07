using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashing : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;
    EnemyConfig enemyConfig;
    bool flag = true;
    private void Awake()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        enemyConfig = GetComponentInParent<EnemyConfig>();
    }
    private void Start()
    {
        StartCoroutine(Flash());
        
    }

    private IEnumerator Flash()
    {
        WaitForSeconds wait = new WaitForSeconds(enemyConfig.Flashing());
        while (true)
        {
            yield return wait;
            if (flag)
            {
                meshRenderer.enabled = false;
                flag = false;
            }
            else
            {
                meshRenderer.enabled = true;
                flag = true;
            }
            Debug.Log("hello");
        }
    }
}
