using UnityEditor;
using UnityEngine;

namespace JCMG.AutoPresets.Editor
{
    [CustomEditor(typeof(AutoPresetConfig))]
    internal sealed class AutoPresetConfigInspector : UnityEditor.Editor
    {
        private const string ACTIONS_TITLE_TEXT = "Actions";
        private const string REIMPORT_BUTTON_TEXT = "Reimport linked assets";

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GUILayout.Space(5);
            GUILayout.Label(ACTIONS_TITLE_TEXT, EditorStyles.boldLabel);

            var config = (AutoPresetConfig) target;

            if (GUILayout.Button(REIMPORT_BUTTON_TEXT))
            {
                var assetPath = AssetDatabase.GetAssetPath(config);
                var parentPath = AssetDatabaseTools.GetAssetParentFolderPath(assetPath);

                AssetDatabaseTools.ReimportAllAssets(parentPath, config);
            }
        }
    }
}
