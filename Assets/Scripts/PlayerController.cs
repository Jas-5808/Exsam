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
        // Ќачинаем движение сразу при старте (это можно изменить по вашему усмотрению)
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
            // ѕеремещаем персонажа вперед
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // ќбновл€ем параметры анимации в аниматоре
        }*/
    }

    private void StartMoving()
    {
        // √енерируем случайное значение дл€ определени€ продолжительности движени€
        float moveDuration = Random.Range(1f, 3f);
        // «апускаем корутину дл€ временного останова и повторного запуска движени€
        StartCoroutine(MoveCoroutine(moveDuration));
    }

    //  орутина дл€ временного останова и повторного запуска движени€
    private System.Collections.IEnumerator MoveCoroutine(float duration)
    {
        // ќстанавливаем движение
        isMoving = false;
        animator.SetFloat("Speed", 0f);

        // ∆дем случайное врем€
        yield return new WaitForSeconds(duration);

        // √енерируем новое случайное направление
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, randomAngle, 0f);

        // Ќачинаем движение
        isMoving = true;
    }
}
