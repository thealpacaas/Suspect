using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingManager : MonoBehaviour
{
    public Vector3 BlanketStartPos;
    public Vector3 PullLampStartPos;

    public GameObject Blanket;
    public GameObject PullLamp;
    public GameObject BG;

    public bool BlanketOn;
    public bool LightOff;

    //Comment If Prefabs Gameplay Be Used
    //public GameObject NextGamePlay;

    void Init()
    {
        BG.GetComponent<SpriteRenderer>().color = Color.white;
        Blanket.transform.localPosition = BlanketStartPos;
        PullLamp.transform.localPosition = PullLampStartPos;
        BlanketOn = false;
        LightOff = false;
    }

    private void OnEnable()
    {
        Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Comment If Prefabs Gameplay Be Used
    void Next()
    {
        this.gameObject.SetActive(false);
        //NextGamePlay.SetActive(true);
    }

    public void PutOnBlanket()
    {
        AudioManager.Instance.PlaySFX("Blanket");
        BlanketOn = true;
    }

    public void TurnOffLight()
    {
        BG.GetComponent<SpriteRenderer>().color = Color.black;
        AudioManager.Instance.PlaySFX("LampOff");
        LightOff = true;
        Invoke("Next", 1f);
    }
}
