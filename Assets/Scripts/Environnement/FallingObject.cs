using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float speed = 3;
    public GameObject explosionPrefab;
    private GameObject _newObj;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y <= -9)
            Destroy(this.gameObject);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, -2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.StartsWith("Player"))
        {
            _newObj = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity, transform.parent);
            _newObj.transform.Rotate(new Vector3(0, 0, Random.Range(0, -360)));
            Destroy(this.gameObject);
        }
    }
}
