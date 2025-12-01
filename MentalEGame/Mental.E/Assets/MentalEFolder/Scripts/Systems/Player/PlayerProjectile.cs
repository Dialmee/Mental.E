using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using static UnityEngine.GraphicsBuffer;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private VisualEffect vfxArrow = null;
    public Transform playerTr = null;
    public Transform target = null;
    [SerializeField] private Rigidbody rb;
    public float fSpeed = 10f;
    public int iDamage = 20; 
    private Vector3 lastDirectionTake = Vector3.zero;
    [SerializeField] private float fTresholdZ = 80f;
    private void OnEnable()
    {
        if (playerTr != null)
        {
            this.transform.position = playerTr.position;
        }
    }
    private void OnDisable()
    {
        target = null;
    }
    private void Update()
    {
        if(this.gameObject.activeInHierarchy && target !=null)
        {
            if(target.gameObject.activeInHierarchy)
            {
                Vector3 direction = (Vector3)target.position - rb.position;
                direction.Normalize();
                if(vfxArrow!=null && vfxArrow.HasVector3("Vect3Direction"))
                {
                    Vector3 newV = rb.position - (Vector3)target.position;
                    vfxArrow.SetVector3("Vect3Direction", newV.normalized);
                }
                this.transform.position += direction * fSpeed *Time.deltaTime;
                lastDirectionTake = direction;
                if (direction.z < -0.2)
                {
                    this.gameObject.SetActive(false);
                    target = null;
                    this.transform.position = Vector3.zero;
                }
            }
            else
            {
                this.transform.position += lastDirectionTake * fSpeed * Time.deltaTime;
                if (this.transform.position.z >= fTresholdZ)
                {
                    this.gameObject.SetActive(false);
                    target = null;
                    this.transform.position = Vector3.zero;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Shootable"))
        {
            //TODO L'ennemi prend des d�gats
            collider.gameObject.GetComponent<FoeManager>().TakeDamage(iDamage);
            this.gameObject.SetActive(false);
            target = null;
            this.transform.position = Vector3.zero;
        }
    }
}
