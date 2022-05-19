using System;
using UnityEngine;
using UnityEngine.UI;

public class QuestPoint : MonoBehaviour
{
    public Image img;
    public Transform target;
    public Text _textMetr;
    public Vector3 Offset;
    public float dist;
    private void Update()
    {
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        
        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;

        if (target != null)
        {
            Vector2 pos = UnityEngine.Camera.main.WorldToScreenPoint(target.position + Offset);

            if (Vector3.Dot(target.position - transform.position, transform.forward) < 0)
            {
                if (pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }
                else
                {
                    pos.x = minX;
                }
            }
            
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            img.transform.position = pos;
            dist = Vector3.Distance(target.position, transform.position);
            _textMetr.text = ((int)dist).ToString();
        } 
       

    }
}
