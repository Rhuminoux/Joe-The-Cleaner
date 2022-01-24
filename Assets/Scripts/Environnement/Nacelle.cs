using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Manager;

public class Nacelle : MonoBehaviour
{
    public Manager gameManager;

    public Text scoreText;
    public int _score = 0;
    private float _newPoint;

    public SpringJoint2D jointL;
    public Joystick joystickL;
    public AudioSource audioL;

    public SpringJoint2D jointR;
    public Joystick joystickR;
    public AudioSource audioR;

    public SpriteRenderer player;

    public float speed = 1;
    private float _newDist;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<Manager>();
        joystickL = gameManager.joystick.transform.GetChild(0).GetComponent<Joystick>();
        joystickR = gameManager.joystick.transform.GetChild(1).GetComponent<Joystick>();
    }

    private void Update()
    {
        if (gameManager._currentState == State.GAME)
        {
            if (_newPoint >= 1)
            {
                _score += 1;
                scoreText.text = _score.ToString();
                _newPoint = 0;
            }
            else
                _newPoint += Time.deltaTime;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (jointL.distance > 9)
            jointL.distance = 9;
        if (jointR.distance > 9)
            jointR.distance = 9;

        if (joystickL.Vertical != 0)
        {
            _newDist = jointL.distance - joystickL.Vertical * speed * Time.deltaTime;
            if (_newDist - jointR.distance > -2 && _newDist - jointR.distance < 2 & (jointL.distance > 2 && jointL.distance <= 9))
            {
                jointL.distance = _newDist;
                if (!audioL.isPlaying)
                    audioL.Play();
            }
        }
        else if (audioL.isPlaying)
            audioL.Pause();

        if (joystickR.Vertical != 0)
        {
            _newDist = jointR.distance - joystickR.Vertical * speed * Time.deltaTime;
            if (_newDist - jointL.distance > -2 && _newDist - jointL.distance < 2 && (jointR.distance > 2 && jointR.distance <= 9))
            {
                jointR.distance = _newDist;
                if (!audioR.isPlaying)
                    audioR.Play();
            }

        }
        else if (audioR.isPlaying)
            audioR.Pause();

        if (jointR.distance > jointL.distance && player.flipX)
            player.flipX = false;
        else if (jointR.distance < jointL.distance && !player.flipX)
            player.flipX = true;
    }
}
