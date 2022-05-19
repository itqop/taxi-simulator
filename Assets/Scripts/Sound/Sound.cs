using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sound : MonoBehaviour
{
    private Cont _cont;
    private AudioSource _audio;
    public AudioSource _audioEng;
    public AudioClip[] _audioClip;
    public AudioClip[] radioClip;
    public AudioSource radio;
    private bool turn;
    private void Awake()
    {
        radio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        _cont = GetComponent<Cont>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R) & !_cont.startCar)
        {
            _audio.volume = 0.8f;
            _audio.clip = _audioClip[0];
            _audio.loop = false;
            _audio.Play();
        }
        
        if (_cont.startCar & !_audioEng.isPlaying)
        {
            _audioEng.Play();
            _audioEng.loop = true;
        }
        
        if (!_cont.startCar)
        {
            _audioEng.Stop();
        }
        
        if (_cont.startCar & Input.GetButton("Vertical"))
        {
            if(!_audio.isPlaying)
                _audio.Play();
            
            _audio.volume += 0.5f * Time.deltaTime;
            _audio.clip = _audioClip[1];
            _audio.loop = true;
        }

        if (!Input.GetButton("Vertical") & _cont.startCar)
        {
            _audio.volume -= 0.5f * Time.deltaTime;
        }
        
        
        if (Input.GetKeyDown(KeyCode.R) & _cont.startCar)
        {
            _audio.Stop();
        }

        if (Input.GetButtonDown("radio"))
        {
            turn = !turn;
            if (turn)
            {
                if (!radio.isPlaying)
                {
                    radio.clip = radioClip[Random.Range(0, radioClip.Length-1)];
                    radio.Play();
                }
            }

            if (!turn)
            {
                radio.Stop();
            }
        }
    }
}
