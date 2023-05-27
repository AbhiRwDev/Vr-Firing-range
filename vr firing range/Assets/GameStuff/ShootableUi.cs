using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableUi : MonoBehaviour
{
    public enum Type
    {
        MaxRounds,
        Level,
        infiniteMode,
        Sound1,
        Sound2,
        Sound3,
        StartGame
    }
    public Type type;
    public int Change;
    public TargetManager tmg;
    // Start is called before the first frame update
    void Start()
    {
        tmg = FindFirstObjectByType<TargetManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            if(type==Type.MaxRounds)
            {
                tmg.MaxRounds += Change;
            }
            else if(type==Type.Level)
            {
                if(!(tmg.Level<0)&&!(tmg.Level>4))
                tmg.Level += Change;
                
            }else if(type==Type.infiniteMode)
            {
                if(tmg.MaxRounds==int.MaxValue)
                {
                    tmg.MaxRounds = 0;
                    transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.white;
                }
                else
                {
                    tmg.MaxRounds = int.MaxValue;
                    transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
                }
                
                
            }else if(type==Type.StartGame)
            {
                tmg.StartSpawn();
                gameObject.transform.parent.gameObject.SetActive(false);
            }else if(type==Type.Sound1|| type == Type.Sound2 || type == Type.Sound3)
            {
                tmg.PlaySound(Change);
            }
        }
    }
}
