using System;
using UnityEngine;
using UnityEngine.UI;

//! TUTORIAL READ JSON 
public class StartTutorial : MonoBehaviour
{
    public Text _text;
    public TextAsset tutTitle;
    private int num;
    public GameObject tutrorialCanvas;
    [Serializable]public class Tutrorial
    {
        public string q1;
        public string q2;
        public string q3;
        public string q4;
        public string q5;
        public string q6;
        public string q7;
        public string q8;
        public string q9;
    }
    
    public Tutrorial tutorialtList;
    // Start is called before the first frame update
    void Start()
    {
        num = 1;
        tutorialtList = JsonUtility.FromJson<Tutrorial>(tutTitle.text);
        if (PlayerPrefs.GetInt("tut") == 1)
        {
            tutrorialCanvas.SetActive(false);
        }
        else
        {
            tutrorialCanvas.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        switch (num)
        {
            case 1:
                _text.text = tutorialtList.q1;
                break;
            case 2:
                _text.text = tutorialtList.q2;
                break;
            case 3:
                _text.text = tutorialtList.q3;
                break;
            case 4:
                _text.text = tutorialtList.q4;
                break;
            case 5:
                _text.text = tutorialtList.q5;
                break;
            case 6:
                _text.text = tutorialtList.q6;
                break;
            case 7:
                _text.text = tutorialtList.q7;
                break;
            case 8:
                _text.text = tutorialtList.q8;
                break;
            case 9:
                _text.text = tutorialtList.q9;
                break;
        }
    }

    private void Update()
    {
        if (num > 9)
        {
            tutrorialCanvas.SetActive(false);
            PlayerPrefs.SetInt("tut",1);
        }
        if(Input.GetButtonDown("tut"))
        {
            num++;
        }
    }
}
