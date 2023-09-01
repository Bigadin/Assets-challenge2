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
    public float TimebtwAttack;
    [HideInInspector] public NavMeshAgent agent;
    public Transform theTarget;
    public bool CanAttack;
    SpawningSolders ss;
    // Timer

    float timerAttack = 1f;
    private void Start()
    {
        ss = GameObject.FindObjectOfType<SpawningSolders>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (CanAttack && theTarget!= null)
        {
            transform.LookAt(new Vector3(theTarget.position.x,theTarget.position.y,theTarget.position.z));
            float dist = Vector3.Distance(transform.position, theTarget.position);
            if(dist <= distanceAttack)
            {
                timerAttack -= Time.deltaTime;
                if(timerAttack < 0f)
                {
                    Attack();
                    timerAttack = TimebtwAttack;
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
            if(agent != null) 
                agent.isStopped = true;
            ss.solderSpawned.Remove(gameObject.GetComponent<Solder>());
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
