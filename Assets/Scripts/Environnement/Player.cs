using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite iddleJoe;
    public Sprite cleaningJoe;

    public Manager gameManager;
    public Nacelle nacelle;

    private void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<Manager>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.StartsWith("Dirt"))
        {
            nacelle._score += 10;
            nacelle.scoreText.text = nacelle._score.ToString();
            Destroy(collision.gameObject);
            gameObject.GetComponent<SpriteRenderer>().sprite = cleaningJoe;
            StartCoroutine(SetSprite());
        }
        else if (collision.tag.StartsWith("Rock"))
        {
            gameManager.SetStateDeathMenu();
        }
    }

    IEnumerator SetSprite()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<SpriteRenderer>().sprite = iddleJoe;
    }
}
