using UnityEditor.Presets;
using UnityEngine;

namespace JCMG.AutoPresets.Editor
{
	/// <summary>
	/// <see cref="AutoPresetConfig"/> allows for specifying a
	/// </summary>
	[CreateAssetMenu(menuName = "JCMG/AutoPreset/AutoPresetConfig", fileName = "NewAutoPresetConfig")]
	public sealed class AutoPresetConfig : ScriptableObject
	{
		/// <summary>
		/// The <see cref="Preset"/> to be applied to <see cref="Object"/> derived assets in the
		/// same folder as this <see cref="AutoPresetConfig"/> instance.
		/// </summary>
		public Preset Preset
		{
			get => _preset;
			set { _preset = value; }
		}

		#pragma warning disable 0649
		[SerializeField]
		private Preset _preset;
		#pragma warning restore 0649

		/// <summary>
		/// Returns true if <seealso cref="Preset"/> is assigned and it can be applied to <paramref name="obj"/>.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public bool CanBeAppliedTo(Object obj)
		{
			return _preset != null && _preset.CanBeAppliedTo(obj);
		}

		/// <summary>
		/// Returns true if <seealso cref="Preset"/> is assigned, it can be applied to <paramref name="obj"/>, and the
		/// preseT has been applied to <paramref name="obj"/>.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public bool ApplyTo(Object obj)
		{
			return _preset != null && _preset.ApplyTo(obj);
		}
	}
}
