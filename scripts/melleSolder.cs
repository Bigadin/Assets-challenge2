using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melleSolder : Solder
{


    public override void Attack()
    {
        base.Attack();
        if(theTarget != null) 
            theTarget.GetComponent<Enemy>().TakeDmg(dmg);
    }
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            CanAttack = true;
            theTarget = other.transform;
            agent.SetDestination(other.transform.position);
        }
    }
}
