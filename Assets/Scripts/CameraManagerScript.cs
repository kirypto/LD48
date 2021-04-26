using UnityEngine;

public class CameraManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject bossCamera;

    private void Awake()
    {
        bossCamera.SetActive(false);
    }
}
 
