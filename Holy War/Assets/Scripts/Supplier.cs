using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplier : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int direction = 1;
    [SerializeField] private int hp = 10;

    [SerializeField] GameObject pop;
    [SerializeField] GameObject drop;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        if (transform.position.x < 0)
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
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        Flip();
        

        
        if (transform.position.x > 15 && direction == 1)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -15 && direction == -1)
        {
            Destroy(gameObject);
        }
        
    }
    public void Dead()
    {
        if (hp <= 0)
        {
            AudioManager.instance.audioDead();
            Destroy(gameObject);
            Instantiate(pop, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Instantiate(drop, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if(hp <= 0)
            {
                Dead();
            }
            else
            {
                hp -= Bullet.instance.damage;
                StartCoroutine(Flash());
            }
            
        }
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 3; i++)
        {
            this.GetComponentInChildren<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            this.GetComponentInChildren<Renderer>().material.color = Color.white;
            yield return new WaitForSeconds(0.1f);

        }
    }
}
