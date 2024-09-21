using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MonsterIA : MonoBehaviour
{
    [Header("Player Settings")]
    public Transform player;
    public float distancePlayer;
    public float distanceAttach;
    public lifePlayer lifeP;
    [Header("Monster Settings")]
    public Animator animMonster;
    public AudioSource monsterGrounSound;
    public bool monsterActived = false;
    public lifeMonster lifeM;
    [Header("Artificial Intelligence")]
    public NavMeshAgent monsterAI;

    [Header("Settings Attack")]
    public float timeAccount;
    public float timeToAttack = 2f;
    public waypointsMonster waypointsMonsterr;
    public NavMeshAgent navMeshMonster;

    // Start is called before the first frame update
    void Start()
    {
        timeAccount = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        monsterAI.SetDestination(player.position);
        distancePlayer = Vector3.Distance(transform.position, player.position);

        // Incrementa timeAccount a cada frame
        timeAccount += Time.deltaTime;

        if (distancePlayer <= distanceAttach && monsterActived == true && timeAccount >= timeToAttack && lifeM.lifeMonsterPercent > 0)
        {
            Debug.Log("Executing attack animation and logic...");
            monsterGrounSound.Play();
            animMonster.SetBool("fight", true);
            animMonster.SetBool("fightAnimation", false);
            animMonster.SetBool("Death", false);
            lifeP.life -= 5;
            timeAccount = 0; // Reinicia o contador de tempo após o ataque
        }
        else
        {
            monsterGrounSound.Pause();
            animMonster.SetBool("fight", false); // Reseta a animação de luta quando o ataque não está acontecendo
        }

        if(monsterActived == true)
        {
            waypointsMonsterr.enabled = false;
            navMeshMonster.enabled = true;
        }
    }
}