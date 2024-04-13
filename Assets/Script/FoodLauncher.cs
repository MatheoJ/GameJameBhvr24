using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    public Transform foodSpawnPoint;
    public GameObject foodPrefab;
    public List<GameObject> foodList;
    public float foodSpeed = 10;
    public int foodNumberUnlocked = 2;

<<<<<<< Updated upstream
    private int chosenFoodIndex = 0;
=======
    public Animator animatorhand;
    private bool isClick = false;
    private bool isTurnPage = false;

    private int foodIndex = 0;
>>>>>>> Stashed changes

    void start()
    {
        animatorhand = GetComponent<Animator>();
    }

    void Update()
    {
        animatorhand.SetBool("isClick", isClick);
        animatorhand.SetBool("isTurnPage", isTurnPage);

        //if mouse down
        if (Input.GetMouseButtonDown(0))
        {
<<<<<<< Updated upstream
            var bullet = Instantiate(foodList[chosenFoodIndex], foodSpawnPoint.position + foodSpawnPoint.forward*2, foodSpawnPoint.rotation);
=======
            isClick = true;

            var bullet = Instantiate(foodList[foodIndex], foodSpawnPoint.position + foodSpawnPoint.forward*2, foodSpawnPoint.rotation);
>>>>>>> Stashed changes
            bullet.GetComponent<Rigidbody>().velocity = foodSpawnPoint.forward * foodSpeed;
        }
        else
        {
            isClick = false;
        }


        //if mouse wheel is scrolled
        if (Input.mouseScrollDelta.y > 0)
        {
<<<<<<< Updated upstream
            chosenFoodIndex++;
            if (chosenFoodIndex >= foodList.Count || chosenFoodIndex >= foodNumberUnlocked)
=======
            isTurnPage = true;
            foodIndex++;
            if (foodIndex >= foodList.Count)
>>>>>>> Stashed changes
            {
                chosenFoodIndex = 0;
            }
            else
            {
                isTurnPage = false;
            }
        }


        else if (Input.mouseScrollDelta.y < 0)
        {
<<<<<<< Updated upstream
            chosenFoodIndex--;
            if (chosenFoodIndex < 0)
=======
            
            isTurnPage = true;
            foodIndex--;
            if (foodIndex < 0)
>>>>>>> Stashed changes
            {
                chosenFoodIndex = foodList.Count - 1;
            }
            else
            {
                isTurnPage = false;
            }
        }

        //if 1, 2, 3, 4, 5, 6, 7, 8, 9 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            chosenFoodIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && foodNumberUnlocked>=2)
        {
            chosenFoodIndex = 1;
        }
    }
}
