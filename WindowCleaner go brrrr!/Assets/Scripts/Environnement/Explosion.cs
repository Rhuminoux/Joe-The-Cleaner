using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    private float _lifeTime = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_lifeTime >= 0.5f)
            Destroy(this.gameObject);
        else
            _lifeTime += Time.deltaTime;
    }
}
