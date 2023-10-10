using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public TextMeshProUGUI text;
    private PlayerData _playerData;
    public Button button;
    public MusicController musicController;
    private int price;
    private int id;

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            AudioManager.Instance.ClickSound();
            musicController.Pay(price, id);
        });
    }

    public void Show(int price, int id)
    {
        gameObject.SetActive(true);
        text.text = $"x{price}";
        this.price = price;
        this.id = id;
    }
}