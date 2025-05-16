using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{

    private AudioSource backgroundACMusic;
    private Slider sliderAC;
    // Start is called before the first frame update
    void Start()
    {
        backgroundACMusic = gameObject.GetComponent<AudioSource>();
        sliderAC = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVolumeAC();
    }

    public void UpdateVolumeAC()
    {
        backgroundACMusic.volume = sliderAC.value;
    }
}
