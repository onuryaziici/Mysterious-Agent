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
    float bossLevelIndex = 5;
    int random;
    float mode;
    float level = 1;

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
        if (!PlayerPrefs.HasKey("Checkpoint"))
        {
            PlayerPrefs.SetFloat("Checkpoint", level);
        }
        else
        {
            level = PlayerPrefs.GetFloat("Checkpoint");
        }
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetFloat("Score", score);
        }
        else
        {
            score = PlayerPrefs.GetFloat("Score");
        }
        score = PlayerPrefs.GetFloat("Checkpoint");
        PlayerPrefs.SetFloat("Score", level);
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        scoreText.text = "Level: " + (PlayerPrefs.GetFloat("Checkpoint")).ToString();
        //scoreText.text = "Level: " + (PlayerPrefs.GetFloat("Score")).ToString();
    }
    private void Update()
    {
        Checkpoint();
        //Debug.Log(!PlayerPrefs.HasKey("Score"));
        Debug.Log(PlayerPrefs.GetFloat("Score"));
        //Debug.Log(PlayerPrefs.GetFloat("Score"));
        //scoreText.text = "Level: " + (PlayerPrefs.GetFloat("Score")).ToString();
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
    void Checkpoint()
    {
        mode = score % 5;
        level = score + 1 - mode;
        PlayerPrefs.SetFloat("Checkpoint", level);
        Debug.Log(PlayerPrefs.GetFloat("Checkpoint"));
    }
    public void ScoreInc()
    {
        score++;
        PlayerPrefs.SetFloat("Score", score);
    }
    public void SaveStart()
    {
        PlayerPrefs.SetFloat("Score", score);
        scoreText.text = "Level: " + (PlayerPrefs.GetFloat("Score")).ToString();
    }
    public void SaveDie()
    {
        PlayerPrefs.SetFloat("Score", score);
    }
}
    

