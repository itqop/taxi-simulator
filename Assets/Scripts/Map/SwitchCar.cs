using UnityEngine;

public class SwitchCar : MonoBehaviour
{
    public GameObject[] AllCar;

    private void Start()
    {
        var LastCar = GameObject.Find("Car");
        Destroy(LastCar.gameObject);
        LastCar = Instantiate(AllCar[PlayerPrefs.GetInt("CurrentCar")], new Vector3(PlayerPrefs.GetFloat("x"),
            PlayerPrefs.GetFloat("y"),PlayerPrefs.GetFloat("z")),Quaternion.identity);
        LastCar.name = "Car";
        LastCar.transform.Rotate(0f,PlayerPrefs.GetFloat("ry"),0f);
    }
}
