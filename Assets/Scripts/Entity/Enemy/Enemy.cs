using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : Entity
{
    public Image healthBar;
    public bool isDead = false;
    public double time = 0f;
    public double timer = 5f;

    public Animator animator;
    public Rigidbody rigidbody;
    public EnemyNavMesh agent;

    [Header("Statistics")]
    public GameObject statisticsManagerGameObject;
    public StatisticsManager statisticsManager;

    [Header("Sounds")]
    private SoundEffects playSound;

    public override void GetDamage(int amountDamage)
    {
        playSound = GameObject.FindGameObjectWithTag("SOUND_EFFECTS_TAG").GetComponent<SoundEffects>();
        playSound.PlaySound("book_hit");

        healhPoint -= amountDamage;
        ChangeHealth();
        if (healhPoint <= 0)
            isDead = true;
    }

    public override void Die()
    {
        statisticsManagerGameObject = GameObject.FindGameObjectWithTag("Player");
        statisticsManager = statisticsManagerGameObject.GetComponent<StatisticsManager>();
        if (statisticsManager != null)
            statisticsManager.killedFools += 1;
        base.Die();
    }

    public void ChangeHealth()
    {
        healthBar.fillAmount = (float)healhPoint / maxHealhPoint;
    }

    public void UpgradeParametrs(int damage, int hp)
    {
        base.power += damage;
        healhPoint += hp;
        maxHealhPoint = healhPoint;
    }
/*
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<EnemyNavMesh>();
    }*/

    private void Update()
    {
        if (isDead && timer > time)
        {
            if (time == 0f)
            {/*
                //Collider collider = transform.GetChild(1).GetComponent<Collider>();
                //collider.enabled = false;
                agent.navMeshAgent.isStopped = true;
                //agent.navMeshAgent.destination = agent.me.position;
                animator.enabled = false;
                rigidbody.freezeRotation = false;
                //rigidbody.AddForce(this.transform.position * 5, ForceMode.Impulse);
                //rigidbody.AddForce(new Vector3(0, 90, 0) * 30, ForceMode.Impulse);
                //rigidbody.AddForce(transform.up * 5, ForceMode.Impulse);*/
                power = 0; 
                animator.enabled = false;
                rigidbody.freezeRotation = false;
                Canvas canvas = transform.GetChild(0).GetComponent<Canvas>();
                canvas.enabled = false;
                rigidbody.AddForce(this.transform.position * 0.5f, ForceMode.Impulse);
                gameObject.GetComponent<EnemyNavMesh>().enabled = false;
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
            }
            time += Time.deltaTime;
        }
        else if (timer < time)
        {
            Die();
        }
    }
}
