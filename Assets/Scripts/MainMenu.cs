using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void onstartCLick()
    {
       GM.Instance.gamePhase = GamePhase.INTRO;
       GM.Instance.Change_Gamephase(GM.Instance.gamePhase);
        this.gameObject.SetActive(false);
    }
}
