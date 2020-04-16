using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public float delayGreeting;
    public Animator _animator;
    private void OnEnable()
    {
        StartCoroutine(StartGreeting(delayGreeting));
    }
   

    IEnumerator StartGreeting(float delayg)
    {
        yield return new WaitForSeconds(delayg);
        _animator.CrossFade("CharaGreeting", 0.5f);
        AudioManager.Instance.PlaySFX("Hoi");
    }



    public void ChangePointColor_Activated()
    {
        _animator.CrossFade("CharaIdle", 0.5f);
        transform.GetComponent<Collider2D>().enabled = false;
        StartCoroutine(ChangePointColor(5f));
    }

    IEnumerator ChangePointColor(float delay)
    {
        yield return new WaitForSeconds(delay);

        this.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        AudioManager.Instance.PlaySFX("Cough");
        _animator.CrossFade("CharaCough", 0.5f);

    }


}
