using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectManager : MonoBehaviour
{
    public List<GameObject> ObjectsPrefabs;

    private float _nextObject;
    private float _time;
    private GameObject _newObj;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_time > _nextObject)
        {
            _newObj = GameObject.Instantiate(ObjectsPrefabs[Random.Range(0, ObjectsPrefabs.Count)], transform);
            
            _newObj.transform.position = new Vector3(Random.Range(-1.8f, 1.8f), 6, -2);
            _newObj.transform.Rotate(new Vector3(0, 0, Random.Range(0, -360)));
            _time = 0;
            _nextObject = Random.Range(2, 5);
        }
        else
            _time += Time.deltaTime;
    }

    public void PauseSound()
    {
        for(int i = 0; i < transform.childCount; ++i)
            foreach (AudioSource audio in transform.GetChild(i).gameObject.GetComponents<AudioSource>())
                audio.Pause();
    }

    public void PlaySound()
    {
        for (int i = 0; i < transform.childCount; ++i)
            foreach (AudioSource audio in transform.GetChild(i).gameObject.GetComponents<AudioSource>())
                audio.Play();
    }
}
