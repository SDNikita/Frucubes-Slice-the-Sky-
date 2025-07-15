using UnityEngine;
using TMPro;

public class GameScor : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;

    private int _score;

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        _score = 0; 
        _scoreText.text = _score.ToString();
    }
    public void AddScore(int amount)
    {
        _score += amount;
        _scoreText.text = _score.ToString();
    } 
}
