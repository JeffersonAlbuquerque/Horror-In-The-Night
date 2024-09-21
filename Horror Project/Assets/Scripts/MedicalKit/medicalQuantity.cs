using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class medicalQuantity : MonoBehaviour
{
    [Header("Medical Settings")]
    public int medicalAccount;
    [Header("HUD Settings")]
    public Text medicalTextAccount;
    [Header("Life Settings")]
    public float rechargeLife;
    [Header("Secondary Scripts")]
    public lifePlayer lifeP;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        medicalTextAccount.text = medicalAccount.ToString();

        if (medicalAccount >= 1)
        {
            if (Input.GetKeyDown(KeyCode.K) && lifeP.life < lifeP.lifeMaximum)
            {
                lifeP.life = lifeP.life + rechargeLife;
                medicalAccount -= 1;
            }
        }
        if (lifeP.life > lifeP.lifeMaximum)
        {
            lifeP.life = lifeP.lifeMaximum;
        }
    }
}
