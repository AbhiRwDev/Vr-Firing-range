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
    private float startpos =4000;    // The speed of the movement
    private float endpos = 1.0f;    // The speed of the movement
    
    public float movespeed;
    public bool Ismovingup = false;
    public float UpdownSpeed;
    public int ShouldMoveUp=0;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.localPosition.x;
       
        
        
        Bcontroller = FindAnyObjectByType<BaloonController>();
    }
    private void OnEnable()
    {
        SetupSpeeds();
    }
    public void SetupSpeeds()
    {
        if (startpos == 4000)
        {
            startpos = transform.localPosition.x;
        }
        transform.localPosition = new Vector3(startpos - movespeed / 2, transform.localPosition.y + Random.Range(-0.5f, 1.5f), transform.localPosition.z);
        UpdownSpeed = Random.Range(0.3f, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
        Ntext.text = number.ToString();   
       
        MoveLeftAndRight();
        
    }
   
    void MoveLeftAndRight()
    {/*
        if(transform.position.x<=startpos)
        {
            movespeed = -movespeed;
        }else if(transform.position.x >=endpos)
        {
            movespeed *= -1;
        }
*/
       // transform.localPosition += Vector3.right * movespeed * Time.deltaTime;
        transform.localPosition = new Vector3(transform.localPosition.x + (Mathf.Sin(Time.time) * movespeed * Time.deltaTime), transform.localPosition.y + (Mathf.Sin(Time.time)*UpdownSpeed*Time.deltaTime*ShouldMoveUp), transform.localPosition.z);
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            Bcontroller.EnterCombination(number);
            Bcontroller.PlayBalloonPop();
        }
    }
}
