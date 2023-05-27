using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public int Level;
    public GameObject[] targetPrefabs;
    public GameObject[] targets;
    public int RoundCounter,MaxRounds;
    public GameObject RightImage;
    public GameObject[] WrongImage;
    public int CorrectHits;
    public int WrongHits;
    public GameObject settingBoard;
    public AudioSource ad;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartSpawn()
    {
        SpawnTargets();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
     public void CheckHit(int HitValue)
    {
        disableColliders();
        if (HitValue==1)
        {
            Debug.Log("correct hit");
            CorrectHits += 1;
        }
        else
        {
            Debug.Log("Wrong hit");
            WrongHits += 1;
        }
       
        Invoke(nameof(ResetTargets),3f);
    }
    public void ResetTargets()
    {
        foreach (var item in targets)
        {
            item.transform.position = new Vector3(item.transform.position.x,-1,item.transform.position.z);
            item.GetComponent<TargetMove>().resetValues();
            item.SetActive(false);
        }
        SpawnTargets();
        Debug.Log("Targets reset");
    }
    public void disableColliders()
    {
        foreach (var item in targets)
        {
            item.GetComponent<Collider>().enabled = false;
        }
    }
    public void SpawnTargets()
    {
        int im = 0;
        if (RoundCounter < MaxRounds)
        {
            int i = 0;
            
            int r = Random.Range(0, targets.Length-1);
            switch (Level)
            {
                case 0://only pop up and go down when shot

                    foreach (var item in targets)
                    {
                        
                        
                        item.SetActive(true);
                        item.GetComponent<TargetMove>().popUpTimer = 3;
                        item.GetComponent<TargetMove>().bshouldGoDown = false;
                        item.GetComponent<TargetMove>().bshouldMove = false;
                        item.GetComponent<TargetMove>().TargetPoppedUp = false;
                        item.GetComponent<TargetMove>().bshouldMoveRandom = false;
                        item.GetComponent<TargetMove>().speed = Random.Range(3, 8);
                        item.GetComponent<TargetMove>().goDownTimer = 5;
                        item.GetComponent<Collider>().enabled = true;
                        
                        if (i == r)
                        {
                            item.GetComponent<TargetMove>().isCorrect = 1;
                            RightImage.transform.parent = item.transform;
                            RightImage.transform.position = item.transform.position;
                            RightImage.transform.localPosition = new Vector3(RightImage.transform.localPosition.x, 1.05f, RightImage.transform.localPosition.z);
                        }
                        else
                        {
                           
                            item.GetComponent<TargetMove>().isCorrect = 0;
                            WrongImage[im].transform.parent = item.transform;
                            WrongImage[im].transform.position = item.transform.position;
                            WrongImage[im].transform.localPosition = new Vector3(WrongImage[im].transform.localPosition.x, 1.05f, WrongImage[im].transform.localPosition.z);
                            im++;

                        }
                        i++;
                    }
                    break;
                case 1://only pop up and go down after some time
                    i = 0;
                    r = Random.Range(0, targets.Length);
                    foreach (var item in targets)
                    {
                        
                        item.SetActive(true);
                        item.GetComponent<TargetMove>().popUpTimer = 3;
                        item.GetComponent<TargetMove>().bshouldGoDown = true;
                        item.GetComponent<TargetMove>().bshouldMove = false;
                        item.GetComponent<TargetMove>().TargetPoppedUp = false;
                        item.GetComponent<TargetMove>().bshouldMoveRandom = false;
                        item.GetComponent<TargetMove>().speed = Random.Range(3, 8);
                        item.GetComponent<TargetMove>().goDownTimer = 5;
                        item.GetComponent<Collider>().enabled = true;
                        if (i == r)
                        {
                            item.GetComponent<TargetMove>().isCorrect = 1;
                            RightImage.transform.parent = item.transform;
                            RightImage.transform.position = item.transform.position;
                            RightImage.transform.localPosition = new Vector3(RightImage.transform.localPosition.x, 1.05f, RightImage.transform.localPosition.z);
                        }
                        else
                        {
                            item.GetComponent<TargetMove>().isCorrect = 0;
                            WrongImage[im].transform.parent = item.transform;
                            WrongImage[im].transform.position = item.transform.position;
                            WrongImage[im].transform.localPosition = new Vector3(WrongImage[im].transform.localPosition.x, 1.05f, WrongImage[im].transform.localPosition.z);
                            im++;
                        }
                        i++;
                    }
                    break;
                case 2://only pop up and go move
                    i = 0;
                    r = Random.Range(0, targets.Length);
                    foreach (var item in targets)
                    {
                       
                        item.SetActive(true);
                        item.GetComponent<TargetMove>().popUpTimer = 3;
                        item.GetComponent<TargetMove>().bshouldGoDown = false;
                        item.GetComponent<TargetMove>().TargetPoppedUp = false;
                        item.GetComponent<TargetMove>().bshouldMove = true;
                        item.GetComponent<TargetMove>().bshouldMoveRandom = false;
                        item.GetComponent<TargetMove>().speed = Random.Range(3, 8);
                        item.GetComponent<TargetMove>().goDownTimer = 5;
                        item.GetComponent<Collider>().enabled = true;
                        if (i == r)
                        {
                            item.GetComponent<TargetMove>().isCorrect = 1;
                            RightImage.transform.parent = item.transform;
                           
                            RightImage.transform.position = item.transform.position;
                            RightImage.transform.localPosition = new Vector3(RightImage.transform.localPosition.x, 1.05f, RightImage.transform.localPosition.z);
                        }
                        else
                        {
                            item.GetComponent<TargetMove>().isCorrect = 0;
                            WrongImage[im].transform.parent = item.transform;
                            WrongImage[im].transform.position = item.transform.position;
                            WrongImage[im].transform.localPosition = new Vector3(WrongImage[im].transform.localPosition.x, 1.05f, WrongImage[im].transform.localPosition.z);
                            im++;
                        }
                        i++;
                    }
                    break;
                case 3://pop up and move and go down
                    i = 0;
                    r = Random.Range(0, targets.Length);
                    foreach (var item in targets)
                    {
                        
                        item.SetActive(true);
                        item.GetComponent<TargetMove>().popUpTimer = 3;
                        item.GetComponent<TargetMove>().bshouldGoDown = true;
                        item.GetComponent<TargetMove>().TargetPoppedUp = false;
                        item.GetComponent<TargetMove>().bshouldMove = true;
                        item.GetComponent<TargetMove>().bshouldMoveRandom = false;
                        item.GetComponent<TargetMove>().speed = Random.Range(3, 8);
                        item.GetComponent<TargetMove>().goDownTimer = 5;
                        item.GetComponent<Collider>().enabled = true;
                        if (i == r)
                        {
                            item.GetComponent<TargetMove>().isCorrect = 1;
                            RightImage.transform.parent = item.transform;
                            RightImage.transform.position = item.transform.position;
                            RightImage.transform.localPosition = new Vector3(RightImage.transform.localPosition.x, 1.05f, RightImage.transform.localPosition.z);
                        }
                        else
                        {
                            item.GetComponent<TargetMove>().isCorrect = 0;
                            WrongImage[im].transform.parent = item.transform;
                            WrongImage[im].transform.position = item.transform.position;
                            WrongImage[im].transform.localPosition = new Vector3(WrongImage[im].transform.localPosition.x, 1.05f, WrongImage[im].transform.localPosition.z);
                            im++;
                        }
                        i++;
                    }
                    break;
                case 4://pop up and move and go down
                    i = 0;
                    r = Random.Range(0, targets.Length);
                    foreach (var item in targets)
                    {
                       
                        item.SetActive(true);
                        item.GetComponent<TargetMove>().popUpTimer = 3;
                        item.GetComponent<TargetMove>().bshouldGoDown = true;
                        item.GetComponent<TargetMove>().TargetPoppedUp = false;
                        item.GetComponent<TargetMove>().bshouldMove = true;
                        item.GetComponent<TargetMove>().bshouldMoveRandom = true;
                        item.GetComponent<TargetMove>().speed = Random.Range(3, 8);
                        item.GetComponent<TargetMove>().goDownTimer = 5;
                        item.GetComponent<Collider>().enabled = true;
                        if (i == r)
                        {
                            item.GetComponent<TargetMove>().isCorrect = 1;
                            RightImage.transform.parent = item.transform;
                            RightImage.transform.position = item.transform.position;
                            RightImage.transform.localPosition = new Vector3(RightImage.transform.localPosition.x, 1.05f, RightImage.transform.localPosition.z);
                        }
                        else
                        {
                            item.GetComponent<TargetMove>().isCorrect = 0;
                            WrongImage[im].transform.parent = item.transform;
                            WrongImage[im].transform.position = item.transform.position;
                            WrongImage[im].transform.localPosition = new Vector3(WrongImage[im].transform.localPosition.x, 1.05f, WrongImage[im].transform.localPosition.z);
                            im++;
                        }
                        i++;
                    }
                    break;


            }
            RoundCounter++;
        }
        else
        {
            settingBoard.SetActive(true);
            RoundCounter = 0;
        }
        
    }
    public void PlaySound(int soundClip)
    {
        ad.clip = clips[soundClip];
        ad.Play();
    }
}
