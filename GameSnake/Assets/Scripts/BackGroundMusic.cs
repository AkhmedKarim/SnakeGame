using UnityEngine;
using UnityEngine.Audio;

public class BackGroundMusic : MonoBehaviour
{
	[SerializeField] AudioClip[] audioClips;
	AudioSource source;

    private void Awake()
    {
		source = GetComponent<AudioSource>();
		source.clip = GetClipToCurrentDifficultMode();
		source.Play();
    }
    void Start()
	{
		

    }

	void Update()
	{
			
	}

    AudioClip GetClipToCurrentDifficultMode()
	{
		switch (DifficultController.currentDifficult)
		{
			default:
			case  DifficultController.Difficult.Easy:
					case DifficultController.Difficult.Medium:
					return audioClips[0];
			case DifficultController.Difficult.Hard:
				return audioClips[1];

        }
	}
}

