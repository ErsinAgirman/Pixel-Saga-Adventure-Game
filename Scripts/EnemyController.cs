using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    [SerializeField] private float speed;
    [SerializeField] private float idleTime = 2.0f; 
    private bool isWaiting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
    }

    void Update()
    {
        UnityEngine.Vector2 point = currentPoint.position - transform.position;

        if (!isWaiting)
        {
            if (currentPoint == pointB.transform)
            {
                rb.velocity = new UnityEngine.Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new UnityEngine.Vector2(-speed, 0);
            }
        }

        if (UnityEngine.Vector2.Distance(transform.position, currentPoint.position) < 0.5f && !isWaiting)
        {
            StartCoroutine(WaitAndChangePoint());
        }
    }

    private IEnumerator WaitAndChangePoint()
    {
        isWaiting = true;
        rb.velocity = UnityEngine.Vector2.zero;
        anim.SetBool("isRunning", false);
        yield return new WaitForSeconds(idleTime);

        if (currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        else
        {
            currentPoint = pointB.transform;
        }

        Flip();
        anim.SetBool("isRunning", true);
        isWaiting = false;
    }

    private void Flip()
    {
        UnityEngine.Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
