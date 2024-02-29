using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _Objects;
    [SerializeField] private GameObject[] _SpawnPoint;
    [SerializeField] private NavMeshAgent _agent;
    private Vector3 _position;
    void Start()
    {
        int i = 0;
        Animation();
       /* Movable(i);*/
    }
    private void FixedUpdate()
    {
        
    }

    void Animation()
    {
        GameObject EnemeChild = Instantiate(_Objects[Random.Range(0, _Objects.Length)], transform);
        Animator animator = EnemeChild.GetComponent<Animator>();
        if (animator != null)
        {
            EnemeChild.GetComponent<Animator>().SetFloat("Speed", 1f);
        }
    }
    void Movable(int i)
    {
       
        _agent.SetDestination(_SpawnPoint[i].transform.position);
    }
}
