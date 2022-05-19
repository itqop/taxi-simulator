using UnityEngine;
using UnityEngine.UI;

public class ChoiceBtn : MonoBehaviour
{
    public SwitchBtn _switchBtn;
    public Button _Choice; 
    public int CurrentPos;
    public Color startColor;
    public Image BGcolor;
    public DonDestroyOnLoAD _donDestroy;
    
    
    private void Start()
    {
        _donDestroy = GameObject.Find("DonDestroyOnLoAD").GetComponent<DonDestroyOnLoAD>();
        CurrentPos = PlayerPrefs.GetInt("CurrentCar");
        _switchBtn = GetComponent<SwitchBtn>();
        BGcolor = _Choice.GetComponent<Image>();
        startColor = BGcolor.color;
    }
    
    
    //! PROVERKA DOSTYPNOSTI CAR .
    private void Update()
    {
        
        if (_switchBtn.pos != CurrentPos)
        {
            if (_switchBtn.pos == 0)
            {
                _Choice.interactable = true;
            }
            
            if (_donDestroy.checkCar < 1 & _switchBtn.pos == 1)
            {
                _Choice.interactable = false;
            }
            
            if (_donDestroy.checkCar >= 1 & _switchBtn.pos == 1)
            {
                _Choice.interactable = true;
            }
            
            if (_donDestroy.checkCar <= 1 & _switchBtn.pos == 2)
            {
                _Choice.interactable = false;
            }
            
            if (_donDestroy.checkCar >= 2 & _switchBtn.pos == 2)
            {
                _Choice.interactable = true;
            }
            BGcolor.color = startColor;
        }

        if (_switchBtn.pos == CurrentPos)
        {
            _Choice.interactable = false;
            BGcolor.color = Color.green;
        }
    }

    //! VIBOR AVTO.
    public void choice()
    {
        _Choice.interactable = false;
        BGcolor.color = Color.green;
        CurrentPos = _switchBtn.pos;
    }
}
