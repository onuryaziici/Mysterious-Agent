using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorDetection : MonoBehaviour
{
    [SerializeField] Animator anim = null;
    [SerializeField] bool openTrigger = false;
    [SerializeField] bool closeTrigger = false;
    [SerializeField] Animator finishAnim;
    [SerializeField] int openEnemyCount, closeEnemyCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("Enemies")==openEnemyCount)
        {
            GameObject.Find("door 1").GetComponent<MeshCollider>().enabled=false;
            if (openTrigger)
            {
                anim.Play("DoorOpen", 0, 0.0f);
                 gameObject.SetActive(false);
                if (AgentCount.instance.agentCount == 0)
                {
                    AgentCount.instance.agentCount = AgentCount.instance.newAgentCount;
                    AgentCount.instance.agentCountText.text = "" + AgentCount.instance.agentCount;
                }
            }

           else if (closeTrigger && PlayerPrefs.GetInt("Enemies") == closeEnemyCount)
            {
                anim.Play("DoorClosed", 0, 0.0f);
                StartCoroutine(WaitForNextScene());
                //gameObject.SetActive(false);
                finishAnim.SetTrigger("Finish");
            }
        }
    }
    IEnumerator WaitForNextScene()
    {
        yield return new WaitForSeconds(1.5f);
        //LevelManager.control.score += 0.5f;
        //PlayerPrefs.SetFloat("Score", LevelManager.control.score);
        LevelManager.control.ScoreInc();
        //float score = PlayerPrefs.GetFloat("Score");
        //score++;
        //if (LevelManager.control.score > 0 && LevelManager.control.score < 6)
        //{
        //    //for (int i = 1; i < 6; i++)
        //    //{
        //    //    if (SceneManager.GetActiveScene().buildIndex != i)
        //    //    {
        //    //        SceneManager.LoadScene(Random.Range(i, 5));
        //    //    }
        //    //}
        //}
        LevelManager.control.LevelManage();
    }


}
