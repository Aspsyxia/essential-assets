using UnityEngine;

namespace EssentialAssets.Utilities
{
    /// <summary>
    /// Class used to manage non-environmental sound effects like UI button clicks or music.
    /// </summary>
    public class SoundManager : MonoBehaviour
    {
        [Header("Audio clips")] [SerializeField]
        private AudioClip menuMusic;

        [SerializeField] private AudioClip standardButtonSound;

        [Header("Sources")] [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource effectsSource;

        #region music

        public void PlayMusic(AudioClip musicClip)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }

        public void StopMusic()
        {
            musicSource.Stop();
        }

        public void PlayMenuMusic()
        {
            musicSource.clip = menuMusic;
            musicSource.Play();
        }

        #endregion

        #region soundEffects

        public void PlaySoundEffect(AudioClip clip)
        {
            effectsSource.PlayOneShot(clip);
        }

        public void PlayButtonClickEffect()
        {
            effectsSource.PlayOneShot(standardButtonSound);
        }

        #endregion

    }
}