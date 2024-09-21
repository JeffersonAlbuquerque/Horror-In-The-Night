using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    [Header("Customização Arma")]
    public float alcance = 20;
    public float tempoParaCadaTiro;
    public float dano;

    [Header("Variáveis Tempo")]
    public float tempoParaTiro;
    public float tempoDaAnimacaoRecarga;

    [Header("Config Arma")]
    public int balas = 30;
    public int MaxBalas = 30;
    public int municao = 90;
    public int balasFaltando;
    private bool atirandoRepetidamente = false;

    [Header("Audio Arma")]
    public AudioSource S_atirando;
    public AudioSource S_semBalas;

    [Header("HUD Arma")]
    public Text txtBalas;

    [Header("Particulas")]
    public ParticleSystem ParticulaTiro;

    public Animator animPlayer;

    public MonsterIA monsterSettings;

    private void Start()
    {
        tempoParaTiro = tempoParaCadaTiro;

    }

    void Update()
    {
        txtBalas.text = balas + "/" + municao.ToString();

        if (Input.GetKeyDown(KeyCode.F))
        {
            AtirarUmaVez();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            recarregarArmaF();
        }

        if (atirandoRepetidamente)
        {
            if (tempoParaTiro <= 0)
            {
                AtirarRepetidamente();
                tempoParaTiro = tempoParaCadaTiro;
            }
            else
            {
                tempoParaTiro -= Time.deltaTime;
            }
        }
    }

    public void AtirarUmaVez()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, alcance))
        {
            lifeMonster jogadorInimigo = hitInfo.transform.GetComponent<lifeMonster>();

            if (jogadorInimigo != null)
            {
                monsterSettings.monsterActived = true;
                //StartCoroutine(monsterSettings.animationFight());
                jogadorInimigo.lifeMonsterPercent -= 10;

            }

        }

        if (balas > 0)
        {
            ParticulaTiro.Play();
            S_atirando.Play();
            balas--;
        }
        else
        {
            S_atirando.Pause();
            S_semBalas.Play();
        }
    }

    public void AtirarRepetidamente()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, alcance))
        {
            lifeMonster jogadorInimigo = hitInfo.transform.GetComponent<lifeMonster>();
            if (jogadorInimigo != null)
            {
                monsterSettings.monsterActived = true;
                //StartCoroutine(monsterSettings.animationFight());
                jogadorInimigo.lifeMonsterPercent -= 10;
            }
        }

        if (balas > 0)
        {
            tempoParaTiro = tempoParaCadaTiro;
            ParticulaTiro.Play();
            S_atirando.Play();
            balas--;
        }
    }

    public void recarregarArmaF()
    {
        // Determine quantas balas estão faltando na arma
        int balasFaltando = MaxBalas - balas;

        // Verifique quantas balas de munição você tem disponíveis
        int balasDeMunicao = municao;

        // Calcule a quantidade de balas a recarregar
        int balasParaRecarregar = Mathf.Min(balasFaltando, balasDeMunicao);

        if (balasParaRecarregar > 0)
        {
            // Inicie a animação de recarga
            animPlayer.SetBool("rechargeGun", true);

            // Aguarde o término da animação de recarga antes de realizar a recarga real
            StartCoroutine(EsperarAnimacaoRecarga(balasParaRecarregar));
        }
    }

    private IEnumerator EsperarAnimacaoRecarga(int balasParaRecarregar)
    {
        yield return new WaitForSeconds(tempoDaAnimacaoRecarga);

        // Execute a recarga real
        balas += balasParaRecarregar;
        municao -= balasParaRecarregar;

        // Certifique-se de que o número de balas não exceda o limite máximo
        balas = Mathf.Min(balas, MaxBalas);

        // Desative a animação de recarga
        animPlayer.SetBool("rechargeGun", false);
    }
}
