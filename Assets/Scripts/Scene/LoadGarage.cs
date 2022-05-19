using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGarage : MonoBehaviour
{
    public SaveSysten _save;
    private void Start()
    {
        _save = GameObject.Find("GameManager").GetComponent<SaveSysten>();
    }
    //! trigget load garage and save pos 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            _save.saveGarage();
            PlayerPrefs.SetInt("load", 2);
            SceneManager.LoadScene(3);
        }
    }
}
