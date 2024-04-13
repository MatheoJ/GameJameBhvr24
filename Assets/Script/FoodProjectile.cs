using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodProjectile : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit");
            return;
        }
        Debug.Log("Hit: " + collision.gameObject.tag);
        Destroy(gameObject);
    }
    void OnTriggerEnter(UnityEngine.Collider other)
    {
        Destroy(gameObject);
    }
}
