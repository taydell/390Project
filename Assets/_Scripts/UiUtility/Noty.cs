using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Noty : MonoBehaviour
{
    [SerializeField]
    private Text _titleText;
    [SerializeField]
    private Text _messageText;
    [SerializeField]
    private GameObject _parent;
    [SerializeField]
    private Animation _anim;
    [SerializeField]
    private AnimationClip _draw;
    [SerializeField]
    private AnimationClip _undraw;

    public static Noty instance;

    private void Awake()
    {
        instance = this;
    }

    public void Display(string title, string message, float duration)
    {
        _anim.CrossFade(_draw.name);
        _titleText.text = title;
        _messageText.text = message;
        _parent.SetActive(true);

        duration = Mathf.Clamp(duration, _draw.length, float.MaxValue);
        StartCoroutine(Stop(duration));
    }

    IEnumerator Stop(float duration)
    {
        yield return new WaitForSeconds(duration);
        _anim.CrossFade(_undraw.name);
        StartCoroutine(End());
        
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(_undraw.length);
        _parent.SetActive(false);
    }
}
