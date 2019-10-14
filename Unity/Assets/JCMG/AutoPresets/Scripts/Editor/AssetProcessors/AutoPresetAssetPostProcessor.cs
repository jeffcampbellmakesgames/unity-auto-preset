using UnityEditor;
using UnityEngine;

namespace JCMG.AutoPresets.Editor
{
	/// <summary>
	/// An asset processor that looks for instances of <see cref="AutoPresetConfig"/> in the same folder as
	/// the imported asset and attempts to apply them if applicable.
	/// </summary>
	internal sealed class AutoPresetAssetPostProcessor : AssetPostprocessor
	{
		#region Unity Asset Events

		private void OnPostprocessAudio(AudioClip arg)
		{
			TryApplyPreset();
		}

		private void OnPostprocessCubemap(Cubemap texture)
		{
			TryApplyPreset();
		}

		private void OnPostprocessMaterial(Material material)
		{
			TryApplyPreset();
		}

		private void OnPostprocessModel(GameObject g)
		{
			TryApplyPreset();
		}

		private void OnPostprocessSpeedTree(GameObject arg)
		{
			TryApplyPreset();
		}

		private void OnPostprocessTexture(Texture2D texture)
		{
			TryApplyPreset();
		}

		private void OnPreprocessAnimation()
		{
			TryApplyPreset();
		}

		private void OnPreprocessAssembly(string pathName)
		{
			TryApplyPreset();
		}

		private void OnPreprocessAsset()
		{
			TryApplyPreset();
		}

		private void OnPreprocessAudio()
		{
			TryApplyPreset();
		}

		private void OnPreprocessModel()
		{
			TryApplyPreset();
		}

		private void OnPreprocessSpeedTree()
		{
			TryApplyPreset();
		}

		private void OnPreprocessTexture()
		{
			TryApplyPreset();
		}

		#endregion

		/// <summary>
		/// Checks to see if there are any <see cref="AutoPresetConfig"/> asset instances in the same folder
		/// as the imported asset and if they apply to it; if so, the preset is automatically applied.
		/// </summary>
		private void TryApplyPreset()
		{
			AutoPresetConfig preset;
			if (!TryGetPresetAsset(out preset))
			{
				return;
			}

			preset.ApplyTo(assetImporter);
		}

		/// <summary>
		/// Returns true if an <see cref="AutoPresetConfig"/> instance was found in the same folder as the
		/// asset that applies to it, otherwise false. If true, <paramref name="autoPreset"/> will be
		/// initialized with that value.
		/// </summary>
		/// <param name="autoPreset"></param>
		/// <returns></returns>
		private bool TryGetPresetAsset(out AutoPresetConfig autoPreset)
		{
			autoPreset = null;

			var parentFolder = AssetDatabaseTools.GetAssetParentFolderPath(assetPath);
			var autoPresetConfigs = AssetDatabaseTools.GetAllAutoPresetConfigs(new[] { parentFolder });

			foreach (var autoPresetConfig in autoPresetConfigs)
			{
				if (!autoPresetConfig.CanBeAppliedTo(assetImporter))
				{
					continue;
				}

				autoPreset = autoPresetConfig;
				return true;
			}

			return false;
		}
	}
}
