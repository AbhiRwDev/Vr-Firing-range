using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedBullets : MonoBehaviour
{
    public int Misses;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            Misses += 1;
        }
    }
    public void ResetMisses()
    {
        Misses = 0;
    }
}
