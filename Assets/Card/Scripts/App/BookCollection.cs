using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BookCollection : MonoBehaviour
{
    [FormerlySerializedAs("_songButton")] [SerializeField]
    private CardButton cardButton;

    [SerializeField] private Transform _content;

    private CardButton _currentCard;
    private List<CardButton> _songButtons = new List<CardButton>();

    void Start()
    {
        ShowAllSongButtons();
        GameManager.OnChooseSong += OnChooseBook;
        GameManager.OnUnlockSong += OnUnlockBook;
    }

    private void OnUnlockBook(int obj)
    {
        Refresh();
    }

    private void OnChooseBook(int i)
    {
        ChooseItem(i);
    }

    private void ShowAllSongButtons()
    {
        var count = GameDataManager.Instance.cardSo.bookInfors.Length;

        for (int i = 0; i < count; i++)
        {
            var song = Instantiate(cardButton, _content);
            song.SetID(i);
            _songButtons.Add(song);
        }

        GetCurrentSong();
    }

    public CardButton GetCurrentSong()
    {
        _currentCard = _songButtons.Find(song => song.BookID == GameDataManager.Instance.currentID);
        return _currentCard;
    }

    public void Refresh()
    {
        foreach (var song in _songButtons)
        {
            song.Refresh();
        }
    }

    public void ChooseItem(int songID)
    {
        _currentCard?.Choose(false);
        GetCurrentSong();
        _currentCard?.Choose(true);
    }
}