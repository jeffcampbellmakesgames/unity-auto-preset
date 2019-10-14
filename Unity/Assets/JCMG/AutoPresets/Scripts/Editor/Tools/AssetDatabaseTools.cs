using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace JCMG.AutoPresets.Editor
{
	/// <summary>
	/// Helper methods for dealing with the <see cref="AssetDatabase"/>.
	/// </summary>
	internal static class AssetDatabaseTools
	{
		private static readonly StringBuilder SB = new StringBuilder();

		private const string AUTO_PRESET_CONFIG_SEARCH_FILTER = "t:AutoPresetConfig";
		private const string WILDCARD_SEARCH = "*";
		private const string META_FILE_EXTENSION = ".meta";
		private const string UNITY_ASSETS_FOLDER_NAME = "Assets";
		private const string FORWARD_SLASH_STR = "/";
		private const char FORWARD_SLASH_CHAR = '/';

		/// <summary>
		/// Returns the parent folder of a Unity asset or folder path. Where the asset is in the root Assets
		/// folder already or is the Assets folder, the Assets folder is returned.
		/// </summary>
		/// <param name="unityRelativePath"></param>
		/// <returns></returns>
		public static string GetAssetParentFolderPath(string unityRelativePath)
		{
			var parentFolder = UNITY_ASSETS_FOLDER_NAME;

			var normalizedUnityRelativeFilePath = unityRelativePath.EndsWith(FORWARD_SLASH_STR)
				? unityRelativePath.Remove(unityRelativePath.Length - 1)
				: unityRelativePath;

			if (normalizedUnityRelativeFilePath.StartsWith(UNITY_ASSETS_FOLDER_NAME))
			{
				var splitAssetPathParts = normalizedUnityRelativeFilePath.Split(FORWARD_SLASH_CHAR);
				if (splitAssetPathParts.Length > 1)
				{
					SB.Clear();
					for (var i = 0; i < splitAssetPathParts.Length - 1; i++)
					{
						SB.Append(splitAssetPathParts[i]);
						SB.Append(FORWARD_SLASH_CHAR);
					}

					parentFolder = SB.ToString().TrimEnd(FORWARD_SLASH_CHAR);
				}
			}

			return parentFolder;
		}

		/// <summary>
		/// Returns the root folder of the Unity Project
		/// </summary>
		/// <returns></returns>
		public static string GetProjectPath()
		{
			return Application.dataPath.Substring(0, Application.dataPath.Length - 6);
		}

		/// <summary>
		/// Reimports all assets at <paramref name="path"/> where the preset in <paramref name="applicableConfig"/> applies.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="applicableConfig"></param>
		public static void ReimportAllAssets(string path, AutoPresetConfig applicableConfig)
		{
			var projectPath = GetProjectPath();
			var fullPath = Path.Combine(projectPath, path);

			var assetPaths = Directory.GetFiles(fullPath, WILDCARD_SEARCH, SearchOption.TopDirectoryOnly)
				.Where(x => !x.EndsWith(META_FILE_EXTENSION))
				.Select(y => y.Replace(projectPath, string.Empty));

			foreach (var assetPath in assetPaths)
			{
				var assetImporter = AssetImporter.GetAtPath(assetPath);
				if (assetImporter != null && applicableConfig.CanBeAppliedTo(assetImporter))
				{
					AssetDatabase.ImportAsset(assetPath);
				}
			}
		}

		/// <summary>
		/// Returns all <see cref="AutoPresetConfig"/> instances in the project.
		/// </summary>
		/// <returns></returns>
		public static IReadOnlyList<AutoPresetConfig> GetAllAutoPresetConfigs()
		{
			return GetAllAutoPresetConfigs(null);
		}

		/// <summary>
		/// Returns all <see cref="AutoPresetConfig"/> instances in the project located in <paramref name="folderPaths"/>.
		/// </summary>
		/// <returns></returns>
		public static IReadOnlyList<AutoPresetConfig> GetAllAutoPresetConfigs(string[] folderPaths)
		{
			var assetGUIDs = folderPaths != null
				? AssetDatabase.FindAssets(AUTO_PRESET_CONFIG_SEARCH_FILTER, folderPaths)
				: AssetDatabase.FindAssets(AUTO_PRESET_CONFIG_SEARCH_FILTER);

			var autoPresetConfigList = new List<AutoPresetConfig>();
			foreach (var assetGUID in assetGUIDs)
			{
				var assetPath = AssetDatabase.GUIDToAssetPath(assetGUID);
				var autoPresetConfig = AssetDatabase.LoadAssetAtPath<AutoPresetConfig>(assetPath);
				if (autoPresetConfig != null)
				{
					autoPresetConfigList.Add(autoPresetConfig);
				}
			}

			return autoPresetConfigList;
		}
	}
}
