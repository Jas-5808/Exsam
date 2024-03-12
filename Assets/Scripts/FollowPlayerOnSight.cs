using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerOnSight : MonoBehaviour
{
    private Player player; // Ссылка на объект, реализующий интерфейс IPlayer
    private NavMeshAgent _agent; // Ссылка на компонент NavMeshAgent
    public float detectionRange = 10f; // Расстояние обнаружения игрока

    void Start()
    {
        // Получаем компонент NavMeshAgent у агента
        _agent = GetComponent<NavMeshAgent>();

        // Находим объект игрока и получаем ссылку на его компонент IPlayer
        player = FindObjectOfType<MonoBehaviour>().GetComponent<Player>();
    }

    void Update()
    {
        // Проверяем, существует ли ссылка на игрока и компонент NavMeshAgent
        if (player != null && _agent != null)
        {
            // Проверяем, видит ли агент игрока
            if (CanSeePlayer())
            {
                // Агент видит игрока, поэтому начинаем следовать за ним
                _agent.SetDestination(player.GetPlayerPosition());
            }
        }
    }

    bool CanSeePlayer()
    {
        // Определяем направление к игроку
        Vector3 direction = player.GetPlayerPosition() - transform.position;
        float distanceToPlayer = direction.magnitude;

        // Проверяем, находится ли игрок в пределах зоны обнаружения и не скрыт ли за препятствиями
        if (distanceToPlayer <= detectionRange)
        {
            RaycastHit hit;

            // Проверяем прямую видимость до игрока
            if (Physics.Raycast(transform.position, direction.normalized, out hit, detectionRange))
            {
                // Если мы попали в игрока, то он видим
                if (hit.transform == player.GetPlayerTransform())
                {
                    return true;
                }
            }
        }

        return false;
    }
}
