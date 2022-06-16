using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetection : MonoBehaviour
{
    [SerializeField] Animator anim = null;
    [SerializeField] bool openTrigger = false;
    [SerializeField] bool closeTrigger = false;


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (openTrigger)
            {
                anim.Play("DoorOpen", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (closeTrigger)
            {
                anim.Play("DoorClosed", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }

    }


}
