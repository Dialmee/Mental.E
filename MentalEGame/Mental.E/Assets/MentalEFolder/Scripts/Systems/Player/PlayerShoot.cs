using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform tr_ProjectilParent;
    [SerializeField] private List<GameObject> GO_Projectil = new List<GameObject>(10);
    private int iCurrentProjectil = 0;
    private float fTimer = 0f;
    [SerializeField] private float fSpeed = 5f;
    [SerializeField] private float fFrequence = 2f;
    private int iDamageInitial = 5;
    public int iDamage = 5;

    private void Start()
    {
        iDamageInitial = iDamage;
    }
    private void Update()
    {
        fTimer += Time.deltaTime;
        if (fTimer > fFrequence)
        {
            Shoot();
            fTimer = 0f;
        }
        if (iDamageInitial != iDamage)
        {
            iDamageInitial = iDamage;
            foreach (GameObject projectile in GO_Projectil)
            {
                projectile.GetComponent<FoeProjectil>().iDamage = iDamage;
            }
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
