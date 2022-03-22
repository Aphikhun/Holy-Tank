using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] tank;
    public Rigidbody2D rb;
    public float maxSpeed = 100f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();

        spriteRenderer.sprite = tank[0];
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * maxSpeed * Time.deltaTime, rb.velocity.y);
        Flip();

        if (TankControl.instance.hpPlayer > 10)
        {
            spriteRenderer.sprite = tank[0];
        }
        if (TankControl.instance.hpPlayer <= 10)
        {
            spriteRenderer.sprite = tank[1];
        }
        if (TankControl.instance.hpPlayer <= 5)
        {
            spriteRenderer.sprite = tank[2];
        }
        
    }

    void Flip()
    {
        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}
