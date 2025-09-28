using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    private Image sceneFade;

    private void Awake()
    {
        sceneFade = GetComponent<Image>();
    }

    private IEnumerator FadeCoroutine(Color startcolor, Color targetColor, float duration)
    {
        float elapsedTime = 0;
        float elapsedPercent = 0;

        while (elapsedPercent < 1)
        {
            elapsedPercent = elapsedTime / duration;
            sceneFade.color = Color.Lerp(startcolor, targetColor, elapsedPercent);
            
            yield return null;
            elapsedTime += Time.deltaTime;
        }

    }



}
