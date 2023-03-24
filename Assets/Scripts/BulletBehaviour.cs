using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody2D bulletRb;
    private Bullet _bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > _bullet.GetBoundX() || transform.position.x < -_bullet.GetBoundX() || transform.position.y > _bullet.GetBoundY())
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player Bullet") && collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage();
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
            bulletRb.AddForce(direction * _bullet.GetBulletSpeed(), ForceMode2D.Impulse);
        }
    }

    public void SetBullet(Bullet bullet)
    {
        _bullet = bullet;
    }
}
