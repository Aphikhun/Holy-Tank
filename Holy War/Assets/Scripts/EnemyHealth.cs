using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hpEnemy = 15;

    [SerializeField] private GameObject pop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dead()
    {
        if (hpEnemy <= 0)
        {
            GameManager.instance.score += 100;
            AudioManager.instance.audioDead();
            Destroy(gameObject);
            Instantiate(pop, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            hpEnemy -= Bullet.instance.damage;

            if(hpEnemy <= 0)
            {
                Dead();
            }
            else
            {
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
