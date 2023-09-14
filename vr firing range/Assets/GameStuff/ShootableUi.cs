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
        sound3
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {

            FindObjectOfType<BaloonController>().StartPlayThrough();
            transform.parent.gameObject.SetActive(false);
        }
    }

}
