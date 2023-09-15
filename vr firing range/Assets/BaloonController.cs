using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BaloonController : MonoBehaviour
{
    public int Combination;
    public string CombinationEntered;
    public int Level;
    public int round=0;
    public AudioSource audiosrc;
    public GameObject[] Baloons;
    public int IncorrectHits;

    public TextMeshPro CombinationText, CombinationText1;
    private int maxrounds = 2;
    public GameObject SettingBoard,ScoreBoard;
    public GameObject LevelText;
    private UtilityScript Us;
    public AudioClip[] audioclips;
    public int sclip;
    public Material Unmat, yesMat;
    public TextMeshPro levelround;
    // Start is called before the first frame update
    void Start()
    {
        Us = FindAnyObjectByType<UtilityScript>();
       // StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        CombinationText.text = Combination.ToString();
        CombinationText1.text = CombinationEntered;
        if(Level<6)
        {
            levelround.text = "L-" + Level.ToString() + "\n" + "R-" + round.ToString();
        }
        else
        {
            levelround.text = "";
        }
    }
    public void StartPlayThrough()
    {
        Level = 1;
        round = 0;
        IncorrectHits = 0;
        Us.ResetScores();
        ScoreBoard.SetActive(false);
        StartGame();
    }
    public void StartGame()
    {
        
        GenerateCombination();
    }
    public void GenerateCombination()
    {
        switch (Level)
        {
            case 1:
                Combination = Random.Range(100, 1000);
                foreach (var item in Baloons)
                {
                    item.GetComponent<Balloon>().Ismovingup = false;
                    item.GetComponent<Balloon>().movespeed = 0;
                    item.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                break;
            case 2:

                Combination = Random.Range(100, 1000);
                foreach (var item in Baloons)
                {
                  
                    item.GetComponent<Balloon>().movespeed = 2;
                }
                break;
            case 3:
                foreach (var item in Baloons)
                {
                    item.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
                    item.GetComponent<Balloon>().movespeed = 2;
                }
                Combination = Random.Range(1000, 10000);
                break;
            case 4:
                foreach (var item in Baloons)
                {
                    item.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
                    item.GetComponent<Balloon>().movespeed = 4;
                }
                Combination = Random.Range(10000, 100000);
                break;
            case 5:
                foreach (var item in Baloons)
                {
                    item.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
                    item.GetComponent<Balloon>().movespeed = 6;
                    
                }
                Combination = Random.Range(100000, 1000000);
                break;
        }
        

       
        RandomizeBaloons();
        
    }
    public void RandomizeBaloons()
    {
        List<int> tempstore=new List<int>();
        
        foreach (var item in Baloons)
        {
            item.SetActive(true);
            int n=10;
            bool isunique = false;
            while(!isunique)
            {
                n = Random.Range(0, 10);
                if (!tempstore.Contains(n))
                {
                    isunique = true;
                }
               
            }
            item.GetComponent<Balloon>().number = n;
            tempstore.Add(n);
        }
        tempstore.Clear();
    }

    public void EnterCombination(int N)
    {
        string s = CombinationEntered + N.ToString();
        if(CombinationEntered.ToString().Length<6)
        {
            Debug.Log(Combination.ToString().Length);
            Debug.Log(s.Length);
            if (s[s.Length-1]==Combination.ToString()[s.Length-1])
            {
               
                Debug.Log("CorrectHit");
                Us.CHs[Level - 1] += 1;
                CombinationEntered = s;
            }
            else
            {
                Debug.Log("WrongHit");
                Us.WHs[Level - 1] += 1;
            }
           
        
        }
        
        if(CombinationEntered.Length==Combination.ToString().Length)
        {
            CombinationEntered = "";
           
            WinRound();
        }
    }

    public void WinRound()
    {
        Us.UpdateTexts();
        if (Level<=5)
        {
            if(round==maxrounds)
            {
                Level += 1;
                foreach (var item in Baloons)
                {
                    item.SetActive(false);
                }
                if(Level<=5)
                {
                    LevelText.SetActive(true);
                    LevelText.GetComponent<TextMeshPro>().text = "LEVEL - " + Level;

                    round = 0;
                }
                
                StartCoroutine(delay());

            }
            else
            {
                round += 1;
                StartGame();
            }
            
           
        }
        if(Level==6)
        {
            GameOver();
        }
       
    }
    IEnumerator delay()
    {
       
        yield return new WaitForSeconds(3);
        LevelText.SetActive(false);
        if(Level<=5)
        {
            StartGame();
        }
       
        
    }
    public void GameOver()
    {
        audiosrc.Stop();
        SettingBoard.SetActive(true);
        ScoreBoard.SetActive(true);
        foreach (var item in Baloons)
        {
            item.SetActive(false);
        }
        Debug.Log("GameOver");
    }

    public void PlaySound(int audioclip)
    {
        
        sclip = audioclip;
        if (sclip < 3)
        {
            audiosrc.clip = audioclips[sclip];
            audiosrc.Play();
        }
        if(sclip==3)
        {
            audiosrc.Stop();
        }
        
    }
}
