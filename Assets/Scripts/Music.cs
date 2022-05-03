using UnityEngine;
using Random = UnityEngine.Random;

public class Music : MonoBehaviour
{
    public AudioClip[] _music;
    public int i;
    public AudioSource _Source;

    private void Start()
    {
        i = Random.Range(0, _music.Length - 1);
        _Source.clip = _music[i];
        _Source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_Source.isPlaying)
        {
            i += 1;
            if (i > _music.Length-1)
            {
                i = 0;
            }
            _Source.clip = _music[i];
            _Source.Play();
        }
        
    }
}
