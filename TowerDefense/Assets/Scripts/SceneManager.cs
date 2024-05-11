using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{

    public string sceneName;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

}