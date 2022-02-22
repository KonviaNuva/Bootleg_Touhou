using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBulletBehavior : MonoBehaviour
{
    public float damage = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 7f;

        transform.Translate(Vector2.up * Time.deltaTime * speed);

        DestroyOutOfBounds();
    }

    void DestroyOutOfBounds()
    {
        float maxRangeX = 8f;
        float maxRangeY = 4.5f;
        float extraSpace = 2f;

        maxRangeX += extraSpace;
        maxRangeY += extraSpace;

        if ((transform.position.x > maxRangeX) | (transform.position.x < -maxRangeX)
            | (transform.position.y > maxRangeY) | (transform.position.y < -maxRangeY))
        {
            Destroy(gameObject);
        }
    }
}
