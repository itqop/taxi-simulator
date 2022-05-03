using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour
{
    private Vector3 axis;
    private GameObject Player;
    public Rigidbody2D t;
    public float speed;
    public float Turnspeed;
    public Vector2 move;
    public GameObject pref;
    public float kd;
    public Progress _progStat;
    public PauseMenu _Pause;
    public GameObject hitEffect;
    private void Start()
    {
        _progStat = GameObject.Find("Panel").GetComponent<Progress>();
        _Pause = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        Player = GameObject.Find("Player");
        var dir = Random.Range(0, 2);
        speed = Random.Range(8, 10);
        t = GetComponent<Rigidbody2D>();
        if (dir == 0)
        {
            axis = Vector3.back;
        }
        else
        {
            axis = Vector3.forward;
        }

        Turnspeed = 2;
    }

    void Update()
    {
        Vector3 dir = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        t.rotation = angle;
        dir.Normalize();
        move = dir;
    }

    private void FixedUpdate()
    {
        if (_Pause.time == 0)
        {
            //если противник стрелок
            if (gameObject.name == "Shooter")
            {
                if (Vector2.Distance(transform.position, Player.transform.position) > 7)
                {
                    moveEnemy(move);
                }

                if (Vector2.Distance(transform.position, Player.transform.position) < 5)
                {
                    moveEnemy2(move);
                    if (kd <= 0)
                    {
                        shoot();
                        kd = 0.5f;
                    }

                }

                if (Vector2.Distance(transform.position, Player.transform.position) < 7 &&
                    Vector2.Distance(transform.position, Player.transform.position) > 5)
                {
                    transform.RotateAround(Player.transform.position, axis, Turnspeed);
                    if (kd <= 0)
                    {
                        shoot();
                        kd = 0.5f;
                    }
                }

                kd -= Time.deltaTime;
            }

            //если противник суицидник
            if (gameObject.name == "Bomber")
            {
                BomberMove(move);
            }
        }
        

    }

    //сближение с игроком
    void moveEnemy(Vector2 direction)
    {
        t.MovePosition((Vector2) transform.position + (direction * speed * Time.deltaTime));
    }

    //в обратную сторону
    void moveEnemy2(Vector2 direction)
    {
        t.MovePosition((Vector2) transform.position + (direction * -speed * Time.deltaTime));
    }

    //огонь
    void shoot()
    {
        Instantiate(pref, transform.position, transform.rotation);
    }
    
    //сближение с игроком для суицидника
    void BomberMove(Vector2 direction)
    {
        t.MovePosition((Vector2) transform.position + (direction * (speed+5) * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.name == "Bomber" & col.name == "Player")
        {
            _progStat.Prog.fillAmount -= 0.1f;
            if (_progStat.Prog.fillAmount == 0)
            {
                _progStat.check = true;
            }
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect,1f);
            Destroy(gameObject);
        }
    }
}
