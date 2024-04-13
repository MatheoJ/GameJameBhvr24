using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    public Transform foodSpawnPoint;
    public GameObject foodPrefab;
    public float foodSpeed = 10;

    void Update()
    {
        //if mouse down
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(foodPrefab, foodSpawnPoint.position + foodSpawnPoint.forward*2, foodSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = foodSpawnPoint.forward * foodSpeed;
        }
    }
}
