using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public sealed class ScoreLabelHandler : MonoBehaviour
{
    [SerializeField] private string _saveKey;
    
    private int _score;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
        
        _score = DataSaveLoadUtility.GetInt(_saveKey);
        UpdateLabel();
    }
    public void IncreaseScore(int amount)
    {
        _score += amount;
        UpdateLabel();
        
        DataSaveLoadUtility.SaveInt(_saveKey, _score);
    }
    private void UpdateLabel()
    {
        _text.text = _score.ToString();
    }
}
