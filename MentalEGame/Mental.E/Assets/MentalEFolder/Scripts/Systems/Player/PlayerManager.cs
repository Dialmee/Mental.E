using PrimeTween;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private uiUpgradesConfig uiUpgradesConfig;
    public PauseManager pauseManager;
    public PlayerStats ps;
    public PlayerMouvement playerMouvement;
    public float hp;
    public float fXP = 0f;
    public LifeUpdate lifeUpdate = null;
    [SerializeField] private XPUpdate xpUpdate = null;
    [SerializeField] private NewLevel newLevel = null;
    [SerializeField] private int iDamageAsteroid = 10;

    private void Start()
    {
        hp = ps.hpMax;
        if(lifeUpdate!=null)
        {
            lifeUpdate.ChangeUI();
        }
        if (uiUpgradesConfig.iNextUpgrade!=10)
        {
            ps.Upgrade(uiUpgradesConfig.iNextUpgrade, this);
        }
    }

    void Update()
    {
        if (hp < ps.hpMax)
        {
            hp += ps.healthRegeneration * Time.deltaTime;
            if(hp > ps.hpMax)
                hp = ps.hpMax;
            if (lifeUpdate != null)
            {
                lifeUpdate.ChangeUI();
            }
        }
    }

    public void GainXP(float nb)
    {
        fXP += nb;
        if(fXP >= ps.fXPmax)
        {
            ps.iLevel += 1;
            newLevel.gameObject.SetActive(true);
            newLevel.NewLevelIn();
            fXP -= ps.fXPmax;
        }
        xpUpdate.ChangeUI();
    }

    public void TakeDamage(int nb)
    {
        hp -= nb;
        if (hp <= 0)
        {
            hp = 0;
            Death();
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Asteroid"))
        {
            TakeDamage(iDamageAsteroid);
            collider.gameObject.SetActive(false);
            collider.gameObject.transform.localPosition = Vector3.zero;
        }
    }

    private void Death()
    {
        pauseManager.PauseGame(true);
        pauseManager.deathScript.StartDeath();
    }
}
