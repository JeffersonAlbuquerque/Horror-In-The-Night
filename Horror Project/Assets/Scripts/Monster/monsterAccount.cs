using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterAccount : MonoBehaviour
{
    [Header("Monster Account Settings")]
    public int monsterDie;
    public int monsterQuantity;
    [Header("Monster Account HUD")]
    public Image monsterNotOkImage;
    public Image monsterCheckImage;
    [Header("Secondary Scripts")]
    public GoalsCheck goalsMonster;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterDie >= monsterQuantity)
        {
            monsterNotOkImage.gameObject.SetActive(false);
            monsterCheckImage.gameObject.SetActive(true);
            goalsMonster.goalsDieMonster = true;
        }
    }
}
