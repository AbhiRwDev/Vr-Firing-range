using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spheremaker : MonoBehaviour
{
    public GameObject sphere;
    public int noojspheres;
    public int total;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            for (int i = 0; i < noojspheres; i++)
            {
                Instantiate(sphere, transform.position, Quaternion.identity);
                total++;
            }
            
        }
    }
}
