using PrimeTween;
using UnityEngine;

public class FoeManager : MonoBehaviour
{
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private ObstacleScrolling obstacleScrolling;
    [SerializeField] private GameObject goMesh;
    [SerializeField] private GameObject goVfxBOOM;
    [SerializeField] private ParticleSystem psvfxBOOM;
    [SerializeField] private float maxHp;
    [SerializeField] private float hp;
    public PlayerManager playerManager;
    [SerializeField] private float fXPifDie = 20f;
    public bool bIsDead = false;

    private void OnEnable()
    {
        boxCollider.enabled = true;
        bIsDead = false;
        hp = maxHp;
    }
    public void TakeDamage(int nb)
    {
        hp -= nb;
        if (hp <= 0)
        {
            hp = 0;
            vfxDeath();
        }
    }

    private void vfxDeath()
    {
        boxCollider.enabled = false;
        obstacleScrolling.enabled = false;
        goMesh.SetActive(false);
        goVfxBOOM.SetActive(true);
        psvfxBOOM.Play();
        Tween.Delay(2f)
            .OnComplete(() => {
                bIsDead = true;
                playerManager.GainXP(fXPifDie);
                goVfxBOOM.SetActive(false);
            });
    }
    public void Death()
    {
        goMesh.SetActive(true);
        this.gameObject.SetActive(false);
        this.transform.position = Vector3.zero;
        obstacleScrolling.enabled = true;
    }
}
