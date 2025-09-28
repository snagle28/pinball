using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdatedFade : MonoBehaviour
{
    public Animator  animator;
    private string levelToLoad;
    
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     FadeToLevel("SampleScene");
        // }
    }

    public void FadeToLevel(string levelName)
    {
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
