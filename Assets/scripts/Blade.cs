using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Blade : MonoBehaviour
{
    public Vector3 Direction { get; private set; }
    public float SliseForce = 5f;
    private Camera _mainCamera;
    private Collider _bladeCollider;
    private TrailRenderer _bladeTrail;
    private bool _slicing;
    [SerializeField] private float _minSliceVelosity=0.02f; 

    private void Awake()
    {
        _mainCamera = Camera.main;
        _bladeTrail = GetComponentInChildren<TrailRenderer>();  
        _bladeCollider = GetComponent<Collider>();
        
    }
    private void OnEnable()
    {
        StopSlicing();
    }

    private void OnDisable()
    {
        StopSlicing();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if (_slicing)
        {
            ContinueSlicing();
        }
    }


    
    private void StartSlicing()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; 
        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);
        transform.position = worldPosition;   

        _slicing = true;
        _bladeCollider.enabled = true;
        _bladeTrail.enabled = true;
        _bladeTrail.Clear();
    }
    private void StopSlicing()
    {
        _slicing = false; 
        _bladeCollider.enabled = false;
        _bladeTrail.enabled = false;    


    }
    private void ContinueSlicing()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        Vector3 newPosition = _mainCamera.ScreenToWorldPoint(mousePosition);
        

        Direction = newPosition - transform.position;
        float velosity= Direction.magnitude/Time.deltaTime;
        _bladeCollider.enabled = velosity > _minSliceVelosity;

        transform.position = newPosition;  
    }

}
