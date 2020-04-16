using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    private void OnEnable()
    {
        GM.Instance.Play_DirectorOnDay(GM.Instance.Day);

        AudioManager.Instance.StopSFXAll();
        //AudioManager.Instance.PlaySFXLoop("Crowd");
    }
    
   
}
