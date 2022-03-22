using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject pop;
    [SerializeField] private float time;
    [SerializeField] private float limit = 15;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        time = 0;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= limit)
        {
            Destroy(gameObject);
            Instantiate(pop, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(pop, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }


}
