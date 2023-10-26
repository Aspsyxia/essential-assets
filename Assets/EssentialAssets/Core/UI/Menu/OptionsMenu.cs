using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using System.Collections.Generic;
using TMPro;

namespace EssentialAssets.Core
{
    public class OptionsMenu: MonoBehaviour
    {
        [Header("Mixers")] 
        [SerializeField] private AudioMixer ambienceMixer;
        [SerializeField] private AudioMixer effectsMixer;
        
        [Header("Sliders")]
        [SerializeField] private Slider ambienceVolumeSlider;
        [SerializeField] private Slider effectsVolumeSlider;
        [SerializeField] private Slider brightnessSlider;
        [SerializeField] private Slider sensitivitySlider;

        [Header("Other")] 
        [SerializeField] private Toggle fullscreenToggle;
        [SerializeField] private TMP_Dropdown resolutionDropdown;

        private static float _brightnessCorrection = 0.9f;
        private static PostProcessVolume _postProcessVolumeInstance; //to do
        
        private ColorGrading _colorGrading;
        private Resolution[] _resolutions;

        private void Awake()
        {
            SavedSettingsSetup();
        }

        public void SetAmbienceVolume()
        {
            var volume = ambienceVolumeSlider.value;
            ambienceMixer.SetFloat("Ambience", volume);
            PlayerPrefs.SetFloat("Ambience", volume);
        }

        public void SetEffectsVolume()
        {
            var volume = effectsVolumeSlider.value;
            effectsMixer.SetFloat("SoundEffects", volume);
            PlayerPrefs.SetFloat("SoundEffects", volume);
        }

        public void SetFullscreen()
        {
            Screen.fullScreen = fullscreenToggle.isOn;
        }

        public void SetResolution()
        {
            var resolutionIndex = resolutionDropdown.value;
            Resolution activeResolution = _resolutions[resolutionIndex];
            Screen.SetResolution(activeResolution.width, activeResolution.height, Screen.fullScreen);
            resolutionDropdown.captionText.text = $"{activeResolution.width}x{activeResolution.height}";
            PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        }

        public void SetBrightness()
        {
            _brightnessCorrection = brightnessSlider.value;
            _colorGrading.postExposure.value = _brightnessCorrection;
            PlayerPrefs.SetFloat("Brightness", _brightnessCorrection);
        }

        public void SetMouseSensitivity()
        {
            Constants.MouseSensitivity = sensitivitySlider.value;
            PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);
        }

        private void SavedSettingsSetup()
        {
            ResolutionSetup();
            ScreenSetup();
            BrightnessSetup();
            VolumeSetup();
            SensitivitySetup();
        }

        private void VolumeSetup()
        {
            ambienceVolumeSlider.value = PlayerPrefs.GetFloat("Ambience", 0f);
            effectsVolumeSlider.value = PlayerPrefs.GetFloat("SoundEffects", 0f);

            ambienceMixer.SetFloat("Music", PlayerPrefs.GetFloat("Ambience", 0f));
            effectsMixer.SetFloat("SoundEffects", PlayerPrefs.GetFloat("SoundEffects", 0f));
        }

        private void BrightnessSetup()
        {
            _colorGrading = FindObjectOfType<PostProcessVolume>().profile.GetSetting<ColorGrading>();
            brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 0.9f);
            
            SetBrightness();
        }
        
        private void ScreenSetup()
        {
            fullscreenToggle.isOn = Screen.fullScreen;
        }
        
        private void ResolutionSetup()
        {
            _resolutions = Screen.resolutions;
            resolutionDropdown.ClearOptions();
            var resolutionStringList = new List<string>();

            foreach (Resolution resolution in _resolutions)
            {
                var resolutionString = $"{resolution.width}x{resolution.height} {resolution.refreshRateRatio}Hz";
                resolutionStringList.Add(resolutionString);
            }
            
            resolutionDropdown.AddOptions(resolutionStringList);
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex", resolutionStringList.Count - 1);
        }

        private void SensitivitySetup()
        {
            sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 2f);
            Constants.MouseSensitivity = sensitivitySlider.value;
        }
    }
}