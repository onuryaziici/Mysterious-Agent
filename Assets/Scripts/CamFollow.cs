using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject player;
    Vector3 offset = new Vector3(0, 15, -10);
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime * 5);
    }
}
