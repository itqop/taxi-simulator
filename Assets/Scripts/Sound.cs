using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public AudioMixer _audio;
    
    private void Start()
    {
        _audio.SetFloat("volume", 0);
        //QualitySettings.SetQualityLevel(0);
    }
    public void SetVolume(float volume)
    {
        SetMasterVolume(volume);
    }
    public void SetMasterVolume(float volume)
    {
        _audio.SetFloat("volume", volume);
    }
}
