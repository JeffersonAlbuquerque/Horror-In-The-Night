using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyGoals : MonoBehaviour
{
    [Header("Trigger Settings")]
    public GameObject ObjectShow;
    public bool isActived = false;
    [Header("Key Settings")]
    public GameObject KeyObject;
    [Header("HUD Goal Key")]
    public Image CheckMarkKey;
    public Image NoCheckMark;
    [Header("Secondary Script")]
    public GoalsCheck goals;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isActived == true)
        {
            ObjectShow.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                CheckMarkKey.gameObject.SetActive(true);
                NoCheckMark.gameObject.SetActive(false);
                KeyObject.SetActive(false);
                isActived = false;
                ObjectShow.SetActive(false);
                goals.goalsKey = true;
            }
        }
        else
        {
            ObjectShow.SetActive(false);
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
