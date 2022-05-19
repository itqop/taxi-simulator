using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveSysten _save;
    // Start is called before the first frame update
    void Start()
    {
        _save = GetComponent<SaveSysten>();
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
