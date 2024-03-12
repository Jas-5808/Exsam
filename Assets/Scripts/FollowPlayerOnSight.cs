using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerOnSight : MonoBehaviour
{
    private Player player; // ������ �� ������, ����������� ��������� IPlayer
    private NavMeshAgent _agent; // ������ �� ��������� NavMeshAgent
    public float detectionRange = 10f; // ���������� ����������� ������

    void Start()
    {
        // �������� ��������� NavMeshAgent � ������
        _agent = GetComponent<NavMeshAgent>();

        // ������� ������ ������ � �������� ������ �� ��� ��������� IPlayer
        player = FindObjectOfType<MonoBehaviour>().GetComponent<Player>();
    }

    void Update()
    {
        // ���������, ���������� �� ������ �� ������ � ��������� NavMeshAgent
        if (player != null && _agent != null)
        {
            // ���������, ����� �� ����� ������
            if (CanSeePlayer())
            {
                // ����� ����� ������, ������� �������� ��������� �� ���
                _agent.SetDestination(player.GetPlayerPosition());
            }
        }
    }

    bool CanSeePlayer()
    {
        // ���������� ����������� � ������
        Vector3 direction = player.GetPlayerPosition() - transform.position;
        float distanceToPlayer = direction.magnitude;

        // ���������, ��������� �� ����� � �������� ���� ����������� � �� ����� �� �� �������������
        if (distanceToPlayer <= detectionRange)
        {
            RaycastHit hit;

            // ��������� ������ ��������� �� ������
            if (Physics.Raycast(transform.position, direction.normalized, out hit, detectionRange))
            {
                // ���� �� ������ � ������, �� �� �����
                if (hit.transform == player.GetPlayerTransform())
                {
                    return true;
                }
            }
        }

        return false;
    }
}
