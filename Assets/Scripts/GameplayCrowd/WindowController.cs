using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public SpriteRenderer mc;
    public SpriteRenderer orang1;
    public SpriteRenderer orang2;
    public SpriteRenderer orang3;


    private void OnEnable()
    {
        if (GM.Instance.isInfected)
        {
            mc.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }

        switch (GM.Instance.Day)
        {
            case 4:
                orang1.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                break;
            case 7:
                orang1.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                orang2.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                break;
            case 10:
                orang1.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                orang2.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                orang3.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                break;
        }
    }
}
