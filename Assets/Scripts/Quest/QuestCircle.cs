using UnityEngine;
using UnityEngine.UI;

public class QuestCircle : MonoBehaviour
{
    public QuestGiver _questGiver;
    public GameObject qstCir;
    public float timerkd = 600;
    public Collider _qstgCollider;

    public GameObject iconQst;
    // Update is called once per frame
    void Update()
    {
        if (!qstCir.activeSelf)
        {
            timerkd -= Time.deltaTime;
            _qstgCollider.enabled = false;
            iconQst.gameObject.SetActive(false);
        }

        if (timerkd <= 0 & _questGiver._quest != 5)
        {
            iconQst.gameObject.SetActive(true);
            _qstgCollider.enabled = true;
            qstCir.SetActive(true);
            timerkd = 600;
        }
    }
}
