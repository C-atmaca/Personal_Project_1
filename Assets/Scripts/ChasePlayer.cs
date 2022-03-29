using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    private GameObject player;
    private float moveSpeed;
    private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        moveSpeed = Random.Range(1.5f, 10.0f);
        rotateSpeed = Random.Range(0.5f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowards(player);
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void RotateTowards(GameObject target)
    {
        Vector2 directon = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(directon.y, directon.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
}
