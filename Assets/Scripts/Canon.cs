using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject bulletPrefab;

    private GameObject player;
    private GameObject muzzle;
    private float turnSpeed = 8.0f;
    private float timeFired = 0;
    private float cooldown = 1.0f;
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
            var firedBullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
            firedBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.transform.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
