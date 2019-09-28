# Auto Preset

## About
Auto Preset enables scriptable configuration of assets from the Unity Editor without requiring any additional code.

## Overview
AutoPresetConfig is a simple Scriptable Object derived class that holds a reference to a native Unity Preset asset; these assets can be created from any native Unity asset or component, containing the serialized settings of that asset in a dedicated Scriptable Object. Any asset imported in the same folder as a AutoPresetConfig asset(s) will check to see if any of them apply to that type of asset. If they do, the first applicable AutoPresetConfig asset found will automatically be applied to that newly imported asset.

## Use-Cases and Usage
This type of automatic, scriptable configuration of assets can be used to reduce the boilerplate, often tedious work of configuring newly imported assets and can prevent errors from doing so manually. 

For example, a group of textures may require specific compression settings and properties in order to be rendered without artifacts by a shader. This may require manual tweaking to elicit what those settings are and apply them manually from that point on, requiring time and energy to make sure all of the settings are correct for any new textures and inviting human error.

Instead, follow these steps to have those settings applied automatically every time a texture is imported into a specific folder.

* Configure one texture using the proper settings and save those settings as a preset by clicking the dial icon at the top right of its inspector. This allows you to save those settings as a preset.

![Preset Button on Inspector](https://github.com/jeffcampbellmakesgames/unity-auto-preset/blob/master/Images/PresetButtonOnInspector.png)

* Create a AutoPresetConfig asset in that folder by right-clicking on the folder in the project view and selecting `Create=>JCMG=>AutoPreset=>AutoPresetConfig` and give it an appropriate name.

![Preset Button on Inspector](https://github.com/jeffcampbellmakesgames/unity-auto-preset/blob/master/Images/AutoPresetConfigCreateMenu.png)

* Assign that newly created Preset asset to the AutoPresetConfig in its inspector.

![Preset Button on Inspector](https://github.com/jeffcampbellmakesgames/unity-auto-preset/blob/master/Images/AutoPresetConfigInspector.png)

Using this workflow, you can automatically configure textures when imported or any of the other supported asset types below:

### Supported Asset Types
* Textures
* AudioClips
* Materials
* Cubemaps
* Animations
* Assemblies/Plugins
* Models
* SpeedTree
* Any other Unity or custom assets that can generate a Preset.

## Contribution
If you find any bugs or if there is a new feature you desire, please create a new issue [here](https://github.com/jeffcampbellmakesgames/unity-auto-preset/issues) or add your comments/thoughts to a related existing issue. If you are interested in contributing a PR for either of these types of issues, read the contribution guidelines here first and please do so!

## Support
If this is useful to you and/or you’d like to see future development and more tools in the future, please consider supporting it either by contributing to the Github projects (submitting bug reports or features,pull requests) or by buying me coffee using any of the links below. Every little bit helps!

[![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/I3I2W7GX)
