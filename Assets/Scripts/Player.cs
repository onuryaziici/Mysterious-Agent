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
        //if (LevelManager.control.buildIndex.Count - 1 == 0)
        //{
        //    PlayerPrefs.SetInt("Elemet One", LevelManager.control.buildIndex[LevelManager.control.buildIndex.Count - 1]);
        //}
        //else if (LevelManager.control.buildIndex.Count - 1 == 1)
        //{
        //    PlayerPrefs.SetInt("Elemet One", LevelManager.control.buildIndex[LevelManager.control.buildIndex.Count - 1]);
        //    PlayerPrefs.SetInt("Elemet Two", LevelManager.control.buildIndex[LevelManager.control.buildIndex.Count - 2]);
        //}
        //else if (LevelManager.control.buildIndex.Count - 1 == 2)
        //{
        //    PlayerPrefs.SetInt("Elemet One", LevelManager.control.buildIndex[LevelManager.control.buildIndex.Count - 1]);
        //    PlayerPrefs.SetInt("Elemet Two", LevelManager.control.buildIndex[LevelManager.control.buildIndex.Count - 2]);
        //    PlayerPrefs.SetInt("Elemet Three", LevelManager.control.buildIndex[LevelManager.control.buildIndex.Count - 3]);
        //}
        //else if (LevelManager.control.buildIndex.Count - 1 == 3)
        //{
        //    PlayerPrefs.SetInt("Elemet One", LevelManager.control.buildIndex[LevelManager.control.buildIndex.Count - 1]);
        //    PlayerPrefs.SetInt("Elemet Two", LevelManager.control.buildIndex[LevelManager.control.buildIndex.Count - 2]);
        //    PlayerPrefs.SetInt("Elemet Three", LevelManager.control.buildIndex[LevelManager.control.buildIndex.Count - 3]);
        //    PlayerPrefs.SetInt("Elemet Four", LevelManager.control.buildIndex[LevelManager.control.buildIndex.Count - 4]);
        //}
        //Debug.Log(PlayerPrefs.GetInt("Element One") + " " + PlayerPrefs.GetInt("Element Two") + "" +
        //          PlayerPrefs.GetInt("Element Three") + "" + PlayerPrefs.GetInt("Element Four
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
