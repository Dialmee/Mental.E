using System.Collections.Generic;
using UnityEngine;

public class FoeShooting : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    private bool bPlayerIsInFront = false;
    [SerializeField] private Transform tr_ProjectilParent;
    [SerializeField] private List<GameObject> GO_Projectil = new List<GameObject>(10);
    private int iCurrentProjectil = 0;
    private float fTimer = 0f;
    [SerializeField] private float fSpeed = 5f;
    [SerializeField] private float fFréquence = 2f;

    private void Update()
    {
        /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 200f, layerMask))
        {
            bPlayerIsInFront = true;
        }
        else
        {
            bPlayerIsInFront = false;
        }

        if(bPlayerIsInFront)
        {

        }*/
        fTimer += Time.deltaTime;
        if (fTimer > fFréquence)
        {
            Shoot();
            fTimer = 0f;
        }
    }
   private void Shoot()
    {
        CheckProjectilEnable();
        GO_Projectil[iCurrentProjectil].SetActive(true);
        iCurrentProjectil += 1;
        Debug.Log("shoot");
    }
    private void CheckProjectilEnable()
    {
        if (iCurrentProjectil >= GO_Projectil.Count && GO_Projectil[0].activeInHierarchy)
        {
            GO_Projectil.Add(Instantiate(GO_Projectil[0], this.transform.position, Quaternion.identity, tr_ProjectilParent));
            Debug.Log("NEW PROJECTIL");
        }
        else if (iCurrentProjectil >= GO_Projectil.Count)
        {
            iCurrentProjectil = 0;
            Debug.Log("nouvelle boucle");
        }
        Debug.Log("Checked");
    }
}
