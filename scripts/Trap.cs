using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Trap : MonoBehaviour
{
    float timer = 8f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                Enemy enm = other.GetComponent<Enemy>();
                enm.TakeDmg(2);
                timer = 8f;
            }
          
        }
    }
}
