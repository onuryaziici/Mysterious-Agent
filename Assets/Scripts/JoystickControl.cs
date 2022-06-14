using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickControl : MonoBehaviour
{
    public DynamicJoystick dynamic;
    public GameObject background;

    float moveSpeed = 5;
    float turnSpeed = 5;

    private Animator playerAnim;
    void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            Joystick();
        }
        AnimatorControl();
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
    void AnimatorControl()
    {
        if (background.gameObject.activeInHierarchy)
        {
            playerAnim.SetFloat("Walk", 2);
        }
        else
        {
            playerAnim.SetFloat("Walk", 1);
        }
    }
}
