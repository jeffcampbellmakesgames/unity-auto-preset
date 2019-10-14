using UnityEditor;
using UnityEditor.Presets;

namespace JCMG.AutoPresets.Editor
{
    /// <summary>
    /// Context menu-items for <see cref="Preset"/>s.
    /// </summary>
    internal static class PresetContextMenus
    {
        [MenuItem("Assets/AutoPreset/Reimport Linked Assets")]
        private static void ReimportLinkedAssetsForPreset()
        {
            PresetTools.UpdateLinkedAssets((Preset)Selection.activeObject);
        }

        [MenuItem("Assets/AutoPreset/Reimport Linked Assets", true)]
        private static bool ReimportLinkedAssetsForPresetValidation()
        {
            return Selection.activeObject is Preset;
        }
    }
}
