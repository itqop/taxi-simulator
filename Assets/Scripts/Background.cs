using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer _mesh;

    [SerializeField] [Range(0f, 1f)] public float lerpTime;
    [SerializeField] public Color[] _colors;

    public int colorIndex = 0;

    public float t = 0f;

    private int len;
    private void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        len = _colors.Length;
    }

    private void Update()
    {
        
        _mesh.material.color = Color.Lerp(_mesh.material.color, _colors[colorIndex],lerpTime * Time.deltaTime);
        
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0;
            if (colorIndex == len-1)
            {
                colorIndex = 0;
            }
            else
            {
                colorIndex += 1;
            }
            
            
        }
    }
}
