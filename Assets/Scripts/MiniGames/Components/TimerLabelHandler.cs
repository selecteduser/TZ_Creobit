using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public sealed class TimerLabelHandler : MonoBehaviour
{
    [SerializeField] private string _saveKey;

    private float _elapsedTime;
    private Text _text;

    private event Action OnUpdate;
    
    private void Awake()
    {
        _text = GetComponent<Text>();
        OnUpdate += UpdateTimer;
    }
    private void Update() => OnUpdate?.Invoke();
    private void UpdateTimer()
    {
        _elapsedTime += Time.deltaTime;
        _text.text = Mathf.FloorToInt(_elapsedTime).ToString();
    }
    public void StopAndSave()
    {
        OnUpdate -= UpdateTimer;

        var seconds = Mathf.FloorToInt(_elapsedTime);
        
        var highScoreValue = DataSaveLoadUtility.GetInt(_saveKey);
        if (highScoreValue != 0 && highScoreValue <= seconds) DisplayNonHighScoreText(seconds, highScoreValue);
        else
        {
            DisplayHighScoreText(seconds);
            DataSaveLoadUtility.SaveInt(_saveKey, seconds);
        }
    }
    private void DisplayNonHighScoreText(int secondsPassed, int highScore)
    {
        _text.text = $"You completed the mission in {secondsPassed} seconds!\nYour High Score is {highScore}";
    }
    private void DisplayHighScoreText(int secondsPassed)
    {
        _text.text = $"New High Score: {secondsPassed}";
    }
}
