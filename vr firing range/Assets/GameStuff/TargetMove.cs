using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    public bool bshouldMove,bshouldGoDown,bshouldMoveRandom;
    public float goDownTimer, popUpTimer;
    public float PopUpheight=4;
    // Start is called before the first frame update

    public float MinX, MaxX;
    public float Dir;
    public float speed;
    public bool TargetPoppedUp=false;
    public int isCorrect;//value of the target if 1= correct, 0 would mean not correct
    float localtimer;
    

    // Update is called once per frame
    void Update()
    {
        MoveTarget();
        popUpTimer -= Time.deltaTime;
        if(popUpTimer<=0&&!TargetPoppedUp)
        {
            
            PopUpTarget();
           
        }

        if (bshouldGoDown)
        {
            if (TargetPoppedUp)
            {
                goDownTimer -= Time.deltaTime;
                if (goDownTimer <= 0)
                {

                    GoDownTarget();

                }
            }
        }
        
    }
    public void PopUpTarget()
    {
        if (transform.position.y >= PopUpheight - 0.005)
        {

            TargetPoppedUp = true;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, PopUpheight, transform.position.z), Time.deltaTime * 10);
        }
    }

    public void GoDownTarget()
    {
        if (transform.position.y >= -1+0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -1, transform.position.z), Time.deltaTime * 10);
        }
        else
        {
            FindObjectOfType<TargetManager>().ResetTargets();
        }
    }
    public void MoveTarget()
    {
        if(bshouldMove)
        {
            if(bshouldMoveRandom)
            {
                if (localtimer <= 0)
                {
                    Dir = Random.Range(-1, 2);
                    localtimer = 1;
                }
                else
                {
                    localtimer -= Time.deltaTime;
                }
                if (transform.position.x<MinX)
                {
                    Dir = 1;
                }
                else if(transform.position.x>MaxX)
                {
                    Dir = -1;
                }


                transform.position = new Vector3(transform.position.x+Dir*speed*Time.deltaTime,transform.position.y,transform.position.z);
            }
            else
            {
               
                if (transform.position.x < MinX)
                {
                    Dir = 1;
                }
                else if (transform.position.x > MaxX)
                {
                    Dir = -1;
                }


                transform.position = new Vector3(transform.position.x + Dir * speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            TargetHit();
            

            Debug.Log("Bullet hit");
        }
    }
    public void TargetHit()
    {
        FindObjectOfType<TargetManager>().CheckHit(isCorrect);
    }
    public void resetValues()
    {
        popUpTimer = 3;
        TargetPoppedUp = false;
       
    }
}
