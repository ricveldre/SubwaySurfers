using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    private int points;
    [SerializeField]
    private float pointsInterval = 0.5f;
    [SerializeField]
    private UnityEvent<int> onPointsChanged;
    private Coroutine pointsCoroutine;
    [SerializeField]
    private Text[] pointsTexts;
    public void StartCounting()
    {
        points = 0;
        onPointsChanged?.Invoke(points);
        pointsCoroutine = StartCoroutine(CountPoints());
    }
    public void StopCounting()
    {
        if(pointsCoroutine != null)
        {
            StopCoroutine(pointsCoroutine);
            pointsCoroutine = null;
        }
    }
    private IEnumerator CountPoints()
    {
        while (true)
        {
            yield return new WaitForSeconds(pointsInterval);
            points++;
            onPointsChanged?.Invoke(points);
        }
    }
    public void CalculateHighScore()
    {
        // 1. Obtenemos el récord guardado
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // 2. Si los puntos actuales son mayores al récord, actualizamos el récord
        if (points > highScore)
        {
            highScore = points; // El nuevo récord es el puntaje actual
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        // 3. ACTUALIZACIÓN CRÍTICA:
        // Mostramos el 'highScore' en los textos, NO los 'points'
        foreach (var text in pointsTexts)
        {
            if (text != null)
            {
                text.text = highScore.ToString();
            }
        }
    }
    private void UpdatePointsTexts()
    {
        foreach (var text in pointsTexts)
        {
            text.text = points.ToString();
        }
    }
}
