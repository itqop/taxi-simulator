using UnityEngine;

//! DonDestroyOnLoAD .
public class DonDestroyOnLoAD : MonoBehaviour
{
    public static DonDestroyOnLoAD instance;
    public int checkCar;
    public int Check;
    
    //! PROVERKA SOXR.
    private void Start()
    {
        if (PlayerPrefs.GetInt("FirstSave") == 1)
        {
            Check = PlayerPrefs.GetInt("FirstSave");
        }
        else
        {
           PlayerPrefs.SetInt("FirstSave",Check); 
        }
        checkCar = PlayerPrefs.GetInt("Car1");
    }
    
    //! DontDestroyOnLoad instance ;.
    private void Awake()
    {
        DontDestroyOnLoad (this);
         
        if (instance == null) {
            instance = this;
        } else {
            DestroyObject(gameObject);
        }
    }
    
    //! PERVII SAVE.
    public void FirstSaveCompl()
    {
        Check = 1;
        PlayerPrefs.SetInt("FirstSave",Check);
    }
}
