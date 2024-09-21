using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;

public class lifeMonster : MonoBehaviour
{
    [Header("Life Monster")]
    public float lifeMaximum;
    public float lifeMonsterPercent;
    public ParticleSystem blood;
    public bool isDead = false;

    [Header("Secondary Scripts")]
    public MonsterIA monsterSettings;
    public monsterAccount monsterGoals;
    public NavMeshAgent navMeshMonster;
    public waypointsMonster waypointsMonsterr;
    [Header("Life Monster HUD")]
    public Image lifeBar;
    // Start is called before the first frame update
    void Start()
    {
        lifeMonsterPercent = lifeMaximum;

    }

    // Update is called once per frame
    void Update()
    {
        lifeBar.fillAmount = lifeMonsterPercent / lifeMaximum;

        if (lifeMonsterPercent <= 0 && !isDead)
        {
            blood.Play();
            monsterGoals.monsterDie += 1;
            isDead = true;
            lifeMonsterPercent = 0;
            navMeshMonster.enabled = false;
            waypointsMonsterr.enabled = false;
            monsterSettings.monsterActived = false;
            monsterSettings.animMonster.SetBool("fight", false);
            monsterSettings.animMonster.SetBool("fightAnimation", false);
            monsterSettings.animMonster.SetBool("Death", true);
            monsterSettings.monsterGrounSound.Play();
        }
        else
        {
            blood.Pause();
        }
    }
}
