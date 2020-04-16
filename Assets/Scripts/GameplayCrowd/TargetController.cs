using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public bool isInfected;
    public SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    public void SetInfection(bool v)
    {
        isInfected = v;
        _sprite.color = Color.red;
    }
}
