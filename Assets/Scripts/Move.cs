using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Move : MonoBehaviour
{
    public float speed;
 
    Rigidbody2D rb;
    Animator animator;
    PhotonView view;

    float hor, ver;
    Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (!view.IsMine)
        {
            return;
        }

        hor = Input.GetAxis("Horizontal");
        direction = new Vector2(hor * speed, rb.velocity.y);

        if (hor > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (hor < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction;
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }
}
