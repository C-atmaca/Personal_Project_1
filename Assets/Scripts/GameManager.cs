using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Respawn();
    }

    private void Respawn()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.SetActive(true);
        }
    }
}
