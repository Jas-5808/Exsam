using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public float rangeInPickUp = 1f;
    public float pickUpRange = 5f; // Максимальное расстояние для подбора предмета
    public Transform holdParent; // Точка, куда будет перемещаться поднятый объект
    public Camera playerCamera; // Камера игрока
    private GameObject heldObj; // Текущий поднятый объект

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                // Попытка поднять объект
                RaycastHit hit;
                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickUpRange))
                {
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ItemPick") && hit.collider.gameObject.GetComponent<Rigidbody>())
                    {
                        heldObj = hit.collider.gameObject;
                        PickUp();
                    }
                }
            }
            else
            {
                // Отпустить объект
                Drop();
            }
        }

    }

    void PickUp()
    {
        Rigidbody rb = heldObj.GetComponent<Rigidbody>();
        rb.isKinematic = true; // Отключаем физику для удерживаемого объекта, чтобы он не падал
                               // Расчет новой позиции на 1 единицу впереди от holdParent в направлении взгляда камеры
        Vector3 newPosition = holdParent.position + playerCamera.transform.forward * rangeInPickUp;
        heldObj.transform.parent = holdParent; // Делаем объект дочерним к точке удержания, чтобы он следовал за игроком
    }


    void Drop()
    {
        Rigidbody rb = heldObj.GetComponent<Rigidbody>();
        rb.isKinematic = false; // Включаем физику обратно
        heldObj.transform.parent = null; // Убираем объект из дочерних элементов, чтобы он больше не следовал за игроком
        heldObj = null; // Очищаем ссылку на поднятый объект
    }

    
}
