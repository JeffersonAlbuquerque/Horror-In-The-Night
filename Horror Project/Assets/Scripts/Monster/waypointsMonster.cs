using UnityEngine;

public class waypointsMonster : MonoBehaviour
{
    public Transform[] waypoints; // Array dos waypoints a seguir
    public float velocidade; // Velocidade de movimento
    public float rotaçãoSuave; // Velocidade de rotação suave
    public int waypointAtual; // Waypoint atual a ser seguido

    private void Start()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("Adicione waypoints ao array!");
            enabled = false; // Desativa o script se não houver waypoints
        }
        
    }

    private void Update()
    {
        // Verifica se já chegou no waypoint atual
        if (waypointAtual < waypoints.Length)
        {
            // Calcula a direção para o waypoint atual
            Vector3 direcao = waypoints[waypointAtual].position - transform.position;
            direcao.Normalize();

            // Move o objeto na direção do waypoint
            transform.Translate(direcao * velocidade * Time.deltaTime, Space.World);

            // Calcula a rotação suave em direção ao waypoint
            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, rotaçãoSuave * Time.deltaTime);

            // Verifica se o objeto chegou ao waypoint atual
            // Verifica se o objeto chegou ao waypoint atual com uma margem de 1 unidade
            if (Vector3.Distance(transform.position, waypoints[waypointAtual].position) < 1.0f)
            {
                waypointAtual++; // Move para o próximo waypoint
            }
        }
        else
        {
            // Se chegou ao último waypoint, você pode fazer algo, como reiniciar o percurso.
            waypointAtual = 0;
        }
    }
}
