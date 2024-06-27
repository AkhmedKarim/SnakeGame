using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
	Slider slider;
	void Awake()
	{
		slider = GetComponent<Slider>();
		slider.onValueChanged.AddListener(
			(float value) => SoundManager.Volume = value
		);
	}
}

