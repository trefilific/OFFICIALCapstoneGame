using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherScript : MonoBehaviour
{
//pick the effect we want
    public GameObject[] WeatherParticles;
    private int particleRandom;

//length of the effect
    private float chanceOfRain = 2f;
    private float RainLength;

    private float dice;
    //helps with deciding if there is an effect active or not
    private bool isSnowing = false;
    private float timer = 0f;


    // Update is called once per frame
    void Update()
    {
        if(!isSnowing)
        {
            dice = Random.Range(0f, 100.0f);
            if(dice < chanceOfRain)
            {
                //rain
                particleRandom = Random.Range(0, WeatherParticles.Length);
                Snow(particleRandom);
                isSnowing = true;
                timer = Random.Range(5f,20f);
            }
        }

        if(isSnowing)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                isSnowing = false;
                StopSnow(particleRandom);
            }
        }
    }

    private void Snow(int particleRandom)
    {
        WeatherParticles[particleRandom].SetActive(true);
    }

    private void StopSnow (int particleRandom)
    {
        WeatherParticles[particleRandom].SetActive(false);
    }
}
