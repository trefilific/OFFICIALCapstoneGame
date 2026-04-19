using UnityEngine;

public enum WeatherType
{
    None,
    Rain,
    Snow
}

public class WeatherManager : MonoBehaviour
{
    [Header("Current Weather")]
    public WeatherType currentWeather = WeatherType.None;

    [Header("Particle Systems")]
    public ParticleSystem rainSystem;
    public ParticleSystem snowSystem;

    private void Start()
    {
        ApplyWeather(currentWeather);
    }

    public void SetWeather(WeatherType newWeather)
    {
        if (newWeather == currentWeather) return;

        currentWeather = newWeather;
        ApplyWeather(currentWeather);
    }

    private void ApplyWeather(WeatherType weather)
    {
        DisableAllWeather();

        switch (weather)
        {
            case WeatherType.None:
                // Nothing active
                break;

            case WeatherType.Rain:
                if (rainSystem != null)
                    rainSystem.Play();
                break;

            case WeatherType.Snow:
                if (snowSystem != null)
                    snowSystem.Play();
                break;
        }
    }

    private void DisableAllWeather()
    {
        if (rainSystem != null)
            rainSystem.Stop();

        if (snowSystem != null)
            snowSystem.Stop();
    }
}
