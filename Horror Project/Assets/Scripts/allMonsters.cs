using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allMonsters : MonoBehaviour
{
    public MonsterIA monster1;
    public MonsterIA monster2;
    public MonsterIA monster3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            monster1.monsterActived = true;
            monster2.monsterActived = true;
            monster3.monsterActived = true;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
