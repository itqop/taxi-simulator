
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class OrderTaxi : MonoBehaviour
{
    public Transform prefab;
    public Transform parent;
    public Transform OrderBtn;
    public float timeLeft;
    public bool AcceptOrder;
    public float price;
    private void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            AcceptOrder = false;
            StartCoroutine(AddOrder());
        }
    }
    //! otobrazenie zakazov
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (OrderBtn != null)
            {
                if (!AcceptOrder)
                {
                    timeLeft -= Time.deltaTime;
                    if ( timeLeft > 0 )
                    {
                        OrderBtn.GetChild(2).GetComponent<Text>().text = Mathf.RoundToInt(timeLeft) + "";
                        OrderBtn.GetChild(0).GetComponent<Text>().text = "Price:" + price + " $";
                    }
                    else
                    {
                        Destroy(OrderBtn.gameObject);
                        StartCoroutine(AddOrder());
                    }
                }
                else
                {
                    OrderBtn.GetChild(0).GetComponent<Text>().text = "[Confirm] - Price:" + price + " $";
                    OrderBtn.GetChild(2).GetComponent<Text>().text = "V";
                }
            }
            else
            {
                timeLeft = 15;
            }
        }
       
    }
    //! sozdanie zakazov
    IEnumerator AddOrder()
    {
        yield return new WaitForSeconds(Random.Range(5,10));
        OrderBtn = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity, parent);
        if (PlayerPrefs.GetInt("CurrentCar") == 0)
        {
            price = Random.Range(30, 50);
        }
        if (PlayerPrefs.GetInt("CurrentCar") == 1)
        {
            price = Random.Range(51, 80);
        }
        if (PlayerPrefs.GetInt("CurrentCar") == 2)
        {
            price = Random.Range(90, 150);
        }
    }
}
