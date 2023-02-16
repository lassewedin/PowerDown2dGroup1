using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerDownCard : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Image image;

    void Start() {
        SetPowerDown();
	}

    public void SetPowerDown() {

        titleText.text = "Bad Apple";
        descriptionText.text = "Max health -50";
        image.sprite = Resources.Load<Sprite>(string.Format("Grapes/Icon_{0:D2}", 2));

	}

    public void OnClicked() {

	}
}
