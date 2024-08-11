using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ResolutionSettings : MonoBehaviour
{
	[SerializeField] TMP_Dropdown _resolutionDropdown;
	Resolution[] _resolutions;
	// Start is called before the first frame update
	void Start()
	{
		_resolutions = Screen.resolutions;
		_resolutionDropdown.ClearOptions();

		int currentResolutionIndex = 0;
		List<string> options = new List<string>();

		for (int i = 0; i < _resolutions.Length; i++)
		{
			string option = _resolutions[i].width.ToString() + "x" + _resolutions[i].height.ToString();
			options.Add(option);

			if (_resolutions[i].width == Screen.currentResolution.width &&
				_resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}
		}

		_resolutionDropdown.AddOptions(options);
		_resolutionDropdown.value = currentResolutionIndex;
		_resolutionDropdown.RefreshShownValue();
	}

	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = _resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

}
