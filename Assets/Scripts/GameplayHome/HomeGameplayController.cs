using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeGameplayController : MonoBehaviour
{
    public GameObject WastafelObj;
    public Animator BedObj;
    public Animator BathAnimator_;
    public Animator NotDoingAnimator_;
    public int Missions;


    public List<GameObject> MissionObjs;
    private void OnEnable()
    {
        MissionActivating();
        AudioManager.Instance.StopSFXAll();
        AudioManager.Instance.PlaySFXLoop("BGM001");
    }



    public void MissionActivating()
    {

        if (Missions >= MissionObjs.Count)
        {
            Missions = 0;
            GM.Instance.Day +=3;
            GM.Instance.Change_Gamephase(GamePhase.INTRO);
        }
        else if (Missions < MissionObjs.Count)
        {
            foreach (GameObject obj in MissionObjs)
            {
                obj.SetActive(false);
            }
            MissionObjs[Missions].SetActive(true);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        switch (collision.tag)
        {
            case "Wastafel":
                GM.Instance.isOnEvent = true;
                WastafelObj.SetActive(true);
                Missions += 1;
                MissionActivating();
                break;
            case "Bedroom":
                GM.Instance.isOnEvent = true;
                BedObj.gameObject.SetActive(true);
                BedObj.CrossFade("SleepOn", 0.05f);
                StartCoroutine(auto_objdisable(1.5f,BedObj.gameObject));
               
                break;
            case "Bathroom":
                Missions += 1;
                MissionActivating();
                break;
            case "NoEvent":
                Debug.Log("no");
                NotDoingAnimator_.CrossFade("CharaNotDoing", 0.05f);
                StartCoroutine(ActivatingEvent(3f));
                break;
        }
    }


    IEnumerator auto_objdisable(float delay, GameObject obj)
    {
        yield return new WaitForSeconds(delay);

        GM.Instance.isOnEvent = false;
        obj.SetActive(false);
        Missions += 1;
        AudioManager.Instance.StopSFXAll();
        MissionActivating();
    }
    IEnumerator ActivatingEvent(float delay)
    {
        GM.Instance.isOnEvent = true;
        yield return new WaitForSeconds(delay);
        GM.Instance.isOnEvent = false;
    }
}
