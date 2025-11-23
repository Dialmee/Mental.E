using UnityEngine;

public class FoeManager : MonoBehaviour
{
    [SerializeField] private float hp;

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
