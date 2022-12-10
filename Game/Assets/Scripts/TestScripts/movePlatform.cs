using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class movePlatform : MonoBehaviour
{
    [SerializeField] private float speedOfPlatform;
    [SerializeField] private float distanceOfPlatform;
    [SerializeField] private bool isVertical;
    private Rigidbody2D rigidbodyOfPlatform;
    private float platformPassed;
    private void Start()
    {
        rigidbodyOfPlatform = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(platformPassed) < Mathf.Abs(distanceOfPlatform))
        {
            if (!isVertical)
                rigidbodyOfPlatform.transform.Translate(speedOfPlatform, 0, 0);
            else
                rigidbodyOfPlatform.transform.Translate(0, speedOfPlatform, 0);
            platformPassed += speedOfPlatform;
        }
        else
        {
            speedOfPlatform = -speedOfPlatform;
            platformPassed = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
