using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankControl : MonoBehaviour
{
    [SerializeField] private int maxHp = 15;
    public int hpPlayer;
    public bool isDead = false;
    [SerializeField] private bool isSheild = false;
    [SerializeField] private GameObject sheild;

    public AimTurret aimTurret;
    public Turret[] turrets;
    
    public Vector2 movementVector;
    [SerializeField] private GameObject pop;

    public static TankControl instance;
    private void Awake()
    {
        instance = this;
        hpPlayer = maxHp;
        sheild.SetActive(false);

        if (aimTurret == null)
            aimTurret = GetComponentInChildren<AimTurret>();
        if (turrets == null || turrets.Length == 0)
        {
            turrets = GetComponentsInChildren<Turret>();
        }
    }

    private void Update()
    {

    }

    public void HandleShoot()
    {
        foreach (var turret in turrets)
        {
            turret.Shoot();
        }
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        aimTurret.Aim(pointerPosition);

    }

    public void Dead()
    {
        if(hpPlayer <= 0) 
        {
            AudioManager.instance.audioDead();
            Destroy(gameObject);
            Instantiate(pop, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            isDead = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (isSheild)
            {
                isSheild = false;
                sheild.SetActive(false);
            }
            else
            {
                if(hpPlayer <= 0)
                {
                    Dead();
                }
                else
                {
                    hpPlayer -= (Bullet.instance.damage + GameManager.instance.dmgBonus);
                    StartCoroutine(Flash());
                }
                
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Repair"))
        {
            hpPlayer += 5;
            if (hpPlayer >= maxHp)
            {
                hpPlayer = maxHp;
            }
        }
        else if (collision.gameObject.CompareTag("Sheild"))
        {
            isSheild = true;
            sheild.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Gun"))
        {
            Turret.instance.isExtra = true;
        }
    }

    public void delayDie()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
