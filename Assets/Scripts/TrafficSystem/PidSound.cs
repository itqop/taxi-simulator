using UnityEngine;

public class PidSound : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip[] _clip;
    private TouchWithPlayer _touch;
    private bool play;
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _touch = GetComponent<TouchWithPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_touch.tch2)
        {
            if (!_audio.isPlaying)
            {
                _audio.clip = _clip[Random.Range(0,_clip.Length)];
                _audio.loop = false;
                _audio.Play();
            }
        }
    }
}
