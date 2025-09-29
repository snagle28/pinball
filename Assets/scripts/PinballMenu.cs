using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PinballMenu : MonoBehaviour
{

    public UpdatedFade transitionAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        print("Starting game");
        // Time.timeScale = 1;
        transitionAnimator.FadeToLevel("SampleScene");
    }

    public void SeeOptions()
    {
        transitionAnimator.FadeToLevel("HowToPlay");
    }

    public void GoBack()
    {
        transitionAnimator.FadeToLevel("Menu");
    }

}
