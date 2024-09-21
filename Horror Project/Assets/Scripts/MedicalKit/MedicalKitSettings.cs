using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MedicalKitSettings : MonoBehaviour
{
    [Header("Trigger Settings")]
    public GameObject ObjectShow;
    public bool isActived = false;
    [Header("Medical Settings")]
    public GameObject MedicalObject;
    [Header("Secondary Script")]
    public medicalQuantity medical;

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
                MedicalObject.SetActive(false);
                isActived = false;
                ObjectShow.SetActive(false);
                medical.medicalAccount += 1;
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
