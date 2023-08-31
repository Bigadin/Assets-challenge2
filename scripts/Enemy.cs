using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public float health;
    NavMeshAgent EnAgent;
    [SerializeField] Transform Base;
    [SerializeField] Transform TheTarget;


    // Timer
    float timerAttack = 3f;
    private void Start()
    {
        EnAgent = GetComponent<NavMeshAgent>();
        TheTarget = Base;
    }
    private void Update()
    {
        if(TheTarget != null) 
        EnAgent.SetDestination(TheTarget.position);
        else
            EnAgent.SetDestination(Base.position);
        
    }
    public void TakeDmg(float dmg)
    {
        if(health - dmg <= 0)
        {
            EnAgent.isStopped = true;
            Destroy(gameObject,0.1f);
        }
        else
        {
            transform.position -= transform.forward * 1.5f;
            health -= dmg;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Solder>())
        {
            float dist = Vector3.Distance(transform.position, other.transform.position);
            if (dist <= 3f)
            {


                TheTarget = other.transform;
                if (dist <= 2f)
                {

                    timerAttack -= Time.deltaTime;
                    if(timerAttack <= 0)
                    {
                        other.GetComponent<Solder>().TakeDmg(0.25f);
                        timerAttack = 3f;
                    }

                }
            }

        }
    }
}
