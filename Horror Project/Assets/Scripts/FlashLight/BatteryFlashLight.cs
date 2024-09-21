using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.GlobalIllumination;

public class BatteryFlashLight : MonoBehaviour
{
    [Header("Light Settings")]
    public Light flashLight;
    public float distance;
    [Header("Battery Settings")]
    public bool activeFlashLight = false;
    public float percentDischargeBattery;
    public float percentChargeBattery;
    public float batteryMaximum;
    public float batteryPercent;
    public float battery;
    [Header("FlashLight Audio")]
    public AudioSource clickFlashLight;
    [Header("Battery HUD")]
    public Image batteryBar;
    public Text textLowBattery;
    public GameObject hudMessage;
    [Header("Secondary Scripts")]
    public MonsterIA monsterSettings;

    // Start is called before the first frame update
    void Start()
    {
        batteryPercent = batteryMaximum;
        textLowBattery.enabled = false;
        hudMessage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        batteryBar.fillAmount = batteryPercent / batteryMaximum;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeFlashLight =! activeFlashLight;
            clickFlashLight.Play();
        }

        if (activeFlashLight == true)
        {
                RaycastHit hitInfo;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, distance))
                {

                    MonsterIA monster = hitInfo.transform.GetComponent<MonsterIA>();
                    print("Raycast hit: " + hitInfo.transform.name);
                    if (monster != null)
                    {
                    monsterSettings.monsterActived = true;
                    }
                }
                else
                {
                     print("Objeto atingido não possui componente MonsterIA.");
                }
                if (batteryPercent > 0)
                {
                    flashLight.enabled = true;
                    battery = batteryPercent -= percentDischargeBattery * Time.deltaTime;
                    print("Bateria Descarregando");
                }
                else
                {
                    StartCoroutine(textAnimation());
                    textLowBattery.text = "YOUR FLASHLIGHT DON'T HAVE BATTERY, WAIT A SECOND TO THE CHARGE.";
                    flashLight.enabled = false;
                    activeFlashLight = false;
                }
        }

        else
        {
            flashLight.enabled = false;

            if (batteryPercent < batteryMaximum)
            {
                battery = batteryPercent += percentChargeBattery * Time.deltaTime;

                if (batteryPercent >= batteryMaximum)
                {
                    batteryPercent = batteryMaximum;
                    battery = batteryMaximum;
                }
            }
        }

        /*if (monsterSettings.monsterActived == true)
        {
            if (monsterSettings.distancePlayer < monsterSettings.distanceAttach)
            {
                StartCoroutine(monsterSettings.animationFight());
            }
            else
            {
                monsterSettings.animMonster.SetBool("fight", false);
                monsterSettings.animMonster.SetBool("fightAnimation", false);
            }
            print("Monstro Ativado");
    }*/
    }

    private IEnumerator textAnimation()
    {
        hudMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(0f);
        textLowBattery.enabled = true;
        yield return new WaitForSeconds(3f);
        textLowBattery.enabled = false;
        hudMessage.gameObject.SetActive(false);
    }
}
