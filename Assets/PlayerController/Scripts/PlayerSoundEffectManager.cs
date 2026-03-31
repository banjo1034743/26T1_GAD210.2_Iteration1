using UnityEngine;

namespace FDAY2025.Player
{
    /// <summary>
    /// This class handle playing sound effects for the player
    /// </summary>
    public class PlayerSoundEffectManager : MonoBehaviour
    {
        public void PlaySoundEffect(AudioClip clip, Vector2 positionToPlaySoundEffect)
        {
            AudioSource.PlayClipAtPoint(clip, positionToPlaySoundEffect);
        }
    }
}