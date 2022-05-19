using UnityEngine.UI;
using UnityEngine;


//! systema seiva progressa and position 

public class Stats : MonoBehaviour
{
    [Header("MoneySystem")] 
    public float startMoney = 500;
    public Text _moneyText;
    public float Money;
    
    
    [Header("FuelSystem")]
    public Image hpBar;
    public float MaxFuel = 1f;
    public float fireRate = 2f;
    private float fireCountdown = 0f;
    public float CurrentFuel;
    public Cont _cont;
    private void Start()
    {
        if (PlayerPrefs.GetInt("FirstSave") == 0)
        {
            Money = startMoney;
            CurrentFuel = MaxFuel;
        }
    }
    private void FixedUpdate()
    {
        _cont = GameObject.Find("Car").GetComponent<Cont>();
        if (PlayerPrefs.GetInt("CurrentCar") == 0)
        {
            fireRate = 1.1f;
        }
        if (PlayerPrefs.GetInt("CurrentCar") == 1)
        {
            fireRate = 1.5f;
        }
        if (PlayerPrefs.GetInt("CurrentCar") == 2)
        {
            fireRate = 1.3f;
        }
        FelSystem();
        MoneySystem();
    }

    void FelSystem()
    {
        if (fireCountdown <= 0f && _cont.startCar)
        {
            CurrentFuel -= 0.002f;
            hpBar.fillAmount = CurrentFuel;
            fireCountdown = 1f / fireRate;
        }
        else
        {
            fireCountdown -= Time.deltaTime;
        }
    }

    void MoneySystem()
    {
        _moneyText.text = Money + " $";
    }
}
