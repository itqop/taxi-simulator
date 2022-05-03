using System;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public Text LeftLvl;

    public Text RightLbl;

    public int NextLvl;
    public int PrefLvl;
    public Image Prog;
    public Text _highScore;
    public bool check;

    public int kolvo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Prog.fillAmount == 1)
        {
            PrefLvl = Int32.Parse(RightLbl.text);
            NextLvl = PrefLvl + 1;
            Prog.fillAmount = 0;
            LeftLvl.text = PrefLvl + " ";
            RightLbl.text = NextLvl + " ";
        }

        if (Int32.Parse(LeftLvl.text) >= 1)
        {
            if (check & Prog.fillAmount == 0)
            {
                PrefLvl = Int32.Parse(LeftLvl.text);
                NextLvl = PrefLvl;
                Prog.fillAmount = 1 - 0.1f;
                LeftLvl.text = (PrefLvl - 1) + " ";
                RightLbl.text = NextLvl + " ";
            }
            check = false;
        }

        if (PrefLvl >= 15)
        {
            _highScore.gameObject.SetActive(true);
            _highScore.text = "HighScore: " + kolvo;
            PlayerPrefs.SetInt("score",kolvo);
        }

        if (PrefLvl < 15)
        {
            kolvo = 0;
            _highScore.gameObject.SetActive(false);
        }
    }
}
