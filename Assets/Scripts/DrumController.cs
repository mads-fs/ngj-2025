using System;
using UnityEngine;
using UnityEngine.UI;

public class DrumController : MonoBehaviour
{
    [SerializeField] private Image yellow;
    [SerializeField] private Image orange;
    [SerializeField] private Image red;
    [SerializeField] private Image blue;
    [SerializeField] private Image green;
    
    public void Start()
    {
        MakeyManager.OnKeyDown += MakeyManager_OnOnKeyDown;
    }

    private void MakeyManager_OnOnKeyDown(KeyCode key)
    {
        
    }
}