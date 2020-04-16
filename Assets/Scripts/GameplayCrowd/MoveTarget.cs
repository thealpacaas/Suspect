using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public float moveSpeed = 2.0f;  // Units per second
    public Animator animator;
    public GameObject MCSpriteObj;
    GameplayController gpCon;
    public Transform startPos;

    public AudioSource audio;
    public AudioClip stepclip;
    public AudioClip happy;
    private void OnEnable()
    {
        this.transform.position = startPos.position;
        if (GM.Instance.isInfected)
        {
            Debug.Log(GM.Instance.isInfected.ToString());
            this.transform.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
    }
   
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!GM.Instance.isOnEvent)
            {

                var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (transform.position.x < targetPos.x)
                {
                    MCSpriteObj.transform.localScale = new Vector3(0.3f, MCSpriteObj.transform.localScale.y, MCSpriteObj.transform.localScale.z);
                }
                else if (transform.position.x >= targetPos.x)
                {
                    MCSpriteObj.transform.localScale = new Vector3(-0.3f, MCSpriteObj.transform.localScale.y, MCSpriteObj.transform.localScale.z);
                }
                animator.CrossFade("CharaWalk", 0.05f);
                targetPos.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                if (!audio.isPlaying)
                {
                    audio.PlayOneShot(stepclip);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!GM.Instance.isOnEvent)
            {
                animator.CrossFade("CharaIdle", 0.05f);
               // AudioManager.Instance.StopSFX("Step");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Scene2")
        {
            GM.Instance.OnActivating_DoorEvent(GameScene.Scene2);

           // AudioManager.Instance.StopSFX("KnockDoor");
        }
        if (collision.tag == "target")
        {
            Debug.Log(collision.tag);
            GM.Instance.GotNewFriend_Activated();
            AudioManager.Instance.StopSFX("Hoi");
            audio.PlayOneShot(happy);
            collision.transform.GetComponent<PointController>().ChangePointColor_Activated();

        }

        if (collision.tag == "ToHome")
        {
            Debug.Log(this.name);
            GM.Instance.Change_Gamephase(GamePhase.ROOM);
        }
    }
}
