using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string _targetScene;

    public void GoToScene()
    {
        SceneManager.LoadScene(_targetScene);
    }

    private void Update()
    {
        float aButton = Input.GetAxis("AButtonWindows") + Input.GetAxis("AButtonMac");
        if (aButton != 0)
        {
            SceneManager.LoadScene(_targetScene);
        }
    }
}
