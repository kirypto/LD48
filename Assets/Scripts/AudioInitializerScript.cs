using UnityEngine;

public class AudioInitializerScript : MonoBehaviour
{
    [SerializeField] private GameObject audioPlayerPrefab;

    private void Awake()
    {
        AudioClipPlayer.Initialize(audioPlayerPrefab);
    }
}
