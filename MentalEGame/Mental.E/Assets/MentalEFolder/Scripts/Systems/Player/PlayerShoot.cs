using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private SpawnAxe[] spawnAxes = new SpawnAxe[9];
    [SerializeField]private PlayerMouvement playerMouvement;
    [SerializeField] private PlayerStats ps;
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform tr_ProjectilParent;
    [SerializeField] private List<GameObject> GO_Projectil = new List<GameObject>(10);
    private int iCurrentProjectil = 0;
    private float[] fTimer = new float[5] {0f,0f,0f,0f,0f };
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
        if (iDamageInitial != iDamage)
        {
            iDamageInitial = iDamage;
            foreach (GameObject projectile in GO_Projectil)
            {
                projectile.GetComponent<FoeProjectil>().iDamage = iDamage;
            }
        }
        CheckFoeInDirection();
    }
    private void Shoot(Transform target)
    {
        if(target!=null)
        {
            CheckProjectilEnable();
            GO_Projectil[iCurrentProjectil].SetActive(true); 
            GO_Projectil[iCurrentProjectil].GetComponent<PlayerProjectile>().target = target;
            GO_Projectil[iCurrentProjectil].GetComponent<PlayerProjectile>().playerTr = this.transform;
            iCurrentProjectil += 1;
        }
    }
    private void CheckProjectilEnable()
    {
        if (iCurrentProjectil >= GO_Projectil.Count && GO_Projectil[0].activeInHierarchy)
        {
            GO_Projectil.Add(Instantiate(GO_Projectil[0], this.transform.position, Quaternion.identity, tr_ProjectilParent));
        }
        else if (iCurrentProjectil >= GO_Projectil.Count)
        {
            iCurrentProjectil = 0;
        }
    }
    private void CheckFoeInDirection()
    {
        if (ps.nbBullets[0] != 0) //forward
        {
            fTimer[0] += Time.deltaTime;
            if (fTimer[0] > fFrequence)
            {
                Shoot(spawnAxes[playerMouvement.iAxe].WhatFoe());
                fTimer[0] = 0f;
            }
        }
        if (ps.nbBullets[1] != 0 && playerMouvement.iAxe != 2 && playerMouvement.iAxe != 5 && playerMouvement.iAxe != 8) //right
        {
            fTimer[1] += Time.deltaTime;
            if (fTimer[1] > fFrequence)
            {
                Shoot(spawnAxes[playerMouvement.iAxe+1].WhatFoe());
                fTimer[1] = 0f;
            }
        }
        if (ps.nbBullets[2] != 0 && playerMouvement.iAxe != 0 && playerMouvement.iAxe != 3 && playerMouvement.iAxe != 6) //left
        {
            fTimer[2] += Time.deltaTime;
            if (fTimer[2] > fFrequence)
            {
                Shoot(spawnAxes[playerMouvement.iAxe-1].WhatFoe());
                fTimer[2] = 0f;
            }
        }
        if (ps.nbBullets[3] != 0 && playerMouvement.iAxe >2) //up
        {
            fTimer[3] += Time.deltaTime;
            if (fTimer[3] > fFrequence)
            {
                Shoot(spawnAxes[playerMouvement.iAxe-3].WhatFoe());
                fTimer[3] = 0f;
            }
        }
        if (ps.nbBullets[4] != 0 && playerMouvement.iAxe < 6) //down
        {
            fTimer[4] += Time.deltaTime;
            if (fTimer[4] > fFrequence)
            {
                Shoot(spawnAxes[playerMouvement.iAxe+3].WhatFoe());
                fTimer[4] = 0f;
            }
        }
    }
}
