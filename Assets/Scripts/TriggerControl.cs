using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerControl : MonoBehaviour
{
    public static TriggerControl instance = null;
    GameObject triggerObject;
    public GameObject triggerOne, triggerTwo, triggerThree, triggerFour ,triggerFive ,triggerSix, triggerSeven ;
    public Image reloadImage, lifeBar, meshReturnBar;
    public Text incNumber;
    public Text lifeEnemyOne, lifeEnemyTwo, lifeEnemyThree, lifeEnemyFour, lifeEnemyFive, lifeEnemySix, lifeEnemySeven;
    public ParticleSystem cloud;
    public ParticleSystem lifeBarPlus;
    public float recoveryTime;
    Animator anim;
    bool meshChange = false;
    public bool isCompleted = false;
    public bool safe = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hide"))
        {
            meshChange = true;
            triggerObject = other.gameObject;
        }
        if (other.gameObject.CompareTag("Attack") && !gameObject.GetComponent<BoxCollider>().Equals(null))
        {
            safe = false;
            if (!gameObject.GetComponent<BoxCollider>().Equals(null))
            {
                cloud.Play();
            }

            gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = true;
            gameObject.GetComponent<Renderer>().enabled = false;

            if (gameObject.GetComponent<CapsuleCollider>().Equals(null))
            {
                gameObject.AddComponent<CapsuleCollider>();

                gameObject.GetComponent<CapsuleCollider>().height = 2;
                gameObject.GetComponent<CapsuleCollider>().radius = 0.5f;
                gameObject.GetComponent<CapsuleCollider>().center = new Vector3(0, 1, 0);
            }

            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(gameObject.GetComponent<MeshFilter>());
            meshReturnBar.gameObject.SetActive(false);
            Attack();
            StartCoroutine(other.gameObject.GetComponentInParent<AIController>().TakeDamage());
            meshChange = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hide"))
        {
            Debug.Log("MeshChange");
            meshChange = false;
            triggerObject = other.gameObject;
            reloadImage.fillAmount = 0;
        }
    }
    private void Update()
    {
        Reload();
        MeshChange();
        MeshPlayer();
        MeshReturn();
        LifeText();
    }
    void Reload()
    {
        reloadImage.transform.parent.rotation = Quaternion.Euler(0, gameObject.transform.rotation.y, 0);

        if (meshChange && gameObject.GetComponent<BoxCollider>().Equals(null))
        {
            reloadImage.fillAmount += Time.deltaTime / 3;
        }
        if (reloadImage.fillAmount == 1)
        {
            isCompleted = true;
            cloud.Play();
        }
        else
        {
            isCompleted = false;
        }
    }
    void MeshChange()
    {
        if (isCompleted && meshChange)
        {
            safe=true;
            gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = false;
            gameObject.AddComponent<MeshFilter>();
            gameObject.GetComponent<Renderer>().enabled = true;

            gameObject.GetComponent<MeshFilter>().mesh = triggerObject.GetComponentInParent<MeshFilter>().mesh;
            gameObject.GetComponent<Renderer>().material = triggerObject.GetComponentInParent<Renderer>().material;

            if (gameObject.GetComponent<BoxCollider>().Equals(null))
            {
                gameObject.AddComponent<BoxCollider>();
            }
            Destroy(gameObject.GetComponent<CapsuleCollider>());

            reloadImage.fillAmount = 0;
            meshReturnBar.fillAmount = 1;
            meshReturnBar.gameObject.SetActive(true);         
        }
    }
    void MeshReturn()
    {
        if (meshReturnBar.fillAmount == 0 && meshReturnBar.gameObject.activeInHierarchy)
        {
            meshChange = false;
            safe = false;
            if (!gameObject.GetComponent<BoxCollider>().Equals(null))
            {
                cloud.Play();
            }

            gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = true;
            gameObject.GetComponent<Renderer>().enabled = false;

            if (gameObject.GetComponent<CapsuleCollider>().Equals(null))
            {
                gameObject.AddComponent<CapsuleCollider>();

                gameObject.GetComponent<CapsuleCollider>().height = 2;
                gameObject.GetComponent<CapsuleCollider>().radius = 0.5f;
                gameObject.GetComponent<CapsuleCollider>().center = new Vector3(0, 1, 0);
            }

            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(gameObject.GetComponent<MeshFilter>());
            meshReturnBar.gameObject.SetActive(false);
        }
    }
    void MeshPlayer()
    {
        if (!gameObject.GetComponent<BoxCollider>().Equals(null))
        {
            meshReturnBar.fillAmount -= Time.deltaTime / recoveryTime;
        }
    }
    void Attack()
    {
        anim.SetTrigger("Attack");
    }
    void LifeText()
    {
        //if (!gameObject.GetComponent<BoxCollider>().Equals(null))
        //{
        //    if (triggerOne != null && lifeEnemyOne.gameObject != null && triggerOne.activeInHierarchy)
        //    {
        //        lifeEnemyOne.gameObject.SetActive(true);
        //        lifeEnemyOne.gameObject.transform.rotation = Quaternion.identity;
        //    }
        //    if (triggerTwo != null && lifeEnemyTwo.gameObject != null && triggerTwo.activeInHierarchy)
        //    {
        //        lifeEnemyTwo.gameObject.SetActive(true);
        //        lifeEnemyTwo.gameObject.transform.rotation = Quaternion.identity;
        //    }
        //    if (triggerThree != null && lifeEnemyThree.gameObject != null && triggerThree.activeInHierarchy)
        //    {
        //        lifeEnemyThree.gameObject.SetActive(true);
        //        lifeEnemyThree.gameObject.transform.rotation = Quaternion.identity;
        //    }
        //    if (triggerFour != null && lifeEnemyFour.gameObject != null && triggerFour.activeInHierarchy)
        //    {
        //        lifeEnemyFour.gameObject.SetActive(true);
        //        lifeEnemyFour.gameObject.transform.rotation = Quaternion.identity;
        //    }
        //    if (triggerFive != null && lifeEnemyFive.gameObject != null && triggerFive.activeInHierarchy)
        //    {
        //        lifeEnemyFive.gameObject.SetActive(true);
        //        lifeEnemyFive.gameObject.transform.rotation = Quaternion.identity;
        //    }
        //    if (triggerSix != null && lifeEnemySix.gameObject != null && triggerSix.activeInHierarchy)
        //    {
        //        lifeEnemySix.gameObject.SetActive(true);
        //        lifeEnemySix.gameObject.transform.rotation = Quaternion.identity;
        //    }
        //    if (triggerSeven != null && lifeEnemySeven.gameObject != null && triggerSeven.activeInHierarchy)
        //    {
        //        lifeEnemySeven.gameObject.SetActive(true);
        //        lifeEnemySeven.gameObject.transform.rotation = Quaternion.identity;
        //    }
            
        //}
        //else
        //{
        //    //lifeEnemyOne.gameObject.SetActive(false);
        //    //lifeEnemyTwo.gameObject.SetActive(false);
        //    //lifeEnemyThree.gameObject.SetActive(false);
        //    //lifeEnemyFour.gameObject.SetActive(false);
        //    //lifeEnemyFive.gameObject.SetActive(false);
        //    //lifeEnemySix.gameObject.SetActive(false);
        //    //lifeEnemySeven.gameObject.SetActive(false);
        //    Life(lifeEnemyOne);
        //    Life(lifeEnemyTwo);
        //    Life(lifeEnemyThree);
        //    Life(lifeEnemyFour);
        //    Life(lifeEnemyFive);
        //    Life(lifeEnemySix);
        //    Life(lifeEnemySeven);
        //}
        //if (!gameObject.GetComponent<BoxCollider>().Equals(null))
        //{
        //    if (AIController.ai.isDead)
        //    {
        //        Debug.Log("fjj");
        //        AIController.ai.kill.gameObject.SetActive(false);
        //    }
        //    else
        //    {
        //        Debug.Log("ser");
        //        AIController.ai.kill.gameObject.SetActive(true);
        //    }
        //}
        //else
        //{
        //    AIController.ai.kill.gameObject.SetActive(false);
        //}
        //if (AIController.ai.isDead)
        //{
        //    gameObject.transform.GetChild(6).gameObject.SetActive(false);
        //}
        //else
        //{
        //    if (!gameObject.GetComponent<BoxCollider>().Equals(null))
        //    {
        //        gameObject.transform.GetChild(6).gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        gameObject.transform.GetChild(6).gameObject.SetActive(false);
        //    }
        //}
    }
    void Life(Text life)
    {
        if (life != null)
        {
            life.gameObject.SetActive(false);
        }
    }
}
