using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    public int damage = 5;
    [SerializeField] private float maxDistance = 30f;

    private Vector2 startPos;
    private float conquaredDis = 0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject pop;

    public static Bullet instance;  
    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        conquaredDis = Vector2.Distance(transform.position, startPos);
        if(conquaredDis >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
    
    public void Initialize()
    {
        startPos = transform.position;
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(pop, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
