using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyDamageScript : MonoBehaviour
{
   [SerializeField] private Vector2 VectorMove;
    private Rigidbody2D body;
    private BoxCollider2D col;
    private bool isGo;

    private void Start()
    {
        isGo = true;
        body = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        StartCoroutine(upDownMove());

    }

    private void FixedUpdate()
    {
        if (isGo == true)
        {
            body.velocity = VectorMove;
        }
        if (isGo == false)
        {
            body.velocity = new Vector2(VectorMove.x, -VectorMove.y);
        }
    }


    IEnumerator upDownMove()
    {
        yield return new WaitForSeconds(2f);

        isGo = !isGo;

        StartCoroutine(upDownMove());
    }
}
