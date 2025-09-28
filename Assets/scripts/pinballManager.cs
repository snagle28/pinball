using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class pinballManager : MonoBehaviour
{
    
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text deathText;

    public string range;
    //why does this keep resetting?
    private int score = 0;
    private bool readyToLoad = false;
    public int timer = 0;
    public int deathTimer = 0;
    public int deaths = 0;
    public bool resetVars = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = PlayerPrefs.GetInt("score");
        deaths = PlayerPrefs.GetInt("deaths");
        scoreText.text = "Score: " + score.ToString();
        deathText.text = "Deaths: " + deaths.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        deathText.text = "Deaths: " + deaths.ToString();
        CheckDeath();
        if(readyToLoad && timer < 100)
        {
            timer++;
            if (timer >= 100)
            {
                //preserve score
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }

        if (resetVars)
        {
            deaths = 0;
            score = 0;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("deaths", deaths);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Menu");
        }

        if (deaths > 4)
        {
            Time.timeScale = 0;
        }
    }


    public void AddScore(string range)
    {
        //update score
        //call this funciton from the player
        switch (range)
        {
            case "1":
                score += 100;
                scoreText.text = "Score: " + score.ToString();
                PlayerPrefs.SetInt("score", score);
                PlayerPrefs.Save();
                break;
            case "2":
                score += 200;
                scoreText.text = "Score: " + score.ToString();
                PlayerPrefs.SetInt("score", score);
                PlayerPrefs.Save();
                break;
            case "3":
                score += 300;
                scoreText.text = "Score: " + score.ToString();
                PlayerPrefs.SetInt("score", score);
                PlayerPrefs.Save();
                break;
            case "ultimate":
                score += 500;
                scoreText.text = "Score: " + score.ToString();
                PlayerPrefs.SetInt("score", score);
                PlayerPrefs.Save();
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            readyToLoad = true;
            deaths += 1; 
            PlayerPrefs.SetInt("deaths", deaths);
            PlayerPrefs.Save();
        }
    }

    public void CheckDeath()
    {
        
        //have a rat counter, if there are three rats (deaths) load scene
        if (deaths >= 5)
        {
           
            resetVars = true;
                //add to scene manager
            
        }
    }
    
    
}
