using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerDownCard : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Image image;

    public delegate void OnClick();
    public event OnClick onClick;

    private IPowerDown powerDown;

    public void SetPowerDown(IPowerDown powerDown) {
        this.powerDown = powerDown;
        titleText.text = powerDown.title;
        descriptionText.text = powerDown.description;
        int imageIdx = Mathf.Clamp(Mathf.Abs(powerDown.GetType().GetHashCode()) % 12 + 1, 1, 12);

        image.sprite = Resources.Load<Sprite>(string.Format("Grapes/Icon_{0:D2}", imageIdx));
	}

    public void OnClicked() {
        PowerDownManager.m_ActivePowerDowns.Add(powerDown.GetType());
        powerDown?.Activate();


        powerDown = null;
        onClick?.Invoke();
	}
}
