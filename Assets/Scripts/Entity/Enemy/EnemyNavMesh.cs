using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private Transform hero;
    private Transform me;
    private NavMeshAgent navMeshAgent;

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
            navMeshAgent.destination = hero.position;
        else
            navMeshAgent.destination = me.position;
    }
}
