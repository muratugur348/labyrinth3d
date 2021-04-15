using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicvalue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("volume"))  //totalScoreKey anahtarıyla kaydedilmiş bir veri var mı ?
        {
            slider.value = PlayerPrefs.GetFloat("volume"); // totalScoreKey anahtarıyla kaydedilmiş veriyi getir
        }
        else
        {
            slider.value=(0.5f);
        }
        audioSource.volume = slider.value;
        sliderval.text = (System.Convert.ToInt16(slider.value*100)).ToString();
    }
    public UnityEngine.UI.Slider slider;
    public AudioSource audioSource;
    public UnityEngine.UI.Text sliderval;
    public Material sesdegeri;
    public void AudioValue()
    {
        audioSource.volume = slider.value;
        sliderval.text = (System.Convert.ToInt16(slider.value * 100)).ToString();
        sesdegeri.name = slider.value.ToString();
        PlayerPrefs.SetFloat("volume", audioSource.volume); // totalScoreKey anahtarıyla totalScore verisini sakla
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
