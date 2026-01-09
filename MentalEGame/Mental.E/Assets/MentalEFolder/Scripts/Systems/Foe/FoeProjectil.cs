using PrimeTween;
using UnityEngine;
using UnityEngine.VFX;

public class FoeProjectil : MonoBehaviour
{
    [SerializeField] private FoeStat foeStats;
    [SerializeField] private GameObject goBullet = null;
    [SerializeField] private GameObject goxImpact = null;
    [SerializeField] private float fSpeed = 10f;
    private bool bHasHit = false;
    public int iDamage = 10;
    private void OnEnable()
    {
        fSpeed = foeStats.bulletSpeed;
        bHasHit = false;
        goBullet.SetActive(true);
        goxImpact.SetActive(false);
    }
    private void Update()
    {
        if(!bHasHit)
        {
            this.transform.position -= new Vector3(0, 0, fSpeed * Time.deltaTime);
            if (transform.position.z < 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            bHasHit = true;
            collider.gameObject.GetComponent<PlayerManager>().TakeDamage(iDamage);
            goBullet.SetActive(false);
            goxImpact.SetActive(true);
            Tween.Delay(1f)
                 .OnComplete(() =>
                 {
                     goxImpact.SetActive(false);
                     this.gameObject.SetActive(false);
                     this.transform.position = Vector3.zero;
                     goBullet.SetActive(true);
                 });
        }
    }
}
