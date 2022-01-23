using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public WallManager manager;
    public float speed = 3;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -10)
        {
            manager.SpawnWall();
            Destroy(this.gameObject);
        }
        else
        {
            transform.position = new Vector3(0, transform.position.y - speed * Time.deltaTime, 0);
        }

    }
}
