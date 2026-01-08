using PrimeTween;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public uiUpgradesConfig uiUpgradesConfig;

    public DeathScript deathScript;
    public PlayerStats playerStats;
    public SoundManager soundManager;
    [SerializeField] private string sGameSceneName = null;
    [SerializeField] private GameObject GO_Pause = null;
    [SerializeField] private GameObject GO_ResumePauseScreen = null;
    [SerializeField] private GameObject GO_SettingsScreen = null;
    [SerializeField] private GameObject GO_UpgradeScreen = null;
    [SerializeField] private GameObject GO_Credits = null;
    [SerializeField] private GameObject GO_Cursor = null;
    [SerializeField] private FMODUnity.EventReference eventReference;

    public bool bIsTuto = false;
    private bool bGameIsPaused = false;
    private bool isLoadingScene = false;
    private AsyncOperation loadingOperation;
    private void Start()
    {
        Cursor.visible = false;
        if (SceneManager.GetActiveScene().name == sGameSceneName)
        {
            // TO DO : a enlever pour build
            playerStats.Start();
            //
            deathScript.bGameIsEnded = false;
            if (playerStats.bTutoDone)
            {
                PauseGame(false);
            }
        }
        soundManager.PlayMusic(eventReference);
    }
    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame && GO_Pause!=null && !deathScript.bGameIsEnded && !bIsTuto)
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
        playerStats.Start();
        if(sceneToLoad== "MainMenu" || sceneToLoad == "Scenes/Game/MainMenu")
        {
            uiUpgradesConfig.iNextUpgrade = 10;
        }
        Debug.LogWarning("Scene loading attempt");
        if (isLoadingScene) return;
        if (!Application.CanStreamedLevelBeLoaded(sceneToLoad)) return;
        isLoadingScene = true;
        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);
    }
    public void PauseMenu(bool toPause)
    {
        if (bGameIsPaused && GO_UpgradeScreen != null && GO_UpgradeScreen.activeInHierarchy)
        {
            PauseGame(!toPause);
            GO_Pause.SetActive(toPause);
            SettingsOpenFromScript(!toPause);
            bGameIsPaused = !toPause;
        }
        else
        {
            PauseGame(toPause);
            GO_Pause.SetActive(toPause);
            SettingsOpenFromScript(!toPause);
            bGameIsPaused = toPause;
        }
    }
    public void CreditsOpen(bool bToOpen)
    {
        GO_Credits.SetActive(bToOpen);
        GO_ResumePauseScreen.SetActive(!bToOpen);
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
