using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GunController : MonoBehaviour
{
    // Reference to the Oculus Quest controller
    public OVRInput.Controller controller;
    public float FireDelay;
    public bool bCanShoot=true;
    public GameObject Bullet;
    public float speed;
    
    public Transform ShootPoint;
    public GameObject MuzzelFlash;

   
    public OVRInput.Button shootButton;
    public float fireRate = 0.5f;  // Adjust the fire rate as desired
    private OVRGrabbable grabbable;
  /*  private AudioSource audioS;*/
    private bool isShooting = false;
    private float nextShotTime = 0f;
    public bool isAutomatic = false;

    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
       /* audioS = GetComponent<AudioSource>();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (isAutomatic)
        {
            if (grabbable.isGrabbed)
            {
                if (OVRInput.GetDown(shootButton, grabbable.grabbedBy.GetController()))
                {
                    isShooting = true;
                }
                else if (OVRInput.GetUp(shootButton, grabbable.grabbedBy.GetController()))
                {
                    isShooting = false;
                }
            }

            if (isShooting && Time.time >= nextShotTime)
            {
                ShootGun();
                //audioS.Play();
                nextShotTime = Time.time + 1f / fireRate;  // Calculate the next shot time based on fire rate
            }
        }
        else
        {
            if (grabbable.isGrabbed && OVRInput.GetDown(shootButton, grabbable.grabbedBy.GetController()))
            {
                ShootGun();
                //audioS.Play();
            }
        }

    }



    private void ShootGun()
    {
        // Add your gun shooting logic here
        Debug.Log("Gun fired!");
      
           
         
            GameObject b = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        b.GetComponent<BulletScript>().BulletForce(speed);
        GetComponent<RevolverController>().HammerStrike();
        MuzzelFlash.SetActive(true);
        
        // Example: Instantiate a bullet or perform shooting animation
        // Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
    
}
