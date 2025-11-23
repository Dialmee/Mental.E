using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerProjectile : MonoBehaviour
{
    public Transform playerTr = null;
    public Transform target = null;
    [SerializeField] private Rigidbody rb;
    public float fSpeed = 10f;
    public int iDamage = 20; 
    private void OnEnable()
    {
        if (playerTr != null)
        {
            this.transform.position = playerTr.position;
            Debug.Log(this.transform.position + " and the player transform is " + playerTr.position);
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
                this.transform.position += direction * fSpeed *Time.deltaTime;
                if(direction.z < -0.2)
                {
                    this.gameObject.SetActive(false);
                    target = null;
                    this.transform.position = Vector3.zero;
                    Debug.Log("projectil passe");
                }
            }
            else
            {
                this.gameObject.SetActive(false);
                target = null;
                this.transform.position = Vector3.zero;
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
            Debug.Log("BAM");
        }
    }
}
