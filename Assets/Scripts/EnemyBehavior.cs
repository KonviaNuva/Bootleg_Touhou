using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBehavior : MonoBehaviour
{
    public float health = 70;
    private float redTime = 0f;
    private float maxRedTime = 0.3f;
    public GameObject bullet;
    private float maxShootTimer = 2f;
    private float shootTimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Renderer thisRenderer = GetComponent<Renderer>();

        redTime -= Time.deltaTime;

        if (redTime <= 0f)
        {
            thisRenderer.material.SetColor("_Color", Color.white);
        }

        shootTimer -= Time.deltaTime;
        Shoot();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HeroBullet")
        {
            HeroBulletBehavior heroBulletScript = collision.GetComponent<HeroBulletBehavior>();
            health -= heroBulletScript.damage;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Renderer thisRenderer = GetComponent<Renderer>();
            thisRenderer.material.SetColor("_Color", Color.red);
            redTime = maxRedTime;
        }
    }

    void Shoot()
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        Vector3 vectorToPlayer = playerPosition - (transform.position + Vector3.down * 0.25f);
        var tan = vectorToPlayer.y / vectorToPlayer.x;
        var degree = Math.Atan(tan) * 180 / Math.PI;
        degree = Math.Abs(degree);
        if ((vectorToPlayer.x >= 0) && (vectorToPlayer.y >= 0))
        {
            degree = 270 + degree;
        }
        else
        if ((vectorToPlayer.x >= 0) && (vectorToPlayer.y <= 0))
        {
            degree = 270 - degree;
        }
        else
        if ((vectorToPlayer.x <= 0) && (vectorToPlayer.y <= 0))
        {
            degree = 90 + degree;
        }
        else
        if ((vectorToPlayer.x <= 0) && (vectorToPlayer.y >= 0))
        {
            degree = 90 - degree;
        }

        if (shootTimer <= 0)
        {
            float ran = UnityEngine.Random.Range(0, 10);

            if (ran < 5)
            {
                ShootOdd((float)degree);
            }
            else
            if (ran < 8)
            {
                ShootEven((float)degree);
            }
            else
            {
                ShootAll((float)degree);
            }
            shootTimer += maxShootTimer;
        }

        bullet.transform.rotation = Quaternion.identity;
    }

    void ShootOdd (float degree)
    {
        bullet.transform.Rotate(new Vector3(0, 0, degree - 12));
        Instantiate(bullet, transform.position + Vector3.down * 0.25f, bullet.transform.rotation);
        bullet.transform.Rotate(new Vector3(0, 0, 12));
        Instantiate(bullet, transform.position + Vector3.down * 0.25f, bullet.transform.rotation);
        bullet.transform.Rotate(new Vector3(0, 0, 12));
        Instantiate(bullet, transform.position + Vector3.down * 0.25f, bullet.transform.rotation);
        bullet.transform.Rotate(new Vector3(0, 0, 360 - degree - 12));
    }

    void ShootEven (float degree)
    {
        bullet.transform.Rotate(new Vector3(0, 0, degree - 18));
        Instantiate(bullet, transform.position + Vector3.down * 0.25f, bullet.transform.rotation);
        bullet.transform.Rotate(new Vector3(0, 0, 12));
        Instantiate(bullet, transform.position + Vector3.down * 0.25f, bullet.transform.rotation);
        bullet.transform.Rotate(new Vector3(0, 0, 12));
        Instantiate(bullet, transform.position + Vector3.down * 0.25f, bullet.transform.rotation);
        bullet.transform.Rotate(new Vector3(0, 0, 12));
        Instantiate(bullet, transform.position + Vector3.down * 0.25f, bullet.transform.rotation);
        bullet.transform.Rotate(new Vector3(0, 0, 360 - degree - 18));
    }

    void ShootAll (float degree)
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(bullet, transform.position + Vector3.down * 0.25f, bullet.transform.rotation);
            bullet.transform.Rotate(new Vector3(0, 0, 12));
        }
    }
}
