using System.Collections.Generic;
using UnityEngine;

public class PowerDownSelect : MonoBehaviour
{
	public PowerDownCard card1;
	public PowerDownCard card2;

	public void Start() {
		card1.onClick += OnClickedCard;
		card2.onClick += OnClickedCard;
	}

	private void OnClickedCard() {
		// Hide
		Show(false);
	}

	public void Show(bool show) {
		if (!show) {
			gameObject.SetActive(false);
			return;
		}

		gameObject.SetActive(true);

		// Pick two random power downs

		var allPowerDowns = new List<IPowerDown>(PowerDownManager.m_PowerDowns);

		var firstPowerDown = allPowerDowns[Random.Range(0, allPowerDowns.Count)];
		allPowerDowns.Remove(firstPowerDown);
		var secondPowerDown = allPowerDowns[Random.Range(0, allPowerDowns.Count)];

		card1.SetPowerDown(firstPowerDown);
		card2.SetPowerDown(secondPowerDown);
	}
}
