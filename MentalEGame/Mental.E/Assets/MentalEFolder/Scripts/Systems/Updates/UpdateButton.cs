using UnityEngine;

public class UpdateButton : MonoBehaviour
{
    [SerializeField] private GameObject GO_levelingUpdate = null;
    public int iNumber = 0;
    public void Upgrading(PlayerManager playerManager)
    {
        playerManager.ps.Upgrade(iNumber, playerManager);
        Debug.Log(iNumber);
        GO_levelingUpdate.SetActive(false);
    }
}
