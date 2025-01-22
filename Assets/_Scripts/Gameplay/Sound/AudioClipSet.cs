using UnityEngine;

namespace _Scripts.Gameplay.Sound
{
    [CreateAssetMenu(fileName = "AudioClipSet", menuName = "Audio/AudioClipSet")]
    public class AudioClipSet : ScriptableObject
    {
        [Tooltip("List of audio clips for the set.")]
        public AudioClip[] audioClips; // Array of audio clips in the set

        private int currentClipIndex = -1; // Index of the current track

        /// <summary>
        /// Returns the next clip in the array, looping back to the first if the end is reached.
        /// </summary>
        public AudioClip GetNextClip()
        {
            // Increment the index and handle looping
            currentClipIndex = (currentClipIndex + 1) % audioClips.Length;
            return audioClips[currentClipIndex];
        }

        /// <summary>
        /// Returns a random clip from the array.
        /// </summary>
        public AudioClip GetRandomClip()
        {
            // Get a random index and return the corresponding clip
            int randomIndex = Random.Range(0, audioClips.Length);
            return audioClips[randomIndex];
        }
    }
}

