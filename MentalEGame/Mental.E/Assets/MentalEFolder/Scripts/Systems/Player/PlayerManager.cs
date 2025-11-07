using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerStats ps;
    [SerializeField] private float hp;

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

    private void Death()
    {
        //TODO: player death, ui and all
    }
}
