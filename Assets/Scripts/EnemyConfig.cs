using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConfig : MonoBehaviour
{   
    [SerializeField] private int Id;
    [SerializeField] private string Name;
    [SerializeField] private float Speed;
    [SerializeField] private float Flashing;
    private void Start()
    {
        
    }
    public float GetSpeed()
    {
        return Speed;
    }

    
}
