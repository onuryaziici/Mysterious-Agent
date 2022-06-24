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
        LevelManager.control.score += 0.5f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
