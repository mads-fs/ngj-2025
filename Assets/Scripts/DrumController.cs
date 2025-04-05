using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class DrumController : MonoBehaviour
{
    [SerializeField] private DrumPad yellow;
    [SerializeField] private DrumPad orange;
    [SerializeField] private DrumPad red;
    [SerializeField] private DrumPad blue;
    [SerializeField] private DrumPad green;

    private readonly Dictionary<KeyCode, DrumPad> _mapping = new();
    
    public void Start()
    {
        _mapping.Add(KeyCode.UpArrow, yellow);
        _mapping.Add(KeyCode.DownArrow, orange);
        _mapping.Add(KeyCode.LeftArrow, red);
        _mapping.Add(KeyCode.RightArrow, blue);
        _mapping.Add(KeyCode.Space, green);
        MakeyManager.OnKeyDown += MakeyManager_OnOnKeyDown;
    }

    private void MakeyManager_OnOnKeyDown(KeyCode key)
    {
        if(key == KeyCode.Mouse0) return;
        _mapping[key].Play();
    }
}