using System.Collections;
using UnityEngine;

namespace _Scripts.Gameplay.Sound
{
    public class SoundManager : MonoBehaviour
    {
        [Header("Audio Sources")]
        public AudioSource musicSource; // AudioSource for background music
        public AudioSource sfxSource;   // AudioSource for sound effects

        [Header("Audio Clips")]
        public AudioClipSet gameMusicSet;     // Background music for the game

        private bool _isGamePaused = false;
        private bool _isPlayingMusic = false;
        private AudioClip _currentMusicClip;
        private Coroutine _musicCoroutine; // Store reference to the coroutine

        public bool IsGamePaused
        {
            get => _isGamePaused;
            set
            {
                if (value == _isGamePaused)
                    return;
                
                if (value == true)
                {
                    sfxSource.Pause();
                    musicSource.Pause();

                    // Pause the coroutine if game is paused
                    if (_musicCoroutine != null)
                    {
                        StopCoroutine(_musicCoroutine);
                    }
                    
                    
                }
                else
                {
                    sfxSource.UnPause();
                    musicSource.UnPause();

                    // Resume the coroutine if game is unpaused
                    if (musicSource.isPlaying && _musicCoroutine == null)
                    {
                        _musicCoroutine = StartCoroutine(WaitForMusicToEnd());
                    }
                }

                _isGamePaused = value;
            }
        }

        public void PlaySFX(AudioClip clip)
        {
            if (_isGamePaused) return;
            if (clip == null) return;
            if (sfxSource.isPlaying)
            {
                sfxSource.Stop();
            }
            sfxSource.PlayOneShot(clip);
        }

        public void PlayGameMusic()
        {
            PlayMusic(gameMusicSet.GetNextClip());
        }

        private void PlayMusic(AudioClip clip)
        {
            if (_isGamePaused) return;
            if (musicSource.clip == clip) return; // Skip if the same music is already playing
            musicSource.Stop();
            musicSource.clip = clip;
            musicSource.loop = false; // Ensure it is not looping, since we want to move to the next track
            musicSource.Play();
            _currentMusicClip = clip; // Store the current clip to track it

            // Start the coroutine to track the music and switch when it's finished
            if (!_isGamePaused)
            {
                _musicCoroutine = StartCoroutine(WaitForMusicToEnd());
            }
        }

        private IEnumerator WaitForMusicToEnd()
        {
            // Wait until the music source finishes playing
            yield return new WaitForSeconds(musicSource.clip.length);

            // If the game is not paused and the current track has finished, play the next one
            if (!IsGamePaused)
            {
                PlayNextTrack();
            }
        }

        private void PlayNextTrack()
        {
            // Play the next music clip in the set
            AudioClip nextClip = gameMusicSet.GetNextClip(); // Assuming GetNextClip() provides the next clip
            PlayMusic(nextClip);
        }

        public void SetMusicVolume(float volume)
        {
            musicSource.volume = Mathf.Clamp01(volume);
        }

        public void SetSFXVolume(float volume)
        {
            sfxSource.volume = Mathf.Clamp01(volume);
        }
    }
}
