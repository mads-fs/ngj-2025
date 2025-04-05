using System;
using System.Collections;
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
        _mapping = new Dictionary<Key, KeyCode>();
        
        //======= MakeyMakey mapping ========
        _mapping[Key.UpArrow] = KeyCode.UpArrow;
        _mapping[Key.DownArrow] = KeyCode.DownArrow;
        _mapping[Key.LeftArrow] = KeyCode.LeftArrow;
        _mapping[Key.RightArrow] = KeyCode.RightArrow;
        _mapping[Key.Space] = KeyCode.Space;
        _mapping[Key.Click] = KeyCode.Mouse0;
    }
    
    private void Update()
    {
        foreach (KeyValuePair<Key, KeyCode> kvp in _mapping)
        {
            if (GetKeyDown(kvp.Key)) OnKeyDown?.Invoke(kvp.Value);
        }
    }

    public void RemapKey(Key key, KeyCode keycode)
    {
        _mapping[key] = keycode;
    }
    
    public bool GetKey(Key key)
    {
        return Input.GetKey(_mapping[key]);
    }

    public bool GetKeyDown(Key key)
    {
        return Input.GetKeyDown(_mapping[key]);
    }

    public bool GetKeyUp(Key key)
    {
        return Input.GetKeyUp(_mapping[key]);
    }
}