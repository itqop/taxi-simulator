using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerEnemy : MonoBehaviour
{

    public GameObject[] pref;
    public int spawnCount;
    public GameObject _Player;
    public float Timer;
    public Vector2 spawnpos;
    public int i;
    public StartGame _Game;
    public PauseMenu _timer;
    private void Start()
    {
        spawnCount = 25;
        Timer = 2;
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        
        if (transform.childCount < spawnCount & _Game.time == 0 & _timer.time == 0)
        {
            if (Timer <= 0 )
            {
                Timer = 1;
                spawnpos = _Player.transform.position;
                spawnpos += Random.insideUnitCircle.normalized * 15;
                i = Random.Range(0, 2);
                GameObject enemyspawn = Instantiate(pref[i], spawnpos, Quaternion.identity);
                enemyspawn.transform.parent = transform;
                if(i == 0)
                    enemyspawn.name = "Shooter";
                
                if(i == 1)
                    enemyspawn.name = "Bomber";
            } 
        }
    }
    
}
