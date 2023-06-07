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
        StartGame,
        EmojiType
    }
    public Type type;
    public int Change;
    public TargetManager tmg;
    public GameObject G;
    public Material Green, Black;
    // Start is called before the first frame update
    void Start()
    {
        tmg = FindFirstObjectByType<TargetManager>();
        G = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (type == Type.Sound1 || type == Type.Sound2 || type == Type.Sound3)
        {
           // tmg.PlaySound(Change);
            if (Change == tmg.Soundtype)
            {
                G.GetComponent<Renderer>().material = Green;
            }
            else
            {
                G.GetComponent<Renderer>().material = Black;
            }
        }
        if (type == Type.EmojiType)
        {
            //tmg.ChangeMat(Change);
            if (Change == tmg.EmojiType)
            {
                G.GetComponent<Renderer>().material = Green;
            }
            else
            {
                G.GetComponent<Renderer>().material = Black;
            }
        }

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
               tmg.Level += Change;
               tmg.Level = Mathf.Clamp(tmg.Level, 0, 4);
                
                
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
                if (Change == tmg.Soundtype)
                {
                    G.GetComponent<Renderer>().material = Green;
                }
                else
                {
                    G.GetComponent<Renderer>().material = Black;
                }
            }
            else if(type==Type.EmojiType)
            {
                tmg.ChangeMat(Change);
                if(Change==tmg.EmojiType)
                {
                    G.GetComponent<Renderer>().material = Green;
                }
                else
                {
                    G.GetComponent<Renderer>().material = Black;
                }
            }
        }
        
    }
}
