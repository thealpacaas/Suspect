using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public Vector3 posStay;
    public float speed = 5f;
    private float minDistance = 3f;
    public Animator animator;
    //  private float range;

    void Start()
    {
        // range = Vector2.Distance(transform.position, target.position);
        posStay = transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "MC")
        {
            transform.position = Vector2.MoveTowards(transform.position, collision.transform.position, -1 * speed * Time.deltaTime);
            animator.CrossFade("CharaWalk", 0.5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MC")
        {
            animator.CrossFade("CharaIdle", 0.5f);
            StartCoroutine(BackToPlace());
            
        }
    }

    IEnumerator BackToPlace()
    {
        yield return new WaitForSeconds(2f);
        transform.position = Vector2.MoveTowards(transform.position, posStay, speed * Time.deltaTime);
        //animator.CrossFade("CharaWalk", 0.5f);
    }
}
