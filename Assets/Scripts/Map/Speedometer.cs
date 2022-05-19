using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;
    public Text speedLabel;
    // Start is called before the first frame update
    void Start()
    {
        speedLabel = GameObject.Find("speed").GetComponent<Text>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude * 3.6f;
        speedLabel.text = ((int) speed) + "км/ч";
    }
}
