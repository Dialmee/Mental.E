using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public SoundManager soundManager;
    [SerializeField] private string sGameSceneName = null;
    [SerializeField] private GameObject GO_Pause = null;
    [SerializeField] private GameObject GO_ResumePauseScreen = null;
    [SerializeField] private GameObject GO_SettingsScreen = null;
    [SerializeField] private GameObject GO_Cursor = null;
    private bool bGameIsPaused = false;
    private bool isLoadingScene = false;
    private AsyncOperation loadingOperation;
    private void Start()
    {
        Cursor.visible = false;
        if (SceneManager.GetActiveScene().name == sGameSceneName)
        {
            PauseGame(false);
        }
    }
    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame && GO_Pause!=null)
        {
            PauseMenu(!bGameIsPaused);
        }
    }
    public void PauseGame(bool toPause)
    {
        if (GO_Cursor)
        {
            GO_Cursor.SetActive(toPause);
        }
        if (toPause)
        {
            Time.timeScale = 0f;
            //Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            //Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        soundManager.PausedVolume(toPause);
    }
    public void SettingsOpen(bool toOpen)
    {
        GO_SettingsScreen.SetActive(toOpen);
        GO_ResumePauseScreen.SetActive(!toOpen);
        soundManager.PausedVolume(!toOpen);
    }
    private void SettingsOpenFromScript(bool toOpen)
    {
        GO_SettingsScreen.SetActive(toOpen);
        GO_ResumePauseScreen.SetActive(!toOpen);
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
        SettingsOpenFromScript(!toPause);
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
