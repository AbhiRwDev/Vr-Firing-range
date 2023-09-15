using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Balloon : MonoBehaviour
{
    public int number=0;
    public TextMeshPro Ntext;
    private BaloonController Bcontroller;

    public float moveDistance = 0.5f;  // The distance to move left and right
    private float startpos = 1.0f;    // The speed of the movement
    private float endpos = 1.0f;    // The speed of the movement
    
    public float movespeed;
    private bool isMovingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x-moveDistance;
        endpos = transform.position.x+ moveDistance;
        Bcontroller = FindAnyObjectByType<BaloonController>();
    }

    // Update is called once per frame
    void Update()
    {
        Ntext.text = number.ToString();   
        switch(Bcontroller.Level)
        {
            case 1:

                break;
            case 2:
               
                moveDistance = 3;
                MoveLeftAndRight();
                break;
            
        }
    }
    void MoveLeftAndRight()
    {
        if(transform.position.x<=startpos)
        {
            movespeed = -movespeed;
        }else if(transform.position.x >= startpos + moveDistance)
        {
            movespeed *= -1;
        }
        transform.localPosition += Vector3.right * movespeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            Bcontroller.EnterCombination(number);
        }
    }
}
