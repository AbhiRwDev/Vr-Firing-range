using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UtilityScript : MonoBehaviour
{
    public enum Type
    {
        WrongHitsCounter,
        CorrectHitsCounter,
        Roundcounter,
        MaxRoundCounter,
        LevelCounter
    }
    public Type type;
    public TargetManager targetmanager;
    public TextMeshPro textcomponent;
    // Start is called before the first frame update
    void Start()
    {
        targetmanager = FindFirstObjectByType<TargetManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(type==Type.WrongHitsCounter)
        {
            textcomponent.text = targetmanager.WrongHits.ToString();
        }
        else if (type == Type.CorrectHitsCounter)
        {
            textcomponent.text = targetmanager.CorrectHits.ToString();
        }
        else if (type == Type.Roundcounter)
        {
            textcomponent.text = targetmanager.RoundCounter.ToString();
        }
        else if (type == Type.MaxRoundCounter)
        {
            textcomponent.text = targetmanager.MaxRounds.ToString();
        }else if(type==Type.LevelCounter)
        {
            textcomponent.text = (targetmanager.Level + 1).ToString();
        }
    }
}
