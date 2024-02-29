using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }
    public Transform GetPlayerTransform()
    {
        return transform;
    }
}
