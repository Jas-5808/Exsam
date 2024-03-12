using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;


public class AIPatrol : MonoBehaviour
{
    public List<Transform> checkpoints;
    private NavMeshAgent agent;
    private int currentCheckpointIndex = -1;
    private FieldOfView vision;
   

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        vision = GetComponent<FieldOfView>();

        if (checkpoints.Count > 0)
        {
            currentCheckpointIndex = Random.Range(0, checkpoints.Count);
            SetDestinationToNextCheckpoint();
        }
        
    }

    void Update()
    {
    
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending && !vision.canSeePlayer)
        {
           
            SetDestinationToNextCheckpoint();
            
        }
        if(vision.canSeePlayer)
        {
            Hunt();
        }
        
    }

    void SetDestinationToNextCheckpoint()
    {
        // Увеличиваем индекс чекпоинта и переходим к следующему, либо выбираем случайный чекпоинт
        if (checkpoints.Count > 1)
        {
            int nextIndex = Random.Range(0, checkpoints.Count);
            while (nextIndex == currentCheckpointIndex)
            {
                nextIndex = Random.Range(0, checkpoints.Count);
            }
            currentCheckpointIndex = nextIndex;
        }
        else
        {
            currentCheckpointIndex = 0;
        }

        // Устанавливаем пункт назначения агента к следующему чекпоинту
        agent.SetDestination(checkpoints[currentCheckpointIndex].position);
    }

    void Hunt()
    {
        agent.SetDestination(vision.playerPosition.position);
    }
}

