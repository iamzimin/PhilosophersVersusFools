using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private Transform hero;
    public Transform me;
    public NavMeshAgent navMeshAgent;

    public bool isPause = false;

    private void Awake()
    {
        hero = FindObjectOfType<Hero>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        me = GetComponent<Transform>();
    }
    private void Update()
    {
        if (hero != null && !isPause)
        {
            navMeshAgent.enabled = true;
            navMeshAgent.destination = hero.position;
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }
}
