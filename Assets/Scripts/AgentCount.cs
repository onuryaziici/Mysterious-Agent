using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentCount : MonoBehaviour
{
    public static AgentCount instance;
    public Text agentCountText;
    public int agentCount, newAgentCount;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        agentCountText.text = "" + agentCount;
    }
    void Update()
    {
        //if (agentCount == 0)
        //{
        //    agentCountText.text = "" + newAgentCount;
        //}
    }
}
