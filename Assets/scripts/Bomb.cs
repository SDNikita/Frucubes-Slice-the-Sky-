using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Camera _mainCamera;
    private GameOver _gameOver;
    
    private void Awake()
    {

        _mainCamera = Camera.main;
        _gameOver = _mainCamera.gameObject.GetComponent<GameOver>();
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Spawner spawner = FindFirstObjectByType<Spawner>();
            
            Explode();
        }
    }
    private void Explode()
    {
        Spawner spawner = FindFirstObjectByType<Spawner>();
        spawner.enabled = false;
        _gameOver.ShowGameOVerPanel();
    }
    
}
