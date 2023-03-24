using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : Enemy
{
    public GameObject bulletPrefab;

    private GameObject player;
    private GameObject muzzle;
    private float turnSpeed = 8.0f;
    private float timeFired = 0;
    private float cooldown = 1.5f;
    private float bulletSpeed = 35.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        muzzle = gameObject.transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowards(player);
        FireAtPlayer(player);
    }

    private void RotateTowards(GameObject target)
    {
        Vector2 directon = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(directon.y, directon.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }

    private void FireAtPlayer(GameObject target)
    {
        if (Time.time - timeFired > cooldown)
        {
            timeFired = Time.time;
            BulletType enemyBullet = new BulletType(null, 17f, 12f, 5f);
            Bullet newEnemyBullet = enemyBullet.NewBullet();
            var firedBullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
            firedBullet.GetComponent<BulletBehaviour>().SetBullet(newEnemyBullet);
            firedBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.transform.up * newEnemyBullet.GetBulletSpeed(), ForceMode2D.Impulse);
        }
    }
    
    public override void TakeDamage()
    {
        Debug.Log("Canon Destroyed!");
        Destroy(gameObject);
    }
}
