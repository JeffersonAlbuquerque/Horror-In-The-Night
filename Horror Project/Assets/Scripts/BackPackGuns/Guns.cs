using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [Header("Booleans")]
    public bool FlashLight = false;
    public bool Gun = false;
    public bool Hands = true;
    [Header("Hud Weapons")]
    public Image hand, gun, flashlight;
    [Header("Player Settings")]
    public Animator animPlayer;
    [Header("Weapons Objects")]
    public GameObject HandsObject;
    public GameObject FlashLightObject;
    public GameObject GunObject;

    void Start()
    {
        FlashLight = false;
        Gun = false;
        Hands = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            FlashLight = false;
            Gun = false;
            Hands = true;

            if (Hands == true)
            {
                hand.color = Color.green;
                gun.color = Color.white;
                flashlight.color = Color.yellow;

                animPlayer.SetBool("flashlightIdle", false);
                animPlayer.SetBool("gunIdle", false);
                animPlayer.SetBool("rechargeGun", false);

                HandsObject.SetActive(true);
                FlashLightObject.SetActive(false);
                GunObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            FlashLight = false;
            Gun = true;
            Hands = false;

            if (Gun == true)
            {
                hand.color = Color.white;
                gun.color = Color.green;
                flashlight.color = Color.yellow;

                animPlayer.SetBool("flashlightIdle", false);
                animPlayer.SetBool("gunIdle", true);
                animPlayer.SetBool("rechargeGun", false);

                HandsObject.SetActive(false);
                FlashLightObject.SetActive(false);
                GunObject.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            FlashLight = true;
            Gun = false;
            Hands = false;

            if (FlashLight == true)
            {
                hand.color = Color.white;
                gun.color = Color.white;
                flashlight.color = Color.green;

                animPlayer.SetBool("flashlightIdle", true);
                animPlayer.SetBool("gunIdle", false);
                animPlayer.SetBool("rechargeGun", false);

                HandsObject.SetActive(false);
                FlashLightObject.SetActive(true);
                GunObject.SetActive(false);
            }
        }
    }
}
