using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QualitySettingsManager : MonoBehaviour
{
	[SerializeField] TMP_Dropdown _qualityDropdown;
	// Start is called before the first frame update
	void Start()
	{
		// Populate the dropdown with the available quality levels
		_qualityDropdown.ClearOptions();
		List<string> options = new List<string>(QualitySettings.names);
		_qualityDropdown.AddOptions(options);

		// Set the dropdown value to the current quality level
		_qualityDropdown.value = PlayerPrefs.GetInt("quality", 0);
		_qualityDropdown.RefreshShownValue();
	}

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
		PlayerPrefs.SetInt("quality", qualityIndex);
	}
}
