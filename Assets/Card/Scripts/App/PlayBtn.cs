using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    [SerializeField] private Sprite _playIcon, _stopIcon;

    private void Start()
    {
        _button.onClick.AddListener(OnClickPlayBtn);
        GameManager.OnPlayMusic += OnPlayMusic;
    }

    private void OnClickPlayBtn()
    {
        AudioManager.Instance.ClickPlayBtn();
        AudioManager.Instance.ClickSound();
    }

    private void OnPlayMusic(bool on)
    {
        _image.sprite = on ? _stopIcon : _playIcon;
    }
}