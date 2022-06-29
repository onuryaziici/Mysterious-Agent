using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoystickControl : MonoBehaviour
{
    public static JoystickControl instance = null;
    public DynamicJoystick dynamic;
    public GameObject background;

    float moveSpeed = 5;
    float turnSpeed = 5;

    public Animator playerAnim;

    bool move;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        move = true;
    }
    void FixedUpdate()
    {
        MoveLimit();
        if (Input.GetButton("Fire1") && move)
        {
            Joystick();
        }
    }
    void Joystick()
    {
        float horizontal = dynamic.Horizontal;
        float vertical = dynamic.Vertical;
        Vector3 addesPos = new Vector3(x: horizontal * Time.deltaTime * moveSpeed, y: 0, z: vertical * Time.deltaTime * moveSpeed);
        transform.position += addesPos;

        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        transform.rotation = Quaternion.Slerp(a: transform.rotation, b: Quaternion.LookRotation(direction), t: turnSpeed * Time.deltaTime);
    }
    void MoveLimit()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (transform.position.z > 19)
            {
                move = false;
            }
            //float forward = Mathf.Clamp(transform.position.z, -21, 19);
            //transform.position = new Vector3(transform.position.x, transform.position.y, forward);
        }
        else
        {
            if (transform.position.z > 61)
            {
                move = false;
            }
            //float forwardPos = Mathf.Clamp(transform.position.z, -21, 61);
            //transform.position = new Vector3(transform.position.x, transform.position.y, forwardPos);
        }
    }
}
