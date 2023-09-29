using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableUi : MonoBehaviour
{
    public enum ButtonType
    {
        Startbutton,
        sound1,
        sound2,
        sound3,
        Mute,
        Levelinc,
        Leveldec
    }
    public ButtonType buttontype;
    public BaloonController bc;
    public MeshRenderer mrendered;
    public GameObject Levelselector;
    private void Start()
    {
        bc = FindAnyObjectByType<BaloonController>();
    }
    private void Update()
    {
        switch (buttontype)
        {
           
            case ButtonType.sound1:
                if(bc.sclip==0)
                {
                    mrendered.GetComponent<MeshRenderer>().material = bc.yesMat;
                }
                else
                {
                    mrendered.GetComponent<MeshRenderer>().material = bc.Unmat;
                }
                break;
            case ButtonType.sound2:
                if (bc.sclip == 1)
                {
                    mrendered.GetComponent<MeshRenderer>().material = bc.yesMat;
                }
                else
                {
                    mrendered.GetComponent<MeshRenderer>().material = bc.Unmat;
                }
                break;
            case ButtonType.sound3:
                if (bc.sclip == 2)
                {
                    mrendered.GetComponent<MeshRenderer>().material = bc.yesMat;
                }
                else
                {
                    mrendered.GetComponent<MeshRenderer>().material = bc.Unmat;
                }
                break;
            case ButtonType.Mute:
                if (bc.sclip == 3)
                {
                    mrendered.GetComponent<MeshRenderer>().material = bc.yesMat;
                }
                else
                {
                    mrendered.GetComponent<MeshRenderer>().material = bc.Unmat;
                }
                break;

        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Bullet"))
        {
            switch(buttontype)
            {
                case ButtonType.Startbutton:
                    FindObjectOfType<BaloonController>().StartPlayThrough();
                    transform.parent.gameObject.SetActive(false);
                    Levelselector.SetActive(false);
                    break;
                case ButtonType.sound1:
                    bc.PlaySound(0);
                    break;
                case ButtonType.sound2:
                    bc.PlaySound(1);
                    break;
                case ButtonType.sound3:
                    bc.PlaySound(2);
                    break;
                case ButtonType.Mute:
                    bc.PlaySound(3);
                    break;
                case ButtonType.Levelinc:
                    if(FindObjectOfType<BaloonController>().Level<5)
                    {
                        FindObjectOfType<BaloonController>().Level += 1;
                    }
                    break;
                case ButtonType.Leveldec:
                    if (FindObjectOfType<BaloonController>().Level > 1)
                    {
                        FindObjectOfType<BaloonController>().Level -= 1;
                    }
                    break;

            }
            
        }
    }

}
