using UnityEngine;

public class FoeProjectil : MonoBehaviour
{
    [SerializeField] private float fSpeed = 10f;
    private void OnEnable()
    {
        this.transform.localPosition = Vector3.zero;
    }
    private void Update()
    {
        this.transform.position -= new Vector3(0,0,fSpeed * Time.deltaTime);
        if(transform.position.z < 0)
        {
            this.gameObject.SetActive(false);
            Debug.Log("disparu");
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            //TODO Le joueur prend des dégats
            this.gameObject.SetActive(false);
            this.transform.localPosition = Vector3.zero;
            Debug.Log("BAM");
        }
    }
}
