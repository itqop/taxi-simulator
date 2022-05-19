using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSystem : MonoBehaviour
{
    public GameObject[] AppPage;

    public void TaxiPage()
    {
        if (!AppPage[0].activeSelf)
        {
            AppPage[0].SetActive(true);
        }
        else
        {
            AppPage[0].SetActive(false);
        }
    }
    public void ShopPage()
    {
        if (!AppPage[1].activeSelf)
        {
            AppPage[1].SetActive(true);
        }else
        {
            AppPage[1].SetActive(false);
        }
    }
    public void DarkPage()
    {
        if (!AppPage[2].activeSelf)
        {
            AppPage[2].SetActive(true);
        }else
        {
            AppPage[2].SetActive(false);
        }
    }
}
