using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int direction = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        if(transform.position.x < 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameManager.instance.enemySpeed;
        Flip();

        rb.velocity = new Vector2(speed * direction, rb.velocity.y);

        if(transform.position.x > 15 && direction == 1)
        {
            Destroy(gameObject);
        }else if(transform.position.x < -15 && direction == -1)
        {
            Destroy(gameObject);
        }
    }
    void Flip()
    {
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}
