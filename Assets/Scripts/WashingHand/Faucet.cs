using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : MonoBehaviour
{
    private WashingHandManager manager;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<WashingHandManager>();
    }

    private void OnMouseDown()
    {
        manager.TapFaucet();
    }
}
