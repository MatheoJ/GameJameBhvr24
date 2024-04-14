using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    public Transform foodSpawnPoint;
    public GameObject foodPrefab;
    public List<GameObject> foodList;
    public float foodSpeed = 10;
    public int foodNumberUnlocked = 1;


    private int chosenFoodIndex = 0;


    void Update()
    {

        //if mouse down
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(foodList[chosenFoodIndex], foodSpawnPoint.position + foodSpawnPoint.forward*2, foodSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = foodSpawnPoint.forward * foodSpeed;
        }


        //if mouse wheel is scrolled
        if (Input.mouseScrollDelta.y > 0)
        {
            chosenFoodIndex++;
            
            if (chosenFoodIndex >= foodList.Count || chosenFoodIndex+1 > foodNumberUnlocked)
            {
                chosenFoodIndex = 0;
            }
            else
            {
            }
        }


        else if (Input.mouseScrollDelta.y < 0)
        {
            chosenFoodIndex--;
            
            if (chosenFoodIndex < 0)
            {
                chosenFoodIndex = Mathf.Min(foodNumberUnlocked, foodList.Count)-1;
            }
            else
            {
            }
        }

        //if 1, 2, 3, 4, 5, 6, 7, 8, 9 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            chosenFoodIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && foodNumberUnlocked>1)
        {
            chosenFoodIndex = 1;
        } else if (Input.GetKeyDown(KeyCode.Alpha3) && foodNumberUnlocked>2)
        {
            chosenFoodIndex = 2;
        } 

    }
}
