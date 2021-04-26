using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioClipPlayer : MonoBehaviour
{
    #region Static API

    private static GameObject _prefab;
    private static bool _initialized;

    // ReSharper disable once ParameterHidesMember
    public static void Initialize(GameObject prefab)
    {
        if (_initialized)
        {
            throw new InvalidOperationException($"{nameof(AudioClipPlayer)} already initialized");
        }
        _prefab = prefab;
        _initialized = true;
    }

    public static void PlayAudioAtLocation(AudioClip audioClip, Vector2 position, float volume = 1f)
    {
        if (!_initialized)
        {
            throw new InvalidOperationException($"{nameof(AudioClipPlayer)} has not been initialized");
        }

        try
        {
            float _ = audioClip.length;
        }
        catch (UnassignedReferenceException)
        {
            // Provided audio clip is 'null' (Unity AudioClips do not compare to null normally)
            return;
        }

        AudioClipPlayer player = Instantiate(_prefab, position, Quaternion.identity).GetComponent<AudioClipPlayer>();
        player._audioClip = audioClip;
        player._volume = volume;
    }

    #endregion

    private AudioClip _audioClip;
    private AudioSource _audioSource; 
    private float _volume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();       
    }

    private void Start() {
        _audioSource.volume = _volume;
        _audioSource.PlayOneShot(_audioClip);      
        Invoke(nameof(Kill), _audioClip.length);
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
