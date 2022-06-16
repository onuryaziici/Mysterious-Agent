using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject[] trapObjects;
    public GameObject trapObject;
    bool trap = false;
    float posY = 1;
    public void Start()
    {
       trapObject=Instantiate(trapObjects[Random.Range(0,3)],new Vector3(0,7,13), Quaternion.identity);
        trapObject.tag = "TrapObject";
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            trap = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            trap = false;
        }
    }
    private void Update()
    {
        if (trap)
        {
            posY = Mathf.Clamp(posY, 2, 8);
            gameObject.transform.localScale = new Vector3(2, posY, 2);
            posY -= Time.deltaTime;
        }
        if (gameObject.transform.localScale.y < 2.01f)
        {
            trapObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
