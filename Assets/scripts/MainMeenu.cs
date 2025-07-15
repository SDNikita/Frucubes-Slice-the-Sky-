using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMeenu : MonoBehaviour

{
    [SerializeField] private float _loadDelay = 0.5f;
    [SerializeField] private TMP_Text _TotalSCore;
    [SerializeField] private int _score;
    public void LoadGame()
    {
        StartCoroutine(DelayLoad());
        SCore(_score);
    }

    private IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(_loadDelay);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (asyncLoad.isDone)
        {
            yield return null;
        }
    }
    private int SCore(int score)
    {

        int scoreMax = 0;
        if (score > scoreMax)
        {
            scoreMax = score;
        }

        return scoreMax;
    }
}
