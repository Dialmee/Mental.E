using System.Collections.Generic;
using UnityEngine;

public class SpawnAxe : MonoBehaviour
{
    public List<GameObject> GO_foes = new List<GameObject>(1);
    public List<GameObject> GO_asteroid = new List<GameObject>(1);
    private Transform tr_entity;
    public int iCurrentFoe = 0;
    public int iCurrentAsteroid = 0;
    private void Start()
    {
        tr_entity = this.GetComponent<Transform>();
    }
    public void Spawn(int hasard)
    {
        if(hasard == 0)
        {
            CheckEntityEnable(iCurrentFoe, GO_foes);
            iCurrentFoe += 1;
        }
        else
        {
            CheckEntityEnable(iCurrentAsteroid, GO_asteroid);
            iCurrentAsteroid += 1;
        }
    }
    private void CheckEntityEnable(int iCurrentEntity, List<GameObject> GO_entity)
    {
        if (iCurrentEntity >= GO_entity.Count && GO_entity[0].activeInHierarchy)
        {
            GO_entity.Add(Instantiate(GO_entity[0], this.transform.position, Quaternion.identity, tr_entity));
        }
        else if (iCurrentEntity >= GO_entity.Count)
        {
            iCurrentEntity = 0;
            GO_entity[0].SetActive(true);
        }
        else
        {
            GO_entity[iCurrentEntity].SetActive(true);
        }
    }
}
