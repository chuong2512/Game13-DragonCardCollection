using ABCBoard.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Card.Scripts.UI
{
    public class UnlockCardPopup : BaseScreenWithModel<BookModel>
    {
        private int _bookID;

        [SerializeField] private TextMeshProUGUI _text;

        [FormerlySerializedAs("_buttonPlay")] [SerializeField]
        private Button _buttonUnlock;

        void Start()
        {
            _buttonUnlock?.onClick.AddListener(OnClickButton);
        }

        private void OnClickButton()
        {
            AudioManager.Instance.ClickSound();

            var playerData = GameDataManager.Instance.playerData;
            
            if (playerData.intDiamond >= 10)
            {
                playerData.Unlock(_bookID);
                playerData.SubDiamond(10);
                UIManager.Instance.Back();
                GameManager.OnUnlockSong.Invoke(0);
            }
            else
            {
                UIManager.Instance.OpenScreen(ScreenType.NotEnoughMoney);
            }
        }

        public override void BindData(BookModel model)
        {
            _bookID = model.bookID;
            SetImage();
        }

        private void SetImage()
        {
            _text.SetText($"Do you want to unlock Image {_bookID} ?");
        }

        public override ScreenType GetID() => ScreenType.UnlockPopup;
    }
}