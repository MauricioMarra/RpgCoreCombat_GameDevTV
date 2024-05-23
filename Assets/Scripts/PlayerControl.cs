using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private NavMeshAgent agentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        agentPlayer = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agentPlayer.SetDestination(target.transform.position);
        
    }
}
