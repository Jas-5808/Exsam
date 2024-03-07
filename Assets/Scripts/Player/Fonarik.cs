using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fonarik : MonoBehaviour
{
    public GameObject Light;
    public bool onLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (onLight == false)
            {
                Light.SetActive(true);
                onLight = true;
            }
            else
            {
                Light.SetActive(false);
                onLight = false;
            }
        }

    }
}
