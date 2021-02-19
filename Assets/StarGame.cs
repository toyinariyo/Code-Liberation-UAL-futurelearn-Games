using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarGame : MonoBehaviour
{
    //int score = 0;
    //float red = .5f;
    //string gameInstructions = "The game is running and the score is ";
    // Start is called before the first frame update
    public GameObject gameInstructions;
    public float secondsTimer = 10.0f;
    public Text secondsText; //Used for Timer GameObject
    public bool timerRunning = false; //Checks if the timer is running
    void Start()
    {
        timerRunning = true; //Makes sure timer is running when game is started
        for (int counter = 0; counter < transform.childCount; counter++)
        {
            // Debug.Log(transform.childCount + " is the child count");
            float r = Random.Range(0.5f, 1.0f); //Stars change to different colour every time the game is run
            float g = Random.Range(0.5f, 1.0f);
            float b = Random.Range(0.5f, 1.0f);
            gameObject.transform.GetChild(counter).GetComponent<SpriteRenderer>().color = new Color(r, g, b);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            secondsTimer -= Time.deltaTime; //Counting down decrementally from 5 e.g. 5, 4, 3, 2, 1
            secondsText.text = (secondsTimer).ToString("0");
        }
       if (transform.childCount == 0 && secondsTimer > 0)
        {
            secondsTimer = 0;
            timerRunning = false;
            gameInstructions.GetComponent<Text>().text = "Your wishes are working on coming true"; //Controls the text property of the Text GameObject
            gameInstructions.GetComponent<Text>().color = new Color(1.0f, 0.85f, 0.0f); //Controls the RGB colour of the Text GameObject
            gameInstructions.GetComponent<RectTransform>().localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (transform.childCount > 0 && secondsTimer <= 0)
        {
            secondsTimer = 0;
            timerRunning = false;
            gameInstructions.GetComponent<Text>().text = "Time has run out."; //Controls the text property of the Text GameObject
            gameInstructions.GetComponent<Text>().color = new Color(1.0f, 0.85f, 0.0f); //Controls the RGB colour of the Text GameObject
            gameInstructions.GetComponent<RectTransform>().localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }
        //if (score < 10)
        //{
        //    Debug.Log(score);
        //}
        //else
        //{
        //    gameInstructions = "The game is over";
        //    Debug.Log(gameInstructions);
        //}
        //score = score + 1;
        //score++;
    }
}
