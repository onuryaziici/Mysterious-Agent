using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speedAmount=1f;
    public int maxHealth = 100;
    public int currentHealth;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }


    
    public void TakeDamage(int damage)
    {
  
        currentHealth -=damage;

        if(currentHealth<=0)
        {
            currentHealth=0;
            Die();
        }
    }
    void Die()
    {
       
        anim.SetBool("isDie", true);
        this.gameObject.GetComponent<JoystickControl>().enabled = false;
        Debug.Log("Player Died!");
    }
    
}
