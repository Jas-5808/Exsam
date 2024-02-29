using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Camera _camera;

    ///
    public float moveSpeed = 3f;
    private Animator animator;
    private bool isMoving = true;
    void Start()
    {
        
        animator = GetComponentInChildren<Animator>();
        // �������� �������� ����� ��� ������ (��� ����� �������� �� ������ ����������)
        /*StartMoving();*/

    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _agent.SetDestination(hit.point);
                animator.SetFloat("Speed", 1f);
            }

        }
       /* if (isMoving)
        {
            // ���������� ��������� ������
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // ��������� ��������� �������� � ���������
        }*/
    }

    private void StartMoving()
    {
        // ���������� ��������� �������� ��� ����������� ����������������� ��������
        float moveDuration = Random.Range(1f, 3f);
        // ��������� �������� ��� ���������� �������� � ���������� ������� ��������
        StartCoroutine(MoveCoroutine(moveDuration));
    }

    // �������� ��� ���������� �������� � ���������� ������� ��������
    private System.Collections.IEnumerator MoveCoroutine(float duration)
    {
        // ������������� ��������
        isMoving = false;
        animator.SetFloat("Speed", 0f);

        // ���� ��������� �����
        yield return new WaitForSeconds(duration);

        // ���������� ����� ��������� �����������
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, randomAngle, 0f);

        // �������� ��������
        isMoving = true;
    }
}
