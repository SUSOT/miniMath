using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private Slider masterSlider;
    private Slider bgmSlider;
    private Slider sfxSlider;

    private void Start()
    {
        masterSlider = transform.Find("Master").GetComponent<Slider>();
        bgmSlider = transform.Find("BGM").GetComponent<Slider>();
        sfxSlider = transform.Find("SFX").GetComponent<Slider>();

        masterSlider.value = SettingManager.instance.master;
        bgmSlider.value = SettingManager.instance.bgm;
        sfxSlider.value = SettingManager.instance.sfx;
    }

    public void SetMasterAudio()
    {
        float sliderValue = masterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
        SettingManager.instance.SetAudioSettings(0, sliderValue);
    }

    public void SetBGMAudio()
    {
        float sliderValue = bgmSlider.value;
        audioMixer.SetFloat("BGM", Mathf.Log10(sliderValue) * 20);
        SettingManager.instance.SetAudioSettings(1, sliderValue);
    }

    public void SetSFXAudio()
    {
        float sliderValue = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);
        SettingManager.instance.SetAudioSettings(2, sliderValue);
    }
}
