using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorknock : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        AudioManager.Instance.PlaySFX("KnockDoor");    }

    private void OnDisable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
