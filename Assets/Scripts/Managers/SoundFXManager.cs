
using Unity.VisualScripting;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;
    [SerializeField] private AudioSource soundFXObject;
     

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySoundFX(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource= Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        
        // assign the audioClip
        audioSource.clip = audioClip;

        // assign volume
        audioSource.volume = volume;

        // play sound
        audioSource.Play();

        float clipLength = audioSource.clip.length;

        // Destroy clip after it is done playing

        Destroy(audioSource.gameObject,clipLength);
    }
}
