using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static LevelManager control;
    float score = 1;
    public List<int> buildIndex = new List<int> { 1, 2, 3, 4 };
    int bossLevelIndex = 5;
    int random;

    private void Awake()
    {
        if (control == null)
        {
            control = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
        else
        {
            return;
        }    
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetFloat("Score",score);
        }
        else
        {
            score = PlayerPrefs.GetFloat("Score");
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        scoreText.text = "Level: " + (PlayerPrefs.GetFloat("Score")).ToString();
    }
    private void Update()
    {
        Debug.Log(!PlayerPrefs.HasKey("Score"));
        Debug.Log(score);
        Debug.Log(PlayerPrefs.GetFloat("Score"));
        scoreText.text = "Level: " + (PlayerPrefs.GetFloat("Score")).ToString();
    }
    public void LevelManage()
    {
        if (score != bossLevelIndex)
        {
            if (buildIndex.Contains(SceneManager.GetActiveScene().buildIndex))
            {
                buildIndex.Remove(SceneManager.GetActiveScene().buildIndex);
                random = Random.Range(0, buildIndex.Count);
                SceneManager.LoadScene(buildIndex[random]);
            }
            else
            {
                random = Random.Range(0, buildIndex.Count);
                SceneManager.LoadScene(buildIndex[random]);
            }
        }
        else if (score == bossLevelIndex)
        {
            buildIndex.Clear();
            SceneManager.LoadScene(5);
            buildIndex.Add(1);
            buildIndex.Add(2);
            buildIndex.Add(3);
            buildIndex.Add(4);
            bossLevelIndex += 5;
        }
    }
    public void ScoreInc()
    {
        score++;
        PlayerPrefs.SetFloat("Score", score);
    }
    public void SaveStart()
    {
        PlayerPrefs.SetFloat("Score", score);
    }
    public void SaveDie()
    {
        PlayerPrefs.SetFloat("Score", score);
    }
}
    

