using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject CollisionParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void BulletForce(float force)
    {
        GetComponent<Rigidbody>().AddForce(transform.forward*force,ForceMode.VelocityChange);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.collider.CompareTag("Balloons"))
        {
            FindObjectOfType<BaloonController>().WrongHitIncrease();
        }
        Instantiate(CollisionParticle, transform.position,Quaternion.identity);
        Destroy(gameObject);
        
    }
}
