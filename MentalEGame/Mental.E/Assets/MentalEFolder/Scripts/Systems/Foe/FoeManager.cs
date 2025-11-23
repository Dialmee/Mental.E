using UnityEngine;

public class FoeManager : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private float hp;

    private void OnEnable()
    {
        hp = maxHp;
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
        this.gameObject.SetActive(false);
        this.transform.position = Vector3.zero;
    }
}
