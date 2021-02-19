using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatGame : MonoBehaviour
{
    public GameObject cat;
    public GameObject scoreBar;
    public GameObject timerBar;
    public GameObject playBtn;
    public GameObject gameOverText;
    public Animator catAnim;
    public Text gameText;

    private int score = 0;
    private float playTime = 5.0f;
    private bool isGameRunning = true;
    private float startTime = 0.0f;
    private int happyCatScore = 10;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; //Runs the start function at the very start of the game and saves the time
        playBtn.gameObject.SetActive(false); //Makes the play button invisible until the player has played the game
        catAnim = cat.GetComponent<Animator>();
        gameText = gameOverText.GetComponent<Text>();
        gameText = gameOverText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning && Time.time > startTime + playTime) //if current time is greater than start time and play time, stop the game
        {
            isGameRunning = false;
            if (cat.GetComponent<ScoreKeeper>().score > happyCatScore)
            {
                gameText.text = "you win";
                catAnim.SetTrigger("happy_trigger");
            }
            else
            {
                gameText.text = "you lose";
            }
            playBtn.gameObject.SetActive(true);
            gameOverText.SetActive(false);
            isGameRunning = false;
            gameObject.SetActive(false);
        }
        scoreBar.GetComponent<Text>().text = "Score: " + cat.GetComponent<ScoreKeeper>().score.ToString();
        float timeLeft = startTime - Time.time + playTime;
        Debug.Log(timeLeft);
        timerBar.GetComponent<RectTransform>().sizeDelta = new Vector2(timeLeft * 160.0f, 10);
    }
    public void ReplayGame()
    {
        catAnim.SetTrigger("reverse_trigger");
        startTime = Time.time;
        isGameRunning = true;
        gameObject.SetActive(true);
        cat.GetComponent<ScoreKeeper>().score = 0;
        gameText.text = "";
        playBtn.gameObject.SetActive(false);
    }
}
