using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UtilityScript : MonoBehaviour
{
    public string Alltexts;
    public int[] WHs, CHs = new int[5];

    public TextMeshPro[] WHstexts, CHstexts = new TextMeshPro[5];
    private void Update()
    {
        UpdateTexts();
    }
    public void UpdateTexts()
    {
        for (int i = 0; i < WHs.Length; i++)
        {
            WHstexts[i].text = WHs[i].ToString();
            CHstexts[i].text = CHs[i].ToString();
        }
    }
    public void ResetScores()
    {
        for (int i = 0; i < WHs.Length; i++)
        {
            WHs[i] = 0;
            CHs[i] = 0;
        }
    }

}
