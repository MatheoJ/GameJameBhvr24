using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Ingredient_Unlocking : MonoBehaviour
{
    public GameObject UI_UnlockJam;
    public GameObject UI_UnlockCheese;

    private void Update()
    {
        if(GameManager.waveNumber == 2)
        {
            UIAnimPlayWave02();
        }
        
        if(GameManager.waveNumber == 3)
        {
            UIAnimPlayWave03();
        }
    }


    public void UIAnimPlayWave02()
    {
        UI_UnlockJam.SetActive(true);
    }
    
    public void UIAnimPlayWave03()
    {
        UI_UnlockCheese.SetActive(true);
    }
}
