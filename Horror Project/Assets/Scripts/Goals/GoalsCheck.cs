using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalsCheck : MonoBehaviour
{
    [Header("Goals Settings")]
    public bool goalsDieMonster = false;
    public bool goalsKey = false;
    [Header("Finnaly Settings")]
    public bool isActived;
    [Header("Finally HUD Settings")]
    public GameObject finallyMenu;
    public Text message;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActived == true)
        {
            message.gameObject.SetActive(true);
            if (goalsDieMonster == true && goalsKey == true)
            {
                message.text = "PRESS E TO THE ENTER";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    finallyMenu.SetActive(true);
                    message.gameObject.SetActive(false);
                }
            }
            else
            {
                message.text = "DONT'T IS POSSIBLE CONTINUE TO THE NEXT MISSION, VERIFY YOUR COMPLETE GOALS TO COMPLETE.";
            }
        }
        else
        {
            message.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActived = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActived = false;
        }
    }
}
