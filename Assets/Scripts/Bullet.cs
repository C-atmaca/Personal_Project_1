using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float boundX = 17.0f;
    private float boundY = 12.0f;
    private float bulletSpeed = 30.0f;
    private Rigidbody2D bulletRb;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > boundX || transform.position.x < -boundX || transform.position.y > boundY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player Bullet") && collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Enemy Bullet") && collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Enemy Bullet") && collision.CompareTag("Shield"))
        {
            Vector2 direction = (transform.position - collision.gameObject.transform.position).normalized;
            bulletRb.velocity = Vector3.zero;
            bulletRb.angularVelocity = 0;
            bulletRb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
