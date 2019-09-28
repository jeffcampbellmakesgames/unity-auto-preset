using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace JCMG.AutoPresets.Editor
{
	internal static class AssetDatabaseTools
	{
		private static readonly StringBuilder SB = new StringBuilder();

		public const string UNITY_ASSETS_FOLDER_NAME = "Assets";
		public const string FORWARD_SLASH_STR = "/";
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

					parentFolder = SB.ToString().TrimEnd('/');
				}
			}

			return parentFolder;
		}

		public static IEnumerable<Object> LoadAllAssets(string[] guids)
		{
			var list = new List<Object>();
			foreach (var guid in guids)
			{
				var assetPath = AssetDatabase.GUIDToAssetPath(guid);
				var asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Object));
				if (asset != null)
				{
					list.Add(asset);
				}
			}

			return list;
		}

		public static IEnumerable<T> LoadAllAssets<T>(string[] guids)
		{
			return LoadAllAssets(guids).Cast<T>();
		}

		/// <summary>
		/// Returns the root folder of the Unity Project
		/// </summary>
		/// <returns></returns>
		public static string GetProjectPath()
		{
			return Application.dataPath.Substring(0, Application.dataPath.Length - 6);
		}
	}
}
