using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    public Transform foodSpawnPoint;
    public GameObject foodPrefab;
    public List<GameObject> foodList;
    public float foodSpeed = 10;

    private int foodIndex = 0;

    void Update()
    {
        //if mouse down
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(foodList[foodIndex], foodSpawnPoint.position + foodSpawnPoint.forward*2, foodSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = foodSpawnPoint.forward * foodSpeed;
        }

        //if mouse wheel is scrolled
        if (Input.mouseScrollDelta.y > 0)
        {
            foodIndex++;
            if (foodIndex >= foodList.Count)
            {
                foodIndex = 0;
            }
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            foodIndex--;
            if (foodIndex < 0)
            {
                foodIndex = foodList.Count - 1;
            }
        }

        //if 1, 2, 3, 4, 5, 6, 7, 8, 9 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foodIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foodIndex = 1;
        }
    }
}
