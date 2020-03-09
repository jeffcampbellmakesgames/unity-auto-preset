using UnityEditor;
using UnityEngine;

namespace JCMG.AutoPresets.Editor
{
	internal static class AutoPresetMenuItems
	{
		[MenuItem("Tools/JCMG/AutoPreset/Submit bug or feature request")]
		internal static void OpenURLToGitHubIssuesSection()
		{
			const string GITHUB_ISSUES_URL = "https://github.com/jeffcampbellmakesgames/unity-auto-preset/issues";

			Application.OpenURL(GITHUB_ISSUES_URL);
		}

		[MenuItem("Tools/JCMG/AutoPreset/Donate to support development")]
		internal static void OpenURLToKoFi()
		{
			const string KOFI_URL = "https://ko-fi.com/stampyturtle";

			Application.OpenURL(KOFI_URL);
		}

		[MenuItem("Tools/JCMG/AutoPreset/About")]
		internal static void OpenAboutModalDialog()
		{
			AboutWindow.View();
		}

	}
}
