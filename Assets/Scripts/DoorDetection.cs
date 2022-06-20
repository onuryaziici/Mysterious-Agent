using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetection : MonoBehaviour
{
    [SerializeField] Animator anim = null;
    [SerializeField] bool openTrigger = false;
    [SerializeField] bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&&PlayerPrefs.GetInt("Enemies")==0)
        {
            GameObject.Find("door 1").GetComponent<MeshCollider>().enabled=false;
            if (openTrigger)
            {
                anim.Play("DoorOpen", 0, 0.0f);
                 gameObject.SetActive(false);
            }

           if (closeTrigger)
            {
                anim.Play("DoorClosed", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }

    }


}
