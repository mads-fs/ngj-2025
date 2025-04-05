using System;
using System.Collections.Generic;
using UnityEngine;

public class MakeyManager : MonoBehaviour
{
    public static MakeyManager Instance => _instance;
    private static MakeyManager _instance;
    
    public static event Action<KeyCode> OnKeyDown;
    
    public enum Key
    {
        UpArrow, 
        DownArrow, 
        LeftArrow, 
        RightArrow, 
        Space, 
        Click
    }

    private Dictionary<Key, KeyCode> _mapping;
    
    private void Awake()
    {
        _instance = this;
        _mapping = new Dictionary<Key, KeyCode>
        {
            [Key.UpArrow] = KeyCode.UpArrow,
            [Key.DownArrow] = KeyCode.DownArrow,
            [Key.LeftArrow] = KeyCode.LeftArrow,
            [Key.RightArrow] = KeyCode.RightArrow,
            [Key.Space] = KeyCode.Space,
            [Key.Click] = KeyCode.Mouse0
        };
    }
    
    private void Update()
    {
        foreach (KeyValuePair<Key, KeyCode> kvp in _mapping)
        {
            if (GetKeyDown(kvp.Key))
                OnKeyDown?.Invoke(kvp.Value);
        }
    }

    private bool GetKeyDown(Key key)
    {
        return Input.GetKeyDown(_mapping[key]);
    }
}