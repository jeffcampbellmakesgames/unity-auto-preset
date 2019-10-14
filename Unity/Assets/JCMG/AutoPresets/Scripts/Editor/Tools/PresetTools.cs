using System;
using UnityEditor;
using UnityEditor.Presets;
using UnityEngine;

namespace JCMG.AutoPresets.Editor
{
    /// <summary>
    /// Helper methods for dealing with <see cref="Preset"/>s.
    /// </summary>
    internal static class PresetTools
    {
        public static void UpdateLinkedAssets(Preset preset)
        {
            var autoPresetConfigList = AssetDatabaseTools.GetAllAutoPresetConfigs();

            const string UPDATE_ASSETS_TITLE = "Updating AutoPresetConfigs";

            EditorUtility.DisplayProgressBar(UPDATE_ASSETS_TITLE, String.Empty, 0f);

            for (var i = 0; i < autoPresetConfigList.Count; i++)
            {
                var progress = Mathf.Clamp01((float)i / autoPresetConfigList.Count);
                EditorUtility.DisplayProgressBar(UPDATE_ASSETS_TITLE,String.Empty, progress);

                var autoPresetConfig = autoPresetConfigList[i];
                if (autoPresetConfig.Preset != preset)
                {
                    continue;
                }

                var msg = string.Format("Importing assets for [{0}]", autoPresetConfig.name);

                EditorUtility.DisplayProgressBar(UPDATE_ASSETS_TITLE,msg, progress);

                var assetPath = AssetDatabase.GetAssetPath(autoPresetConfig);
                var parentPath = AssetDatabaseTools.GetAssetParentFolderPath(assetPath);

                AssetDatabaseTools.ReimportAllAssets(parentPath, autoPresetConfig);
            }

            EditorUtility.ClearProgressBar();
        }
    }
}
