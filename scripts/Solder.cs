using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Solder : MonoBehaviour
{
    public float health;
    public float distanceAttack;
    public float dmg;
    [HideInInspector] public NavMeshAgent agent;
    public Transform theTarget;
    public bool CanAttack;

    // Timer

    float timerAttack = 1f;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (CanAttack && theTarget!= null)
        {
            transform.LookAt(new Vector3(theTarget.position.x,transform.position.y,theTarget.position.z));
            float dist = Vector3.Distance(transform.position, theTarget.position);
            if(dist <= distanceAttack)
            {
                timerAttack -= Time.deltaTime;
                if(timerAttack < 0f)
                {
                    Attack();
                    timerAttack = .75f;
                }
            }

            if(theTarget == null)
            {
                CanAttack = false;
            }
        }
        
        
    }
    public void TakeDmg(float dmg)
    {
        if (health - dmg <= 0)
        {
            agent.isStopped = true;
            Destroy(gameObject,0.1f);
        }
        else
        {
            health -= dmg;
        }
    }
    public virtual void Attack()
    {

    }

}
