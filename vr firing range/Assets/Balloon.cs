using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Balloon : MonoBehaviour
{
    public int number=0;
    public TextMeshPro Ntext;
    private BaloonController Bcontroller;
    // Start is called before the first frame update
    void Start()
    {
        Bcontroller = FindAnyObjectByType<BaloonController>();
    }

    // Update is called once per frame
    void Update()
    {
        Ntext.text = number.ToString();   
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            Bcontroller.EnterCombination(number);
        }
    }
}
