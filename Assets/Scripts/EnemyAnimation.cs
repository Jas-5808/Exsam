using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] _EnemyPrefab;
    [SerializeField] private NavMeshAgent _agent;
    private GameObject EnemyChild;
    
    private void Awake()
    {
        Animation();
        _agent.speed = EnemyChild.GetComponent<EnemyConfig>().GetSpeed();
    }
    void Animation()
    {
        EnemyChild = Instantiate(_EnemyPrefab[Random.Range(0, _EnemyPrefab.Length)], transform);
        Animator animator = EnemyChild.GetComponent<Animator>();
        EnemyChild.GetComponent<Animator>().SetFloat("Speed", 1f);
        
    }
}
