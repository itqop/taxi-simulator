using UnityEngine;
using UnityEngine.UI;

public class SwitchBtn : MonoBehaviour
{
    public GameObject[] AllCar;
    public Button NextBtn;
    public Button BackBtn;
    public int pos;

    private void Update()
    {
        
        if (pos == 0)
        {
            BackBtn.interactable = false;
        }
        else
        {
            BackBtn.interactable = true;
        }

        if (pos == AllCar.Length-1)
        {
            NextBtn.interactable = false;
        }
        else
        {
            NextBtn.interactable = true;
        }
    }

    public void next()
    {
        AllCar[pos].SetActive(false);
        pos += 1;
        AllCar[pos].SetActive(true);
    }

    public void back()
    {
        AllCar[pos].SetActive(false);
        pos -= 1;
        AllCar[pos].SetActive(true);
    }
}
