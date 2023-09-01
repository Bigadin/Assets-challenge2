using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archers : Solder
{
    [SerializeField] GameObject bullet;
    List<Enemy> enemyList;
    public override void Attack()
    {
        base.Attack();
        GameObject bul = Instantiate(bullet,transform.position, Quaternion.identity);
        Rigidbody bulRb =  bul.AddComponent<Rigidbody>();
        bulRb.useGravity = false;
        bul.name = "bullet";
        bulRb.constraints = RigidbodyConstraints.FreezeRotation;
        bulRb.AddForce(transform.forward * 20f, ForceMode.Impulse);
        Destroy(bul, 3.2f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
           // enemyList.Add(other.GetComponent<Enemy>());
            CanAttack = true;
            theTarget = other.transform;
        }
    }
}

