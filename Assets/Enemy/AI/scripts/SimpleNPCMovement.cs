using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNPCMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // Скорость движения NPC
    private float distanceToMove = 3f; // Расстояние для движения

    private Vector3 initialPosition; // Начальная позиция NPC
    private bool isMoving = false; // Флаг, указывающий, двигается ли NPC в данный момент

    private float delayBeforeStart = 5f; // Задержка перед началом движения
    [SerializeField] private float timer = 0f; // Таймер для подсчета времени

    void Start()
    {
        initialPosition = transform.position; // Запоминаем начальную позицию NPC
    }

    void Update()
    {
        // Обновляем таймер
        timer += Time.deltaTime;

        // Проверяем, достиг ли таймер необходимой задержки
        if (timer >= delayBeforeStart && !isMoving)
        {
            // Если прошла задержка и NPC еще не движется, начинаем движение
            isMoving = true;
        }

        if (isMoving)
        {
            // Если NPC движется, продолжаем его движение
            float moveDistance = moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * moveDistance);

            // Проверяем, достиг ли NPC необходимого расстояния
            float currentDistance = Vector3.Distance(transform.position, initialPosition);
            if (currentDistance >= distanceToMove)
            {
                // Если NPC достиг необходимого расстояния, останавливаем его
                isMoving = false;
                transform.position = initialPosition + transform.forward * distanceToMove; // Устанавливаем точную позицию, чтобы избежать погрешности
            }
        }
    }
}
