using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance = null;
    public float speedAmount=1f;
    public int maxHealth = 100;
    public int currentHealth;
    Animator anim;
    public bool isDie = false;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        //PlayerPrefs.SetFloat("Score", LevelManager.control.score);
        //LevelManager.control.scoreText.text = "Level: " + (PlayerPrefs.GetFloat("Score")).ToString();
        LevelManager.control.SaveStart();
    }



    public void TakeDamage(int damage)
    {
  
       Die();
        
    }
    void Die()
    {
        isDie = true;
        anim.SetBool("isDie", isDie);
        this.gameObject.GetComponent<JoystickControl>().enabled = false;
        Debug.Log("Player Died!");
        StartCoroutine(Restart());
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        //PlayerPrefs.SetFloat("Score", LevelManager.control.score);
        LevelManager.control.SaveDie();
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
