using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    private GameObject player;

    private float speed = 2.0f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 playerLocation = player.transform.position;
        Vector3 direction = playerLocation - transform.position;
        Vector3 normalizedDirection = Vector3.Normalize(direction);

        transform.Translate(normalizedDirection * speed * Time.deltaTime);
    }
}
