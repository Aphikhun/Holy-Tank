using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplie : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private GameObject pop;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.audioSupplie();
        pop.transform.localScale = new Vector2(2f, 2f);
        Instantiate(pop, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Destroy(gameObject);
        Instantiate(items[Random.Range(0,3)], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
