using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelText : MonoBehaviour
{
    public BaloonController bcontroller;
    // Start is called before the first frame update
    void Start()
    {
        bcontroller = FindObjectOfType<BaloonController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().text = bcontroller.Level.ToString();
    }
}
