using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerManager : MonoBehaviour
{
    public PauseManager pauseManager;
    public PlayerStats ps;
    public float hp;
    public float fXP = 0f;
    [SerializeField] private LifeUpdate lifeUpdate = null;
    [SerializeField] private GameObject GO_levelingUpdate = null;
    [SerializeField] private XPUpdate xpUpdate = null;
    [SerializeField] private int iDamageAsteroid = 10;

    void Start()
    {
        hp = ps.hpMax;
        if(lifeUpdate!=null)
        {
            lifeUpdate.ChangeUI();
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
            GO_levelingUpdate.SetActive(true);
            fXP -= ps.fXPmax;
        }
        xpUpdate.ChangeUI();
        //TO DO le droit d'avoir une update mtn
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
        //TODO: player death, ui and all
    }
}
