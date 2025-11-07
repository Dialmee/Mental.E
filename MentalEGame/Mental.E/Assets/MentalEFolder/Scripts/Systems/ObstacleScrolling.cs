using UnityEditor.UI;
using UnityEngine;

public class ObstacleScrolling : MonoBehaviour
{

    public float speed = 5f;

    void Update()
    {


        if (transform.position.z > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
        }else 
        { 
            this.gameObject.SetActive(false);
        }
        
    }
}
