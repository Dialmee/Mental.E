using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerProjectile : MonoBehaviour
{
    public Transform target = null;
    [SerializeField] private Rigidbody rb;
    public float fSpeed = 10f;
    public int iDamage = 20; 
    public float rotateSpeed = 200f;
    private void OnEnable()
    {
        this.transform.localPosition = Vector3.zero;
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
                Vector3 rotateAmount = Vector3.Cross(direction, transform.forward);
                rb.angularVelocity = -rotateAmount * rotateSpeed;
                rb.linearVelocity = transform.forward * fSpeed;
            }
            else
            {
                this.gameObject.SetActive(false);
                target = null;
                this.transform.localPosition = Vector3.zero;
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
            this.transform.localPosition = Vector3.zero;
            Debug.Log("BAM");
        }
    }
}
