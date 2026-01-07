using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MiniPlayerProfile : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text nickname;
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text coinsText;

    [SerializeField] private string defaultIconName = "DefaultIcon";

    private void Awake()
    {
        if (PlayerSession.Instance != null)
        {
            var session = PlayerSession.Instance;

            nickname.text = session.Nickname;
            levelText.text = $"Lv: {session.Level}";
            coinsText.text = session.Coins.ToString();

            SetIcon(session.Icon);
        }
        else
        {
            Debug.LogWarning("PlayerSession não encontrado!");
            nickname.text = "";
            levelText.text = "";
            coinsText.text = "";
            SetIcon(defaultIconName);
        }
    }

    public void SetIcon(string iconName)
    {
        Sprite icon = Resources.Load<Sprite>($"Players/Icons/{iconName}");

        if (icon == null)
        {
            Debug.LogWarning($"Ícone não encontrado: {iconName}, usando padrão.");
            icon = Resources.Load<Sprite>($"Players/Icons/{defaultIconName}");
        }

        iconImage.sprite = icon;
    }
}
