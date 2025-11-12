using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;

    [SerializeField] float UpdateInterval = 1.0f;

    float accumulatedFrameTime;
    int framesSinceupdate = 0;

    int[] frameRateSamples;
    int sampleIndex = 0;
    [SerializeField] int numberOfFrames;

    // Start is called before the first frame update
    void Start()
    {

        frameRateSamples = new int[numberOfFrames];
        StartCoroutine(UpdateFPSDisplay());
    }

    // Update is called once per frame
    void Update()
    {
        CalculateFPS();
    }

    void CalculateFPS()
    {
        float deltaTime = Time.unscaledDeltaTime;
        accumulatedFrameTime += deltaTime;
        framesSinceupdate++;

        frameRateSamples[sampleIndex] = Mathf.RoundToInt(1.0f / deltaTime);
        sampleIndex = (sampleIndex + 1) % numberOfFrames;


    }

    private IEnumerator UpdateFPSDisplay()
    {
        while (true)
        {
            yield return new WaitForSeconds(UpdateInterval);

            if (framesSinceupdate == 0)
            {
                continue;
            }

            int sum = 0;
            for ( int i = 0; i < numberOfFrames; i++)
            {
                sum += frameRateSamples[i];
            }

            int averageFPS = sum / numberOfFrames;

            string statsText = "FPS: " + averageFPS;

            fpsText.text = statsText;

            accumulatedFrameTime = 0f;
            framesSinceupdate = 0;
        }
    }
}
