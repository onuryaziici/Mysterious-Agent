using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetection : MonoBehaviour
{
    Quaternion targetAngle;
    [SerializeField] float openedDoorAngle;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        targetAngle = Quaternion.Euler(0, openedDoorAngle, 0);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, speed * Time.deltaTime);
        }
    }
}
