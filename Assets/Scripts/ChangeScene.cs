using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string _targetScene;

    private bool aButtonDisabled = true;
    public void GoToScene()
    {
        SceneManager.LoadScene(_targetScene);
    }

    private void Update()
    {
        bool aButtonPressed = (Input.GetAxis("AButtonWindows") + Input.GetAxis("AButtonMac")) > 0f;
        if (aButtonDisabled)
        {
            if (!aButtonPressed)
            {
                aButtonDisabled = false;
            }
        }
        else if (aButtonPressed)
        {
            SceneManager.LoadScene(_targetScene);
        }
    }
}
