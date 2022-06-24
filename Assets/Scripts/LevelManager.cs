using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static LevelManager control;
    public float score;
   

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
        if (score - 1 == 0)
        {
            scoreText.text = "Intro";
        }
        else
        {
            scoreText.text = "Level: " + (score - 1).ToString();
        }
    }


}
    

