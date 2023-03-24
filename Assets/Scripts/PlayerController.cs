using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;

    private float moveSpeed = 16.0f;
    private float jumpForce = 30.0f;
    private float gravityModifier = 8.0f;
    private float timePressedLeft = 0;
    private float timePressedRight = 0;
    private float cooldown = 0.5f;
    private float bulletSpeed = 30.0f;

    private Rigidbody2D playerRb;
    private Rigidbody2D bulletPrefabRb;
    private GameObject muzzleLeft;
    private GameObject muzzleRight;
    private GameObject shield;

    private bool isOnGround = false;
    private bool shieldActive = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        bulletPrefabRb = bulletPrefab.GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravityModifier;

        muzzleLeft = GameObject.Find("Muzzle Left Point");
        muzzleRight = GameObject.Find("Muzzle Right Point");
        shield = GameObject.Find("Player Shield");

        if (shield.activeInHierarchy)
        {
            shield.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        JumpPlayer();
        ActivateShield();
        Fire();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Moves/jumps the player based on input
    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector3(moveSpeed * horizontalInput, playerRb.velocity.y, 0);
    }

    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            moveSpeed = 10.0f;
            playerRb.velocity = Vector2.up * jumpForce;
        }
    }

    private void Fire()
    {
        if (!shieldActive)
        {
            if (Input.GetKeyDown(KeyCode.K) && Time.time - timePressedLeft > cooldown)
            {
                timePressedLeft = Time.time;
                BulletType playerBullet = new BulletType(null, 17f, 12f, 30f);
                Bullet newPlayerBullet = playerBullet.NewBullet();
                var firedBullet = Instantiate(bulletPrefab, muzzleLeft.transform.position, muzzleLeft.transform.rotation);
                firedBullet.GetComponent<BulletBehaviour>().SetBullet(newPlayerBullet);
                firedBullet.GetComponent<Rigidbody2D>().AddForce(muzzleLeft.transform.up * newPlayerBullet.GetBulletSpeed(), ForceMode2D.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.L) && Time.time - timePressedRight > cooldown)
            {
                timePressedRight = Time.time;
                BulletType playerBullet = new BulletType(null, 17f, 12f, 30f);
                Bullet newPlayerBullet = playerBullet.NewBullet();
                var firedBullet = Instantiate(bulletPrefab, muzzleRight.transform.position, muzzleRight.transform.rotation);
                firedBullet.GetComponent<BulletBehaviour>().SetBullet(newPlayerBullet);
                firedBullet.GetComponent<Rigidbody2D>().AddForce(muzzleRight.transform.up * newPlayerBullet.GetBulletSpeed(), ForceMode2D.Impulse);
            }
        }
    }

    private void ActivateShield()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!shieldActive)
            {
                shieldActive = true;
                shield.SetActive(true);
            }
            else
            {
                shieldActive = false;
                shield.SetActive(false);
            }
        }
    }

    // Checks for ground collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            moveSpeed = 16.0f;
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Pillar"))
        {
            playerRb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
        }
        
        // if (collision.gameObject.CompareTag("Enemy"))
        // {
        //     gameObject.SetActive(false);
        // }
    }
}

