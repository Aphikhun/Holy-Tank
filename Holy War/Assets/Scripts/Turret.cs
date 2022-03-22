using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{
    public List<Transform> turretBarrel;
    public GameObject[] bulletlPrefab;
    public float reloadDelay = 1f;
    public bool isExtra = false;
    private int turretNum = 0;
    private int bulletNum = 0;
    private float time = 0f;

    public bool canShoot = true;
    private Collider2D[] tankCol;
    public float currentDelay = 0f;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] turrets;

    public static Turret instance;
    private void Awake()
    {
        instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        tankCol = GetComponentsInParent<Collider2D>();

        spriteRenderer.sprite = turrets[0];
    }
    private void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if(currentDelay <= 0f)
            {
                canShoot = true;
            }
        }
        
        if (isExtra)
        {
            time += Time.deltaTime;
            turretNum = 3;
            bulletNum = 1;

            if(time >= 20)
            {
                isExtra = false;
                time = 0;
            }
        }
        else
        {
            turretNum = 0;
            bulletNum = 0;
        }

        Change();
    }
    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;

            foreach(var barrel in turretBarrel)
            {
                GameObject bullet = Instantiate(bulletlPrefab[0 + bulletNum]);
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                AudioManager.instance.audioShoot();
                bullet.GetComponent<Bullet>().Initialize();
                foreach(var collider in tankCol)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }
            }
        }
        
    }

    private void Change()
    {
        if (TankControl.instance.hpPlayer > 10)
        {
            spriteRenderer.sprite = turrets[0 + turretNum];
        }
        if (TankControl.instance.hpPlayer <= 10)
        {
            spriteRenderer.sprite = turrets[1 + turretNum];
        }
        if (TankControl.instance.hpPlayer <= 5)
        {
            spriteRenderer.sprite = turrets[2 + turretNum];

        }
    }
}
