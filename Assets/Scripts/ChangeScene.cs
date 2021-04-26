using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    [SerializeField]
    private string _targetScene;
    
    public void GoToScene()
    {
        SceneManager.LoadScene(_targetScene);
    }
}
