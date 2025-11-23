using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerStats ps;
    [SerializeField] private float hp;
    [SerializeField] private int iDamageAsteroid = 10;

    void Start()
    {
        hp = ps.hpMax;
    }

    void Update()
    {
        if (hp < ps.hpMax)
        {
            hp += ps.healthRegeneration * Time.deltaTime;
            if(hp > ps.hpMax)
                hp = ps.hpMax;
        }
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
