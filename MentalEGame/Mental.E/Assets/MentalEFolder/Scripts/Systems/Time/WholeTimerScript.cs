using UnityEngine;
using UnityEngine.SceneManagement;

public class WholeTimerScript : MonoBehaviour
{
    private static WholeTimerScript _instance;
    public static WholeTimerScript Instance
    {
        get
        {
            if (_instance == null)
            {
                // Recherche une instance existante dans la scène
                _instance = FindFirstObjectByType<WholeTimerScript>();

                // Si aucune instance n'existe, en crée une nouvelle
                if (_instance == null)
                {
                    GameObject InspectGUIObject = new GameObject("WholeTimerScript");
                    _instance = InspectGUIObject.AddComponent<WholeTimerScript>();

                }
            }
            return _instance;
        }
    }
    public float fTimer = 0f;
    public float finitialFoeSpeed = 30f;
    public float fFoeSpeed = 30f;
    [SerializeField] private PlayerStats playerStats;
    private void Start()
    {
        fTimer = 0f;
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().name=="MentalEGame")
        {
            fTimer += Time.deltaTime;
            UpdateStats();
        }
    }
    private void UpdateStats()
    {
        playerStats.fBulletSpeedNow = playerStats.bulletSpeed+ (fTimer / 100f);
        fFoeSpeed = finitialFoeSpeed + (fTimer /100f);
    }
}
