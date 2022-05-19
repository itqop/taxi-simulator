using UnityEngine;
using Random = UnityEngine.Random;


//! RANDOMNII SPAWN PED
public class pedisSpawn : MonoBehaviour
{
    public GameObject pedPref;
    public int pedestriansToSpawn;
    public int count;
    private void Start()
    {
        count = 0;
    }

    private void FixedUpdate()
    {
        if (count < pedestriansToSpawn)
        {
            GameObject obj = Instantiate(pedPref);
            if (pedPref.gameObject.name == "TestTS")
            {
                obj.name = "pedestrian";
                TouchWithPlayer pbobj = obj.GetComponent<TouchWithPlayer>();
                pbobj._pd = gameObject.GetComponent<pedisSpawn>();
                Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
                obj.GetComponent<NavWaypoint>().currentWayPoint = child.GetComponent<WayPoint>();
                obj.transform.position = child.position;
            }
                
            if (pedPref.gameObject.name == "CarAi")
            {
                obj.name = "CarAi";
                Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
                obj.GetComponent<CarControllerAI>().currentWayPoint = child.GetComponent<WayPoint>();
                obj.transform.position = child.position;
            }
            count++;
        }
    }
}
