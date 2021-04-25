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
    }

    public static void PlayAudioAtLocation(AudioClip audioClip, Vector2 position)
    {
        if (!_initialized)
        {
            throw new InvalidOperationException($"{nameof(AudioClipPlayer)} has not been initialized");
        }
        AudioClipPlayer player = Instantiate(_prefab, position, Quaternion.identity).GetComponent<AudioClipPlayer>();
        player._audioClip = audioClip;
    }

    #endregion

    private AudioClip _audioClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.PlayOneShot(_audioClip);
        Invoke(nameof(Kill), _audioClip.length);
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
