using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderBehaviour : MonoBehaviour
{
	public AudioMixerGroup audioMixerGroup;


	Slider slider;
	void Awake()
	{
		slider = GetComponent<Slider>();
		slider.onValueChanged.AddListener(SetVolume);
        
    }
    private void Start()
    {
        SetVolume(SoundManager.Volume);
    }

    void SetVolume(float value)
	{
		SoundManager.Volume = value;
		audioMixerGroup.audioMixer.SetFloat("masterVolume", SoundManager.Volume);

        if (slider.value != value)
        {
            slider.value = value;
        }
    }
}

