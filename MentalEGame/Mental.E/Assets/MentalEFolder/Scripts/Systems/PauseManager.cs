using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject GO_Pause = null;
    private bool bGameIsPaused = false;
    private bool isLoadingScene = false;
    private AsyncOperation loadingOperation;
    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame && GO_Pause!=null)
        {
            PauseMenu(!bGameIsPaused);
        }
    }
    public void PauseGame(bool toPause)
    {
        if (toPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void LoaderScene(string sceneToLoad)
    {
        Debug.LogWarning("Scene loading attempt");
        if (isLoadingScene) return;
        if (!Application.CanStreamedLevelBeLoaded(sceneToLoad)) return;
        isLoadingScene = true;
        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);
    }
    public void PauseMenu(bool toPause)
    {
        PauseGame(toPause);
        GO_Pause.SetActive(toPause);
        bGameIsPaused = toPause;
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif
        Application.Quit();
    }
}
