using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;


public class GameOver : MonoBehaviour
{
    [SerializeField] private Animator _gameOverPanelAnimation;
    [SerializeField] private Slider _adsTimerSlider;
    [SerializeField] private GameObject _endOverPanel;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private TMP_Text _totalScore;
    [SerializeField] private TMP_Text _GameScore;

    [SerializeField] private Spawner _spawner;

    private float _adsTimerDuration = 5f;
    private string _animatorTriggerName = "in";
    private bool _paused = true;

    public void ShowGameOVerPanel()
    {
        _gameOverPanel.SetActive(true);
        _gameOverPanelAnimation.SetTrigger(_animatorTriggerName);
        _endOverPanel.SetActive(false);
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        
        float elapsedTime = 0f;
        _adsTimerSlider.value = 1f;

        while (elapsedTime < _adsTimerDuration)
        {
            elapsedTime += Time.deltaTime;
            _adsTimerSlider.value = Mathf.Lerp(1f, 0f, elapsedTime / _adsTimerDuration);
            yield return null;
        }
        _adsTimerSlider.value = 0f;
        ACtivateGameOverPanel();


    }


    private void ACtivateGameOverPanel()
    {
        _endOverPanel.SetActive(true);
        _totalScore.text = "Ñ÷¸ò: " + _GameScore.text;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowAD()
    {
        YG2.RewardedAdvShow("0", AdReward);
    }
    public void AdReward()
    {
        _gameOverPanel.SetActive(false);
        _paused = false;
        _spawner.enabled = true;
        StopAllCoroutines();

    } 

    
}
