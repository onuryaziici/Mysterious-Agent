using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static LevelManager control;
    public int score;
   

    private void Awake()
    {
        if (control == null )
        {
            control = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
        
    }
    private void Update()
    {
        scoreText.text = "Level: " + score.ToString();
        Debug.Log(score);
    }


}
    

