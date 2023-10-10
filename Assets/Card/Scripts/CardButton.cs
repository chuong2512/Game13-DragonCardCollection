using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    [FormerlySerializedAs("_songID")] [SerializeField]
    private int _bookID;

    [SerializeField] private Image _cardImage;

    //[SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Button _button;

    [SerializeField] private GameObject _lockObj;
    [SerializeField] private GameObject _chooseObj;

    private bool _isUnlock;

    public bool IsUnlock
    {
        get => _isUnlock;
        set => _isUnlock = value;
    }

    public int BookID
    {
        get => _bookID;
        set => _bookID = value;
    }

    private void OnValidate()
    {
        _button = GetComponent<Button>();
    }

    void Start()
    {
        _button?.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        AudioManager.Instance.ClickSound();
        if (_isUnlock)
        {
            UIManager.Instance.OpenScreen<BookModel>(ScreenType.BookScreen, new BookModel()
            {
                bookID = _bookID
            });
        }
        else
        {
            UIManager.Instance.OpenScreen<BookModel>(ScreenType.UnlockPopup, new BookModel()
            {
                bookID = _bookID
            });
        }
    }

    public void SetID(int id)
    {
        _bookID = id;
        _isUnlock = GameDataManager.Instance.playerData.CheckLock(_bookID);

        var songSo = GameDataManager.Instance.cardSo;
        _cardImage.sprite = songSo.GetBookWithID(_bookID).icon;
        Refresh();
    }

    public void Refresh()
    {
        _isUnlock = GameDataManager.Instance.playerData.CheckLock(_bookID);
        _lockObj.SetActive(!_isUnlock);
        Choose(_bookID == GameDataManager.Instance.currentID);
    }

    public void Choose(bool b)
    {
        _chooseObj.SetActive(false);
    }
}