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
        activationAssets(true);
        hp = maxHp;
    }
    public void TakeDamage(int nb)
    {
        playerManager.pauseManager.soundManager.PlayOneShot(playerManager.pauseManager.soundManager.soundManagerConfig.sfxLazerHitPath, this.transform.position);
        hp -= nb;
        if (hp <= 0 && !bIsDead)
        {
            hp = 0;
            vfxDeath();
        }
    }

    private void vfxDeath()
    {
        playerManager.pauseManager.soundManager.PlayOneShot(playerManager.pauseManager.soundManager.soundManagerConfig.sfxExplosionPath, this.transform.position);
        activationAssets(false);
        goVfxBOOM.SetActive(true);
        psvfxBOOM.Play();
        playerManager.GainXP(fXPifDie);
        Tween.Delay(2f).OnComplete(() =>
        {
            goVfxBOOM.SetActive(false);
            gameObject.SetActive(false);
        });
    }

    private void activationAssets(bool state)
    {
        boxCollider.enabled = state;
        obstacleScrolling.enabled = state;
        goMesh.SetActive(state);
        bIsDead = !state;
    }
}
