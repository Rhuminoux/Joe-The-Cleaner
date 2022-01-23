using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Manager gameManager;
    public GameObject deathMenu;
    public Nacelle nacelle;
    private void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<Manager>();
        deathMenu = gameManager.deathMenu;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.StartsWith("Dirt"))
        {
            nacelle._score += 10;
            nacelle.scoreText.text = nacelle._score.ToString();
            Destroy(collision.gameObject);
        }
        else if (collision.tag.StartsWith("Rock"))
        {
            deathMenu.SetActive(true);
            gameManager.SetStateGameMenu();
        }
    }
}
