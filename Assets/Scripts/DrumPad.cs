using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DrumPad : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private AudioClip sound;
    [SerializeField] private float padAnimTime = 0.1f;
    [SerializeField] private AnimationCurve padAnimCurve;
    
    private AudioSource[] _audioSources;

    private void Start()
    {
        _audioSources = new AudioSource[4];
        for (int i = 0; i < _audioSources.Length; i++)
        {
            _audioSources[i] = gameObject.AddComponent<AudioSource>();
            _audioSources[i].playOnAwake = false;
            _audioSources[i].clip = sound;
            _audioSources[i].loop = false;
        }
    }

    public void Play()
    {
        PlaySound();
        StopAllCoroutines();
        StartCoroutine(DoAnimatePad());
    }

    private void PlaySound()
    {
        foreach (AudioSource source in _audioSources)
        {
            if(source.isPlaying) continue;
            source.PlayOneShot(sound);
            break;
        }
    }
    
    private IEnumerator DoAnimatePad()
    {
        float timer = 0f;
        Vector3 start = Vector3.one;
        Vector3 end = Vector3.one * 1.2f;
        while (timer < padAnimTime)
        {
            timer += Time.deltaTime;
            float alpha = padAnimCurve.Evaluate(timer / padAnimTime);
            image.transform.localScale = Vector3.Lerp(start, end, alpha);
            yield return null;
        }
        image.transform.localScale = start;
        yield return null;
    }
}