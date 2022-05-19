using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGarage : MonoBehaviour
{
    public ChoiceBtn _choiceBtn;
    private void Start()
    {
        _choiceBtn = GetComponent<ChoiceBtn>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //! VIXOD IZ GARAGE.
    public void Exit()
    {
        PlayerPrefs.SetInt("CurrentCar",_choiceBtn.CurrentPos);
        PlayerPrefs.SetInt("load", 1);
        SceneManager.LoadScene(3);
    }
    
}
