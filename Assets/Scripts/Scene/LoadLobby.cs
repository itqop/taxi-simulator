using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLobby : MonoBehaviour
{
    private AsyncOperation _asyncOperation;
    public Text _text;
    public Image _image;
    
    private void Awake()
    {
        StartCoroutine(loadscene());
    }
    //! load scena + zagruzka
    IEnumerator loadscene()
    {
        yield return new WaitForSeconds(1f);
        _asyncOperation = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("load"));
        while (!_asyncOperation.isDone)
        {
            float progress = _asyncOperation.progress / 0.9f;
            _image.fillAmount += progress;
            _text.text = string.Format("{0:0}%", progress * 100f) +"";
            yield return 0;
        }
    }
}
