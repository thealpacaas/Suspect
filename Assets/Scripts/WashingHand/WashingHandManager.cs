using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingHandManager : MonoBehaviour
{
    public GameObject SoapDropL;
    public GameObject SoapDropR;
    public GameObject Faucet;
    public GameObject Water;

    public bool UseSoap;
    public bool TurnFaucet;
    public bool HandWashing;

    public Animator HandWashAnim;

    //Comment If Prefabs Gameplay Be Used
    //public GameObject NextGamePlay;

    void Init()
    {
        SoapDropL.SetActive(false);
        SoapDropR.SetActive(false);
        Faucet.transform.Rotate(0, 0, 0);
        Faucet.transform.localPosition = new Vector2(0, Faucet.transform.position.y);
        Water.transform.localScale = new Vector2(Water.transform.localScale.x, 0f);
        UseSoap = false;
        TurnFaucet = false;
        HandWashing = false;
    }

    public void TapSoap()
    {
        if (!UseSoap)
        {
            SoapDropL.SetActive(true);
            SoapDropR.SetActive(true);
            AudioManager.Instance.PlaySFX("Soap");
            UseSoap = true;
            Debug.Log("Use Soap");
        }
    }

    public void TapFaucet()
    {
        if ((UseSoap)&&(!TurnFaucet))
        {
            AudioManager.Instance.PlaySFX("Faucet");
            Faucet.transform.Rotate(0, 0, 90);
            AudioManager.Instance.PlaySFXLoop("Water");
            Faucet.transform.position= new Vector2(0.5f,Faucet.transform.position.y);
            Water.transform.localScale = new Vector2(Water.transform.localScale.x, 4f);
            TurnFaucet = true;
            Debug.Log("Turn Faucet");
        }
    }

    public void HoldWater()
    {
        if ((UseSoap)&&(TurnFaucet)&&(!HandWashing))
        {
            HandWashAnim.CrossFade("HandWashAnimation", 0);
        }
    }

    public void ReleaseWater()
    {
        HandWashAnim.CrossFade("START", 0);
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
        if (HandWashAnim.GetCurrentAnimatorStateInfo(0).IsName("FINISH"))
        {

            AudioManager.Instance.StopSFX("Water");
            Faucet.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Faucet.transform.position = new Vector2(0f, Faucet.transform.position.y);
            Water.transform.localScale = new Vector2(Water.transform.localScale.x, 0f);
            SoapDropL.SetActive(false);
            SoapDropR.SetActive(false);
            HandWashing = true;
            Invoke("Next", 1f);
        }
    }

    void Next()
    {
        GM.Instance.isOnEvent = false;
        this.gameObject.SetActive(false);

        //NextGamePlay.SetActive(true);
    }
}
