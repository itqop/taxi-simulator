using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuestGiver : MonoBehaviour
{
    public TextAsset questTitle;
    public TextAsset questDiscription;
    public GameObject _questTab;
    public int _quest;
    public bool checkQuest;
    public bool checkQuestEnd;
    public bool stepQuest;
    public Text Title;
    public Text Disc;
    public GameObject[] point;
    public QuestPoint _pointQ;
    public GameObject _pointImg;
    public float congr;
    private CarControllerAI _car;
    private float kdspeed;
    //Q3 проверка на удачность прохождения
    public bool notcompl;
    
    //q3 start car
    public bool startCar;
    
    //предупреждение для q3
    public Text[] _warningQ3;
    public float timerQ3 = 10;

    public Text timerforq;
    public float timer;
    [Serializable]public class Qst
    {
        public string q1;
        public string q2;
        public string q3;
        public string q4;
    }
    [Serializable]public class Qst2
    {
        public string q1;
        public string q2;
        public string q3;
        public string q4;
    }

    public Qst questList;
    public Qst2 questList2;
    
    //! JSON READ 
    void Start()
    {
        questList = JsonUtility.FromJson<Qst>(questTitle.text);
        questList2 = JsonUtility.FromJson<Qst2>(questDiscription.text);
        _quest = PlayerPrefs.GetInt("Quest");
        startCar = false;
        kdspeed = 5;
        timer = 60;
    }

    //! QUEST MANAGER
    private void FixedUpdate()
    {
        switch (_quest)
        {
            case 1:
                Title.text = questList.q1;
                Disc.text = questList2.q1;
                congr = 300;
                if (checkQuest)
                {
                    point[0].SetActive(true);
                    _pointImg.SetActive(true);
                    _pointQ.target = point[0].transform;
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                if(checkQuestEnd)
                {
                    checkQuestEnd = false;
                    _quest = 2;
                    point[0].SetActive(false);
                    _pointImg.SetActive(false);
                    
                }
                break;
            case 2:
                Title.text = questList.q2;
                Disc.text = questList2.q2;
                congr = 500;
                if (checkQuest)
                {
                    _pointQ.target = point[3].transform;
                    _pointImg.SetActive(true);
                    if (_pointQ.dist < 60f & _pointQ.dist != 0)
                    {
                        point[3].SetActive(true);
                        startCar = true;
                    }
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                if(checkQuestEnd)
                {
                    _pointImg.SetActive(false);
                    _quest = 3;
                    checkQuestEnd = false;
                }

                _car = point[3].GetComponent<CarControllerAI>();
                
                if (_car.currentWayPoint.name == "Waypoint 39" & checkQuest)
                {
                    checkQuest = false;
                    checkQuestEnd = true;
                }
                
                if (startCar)
                {
                    checkdist();
                }
                break;
            case 3:
                _warningQ3[1].gameObject.SetActive(false);
                _warningQ3[2].gameObject.SetActive(false);
                _warningQ3[0].gameObject.SetActive(false);
                congr = 800;
                Title.text = questList.q3;
                Disc.text = questList2.q3;
                if (checkQuest)
                {
                    point[3].gameObject.SetActive(false);
                    if (!stepQuest)
                    {
                        point[1].SetActive(true);
                        _pointImg.SetActive(true);
                        _pointQ.target = point[1].transform;
                    }
                    else
                    {
                        point[1].SetActive(false);
                        point[2].SetActive(true);
                        _pointQ.target = point[2].transform;
                    }
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                if(checkQuestEnd)
                {
                    checkQuestEnd = false;
                    _quest = 4;
                    point[2].SetActive(false);
                    _pointImg.SetActive(false);
                    _warningQ3[1].gameObject.SetActive(false);
                    _warningQ3[2].gameObject.SetActive(false);
                    _warningQ3[0].gameObject.SetActive(false);
                }
                break;
            case 4:
                congr = 1000;
                Title.text = questList.q4;
                Disc.text = questList2.q4;
                if (checkQuest)
                {
                    timerforq.gameObject.SetActive(true);
                    timer -= Time.deltaTime;
                    timerforq.text = "Time Left " + (int)timer ;
                    if (!stepQuest)
                    {
                        point[4].SetActive(true);
                        _pointImg.SetActive(true);
                        _pointQ.target = point[4].transform;
                    }
                    else
                    {
                        point[4].SetActive(false);
                        point[5].SetActive(true);
                        _pointQ.target = point[5].transform;
                    }
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                if(checkQuestEnd)
                {
                    checkQuestEnd = false;
                    point[5].SetActive(false);
                    _pointImg.SetActive(false);
                    timerforq.gameObject.SetActive(false);
                    _quest = 5;
                }
                if (timer <= 0)
                {
                    point[4].SetActive(false);
                    point[5].SetActive(false);
                    checkQuest = false;
                    timerforq.gameObject.SetActive(false);
                    _pointImg.SetActive(false);
                }
                break;
        }
    }

    //! TRIGGER GIVERQST
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Car")
        {
            _questTab.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    //! TRIGGER GIVERQST
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Car")
        {
            _questTab.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    //! Otmena qst
    public void cancelQuest()
    {
        _questTab.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    //! prinyatie qst
    public void AcceptQuest()
    {
        _questTab.SetActive(false);
        checkQuest = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    //! timer for 2 qst

    void checkdist()
    {
        
        kdspeed -= Time.deltaTime;
        if (kdspeed <= 0)
        {
            _car.prevMoveSpeed = Random.Range(5,15);
            kdspeed = 5;
        }
        if (_pointQ.dist > 50 & _pointQ.dist < 70)
        {
            timerQ3 = 10;
            _warningQ3[1].gameObject.SetActive(false);
            _warningQ3[2].gameObject.SetActive(false);
            _warningQ3[0].gameObject.SetActive(false);
        }
        
        if (_pointQ.dist >= 70)
        {
            timerQ3 -= Time.deltaTime;
            _warningQ3[1].gameObject.SetActive(true);
            _warningQ3[2].gameObject.SetActive(true);
            _warningQ3[2].text = (int)timerQ3 + "";
        }

        if (_pointQ.dist <= 50)
        {
            timerQ3 -= Time.deltaTime;
            _warningQ3[0].gameObject.SetActive(true);
            _warningQ3[2].gameObject.SetActive(true);
            _warningQ3[2].text = (int)timerQ3 + "";
        }

        if (timerQ3 < 0)
        {
            notcompl = true;
            checkQuest = false;
            checkQuestEnd = true;
            _warningQ3[1].gameObject.SetActive(false);
            _warningQ3[2].gameObject.SetActive(false);
            _warningQ3[0].gameObject.SetActive(false);
        }
    }
}
