using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archers : Solder
{
    [SerializeField] GameObject bullet;
    public override void Attack()
    {
        base.Attack();
        GameObject bul = Instantiate(bullet,transform.position, Quaternion.identity);
        Rigidbody bulRb =  bul.AddComponent<Rigidbody>();
        bul.name = "bullet";
        bulRb.AddForce(transform.forward * 50f, ForceMode.Impulse);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            CanAttack = true;
            theTarget = other.transform;
        }
    }
}

