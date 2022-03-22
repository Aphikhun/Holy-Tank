using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public Transform target;
    [SerializeField] private Transform sight;
    public bool findPlayer = false;
    public GameObject bulletlPrefab;
    public float reloadDelay;
    public float currentDelay = 0f;
    public List<Transform> barrel;
    private Collider2D[] enemyCol;
    public bool canShoot = true;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        sight = GetComponentInParent<Transform>();
        enemyCol = GetComponents<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        reloadDelay = GameManager.instance.delayShoot;

        FindPlayer(); 
        CanShoot();
        Attack();
    }

    void FindPlayer()
    {
        Vector2 endPos = sight.position + Vector3.down * 50;
        RaycastHit2D hit = Physics2D.Linecast(sight.position, endPos, 1 << LayerMask.NameToLayer("Player"));
        anim.SetBool("findPlayer", findPlayer);
        if (hit.collider != null)
        {
            findPlayer = true;
        }
        else
        {
            findPlayer = false;
        }
    }
    void CanShoot()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0f)
            {
                canShoot = true;
            }
        }
    }
    void Attack()
    {
        if (findPlayer && canShoot)
        {
            findPlayer = false;
            canShoot = false;
            currentDelay = reloadDelay;

            foreach (var barrel in barrel)
            {
                GameObject bullet = Instantiate(bulletlPrefab);
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Initialize();
                foreach (var collider in enemyCol)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }
            }
        }

    }
}
