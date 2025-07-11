# R2API.ContentManagement - ContentPack creation and Management.

## About

R2API.ContentManagement is a submodule assembly for R2API that provides a unifieed system for handling ContentPacks from mods that use R2API.
The ContentManagement submodule handles automatic creation of ContentPacks for an assembly that calls a method that adds any piece of content to the game, as such, most Content related submodules have a direct dependency on the ContentManagement submodule.

## Use Cases / Features

R2API.ContentManaged is used for mods that would like to have R2API handle the content added to the game, alongside mods that would like to obtain the benefits of letting R2API handle certain parts of content creation

* R2APISerializableContentPack is an updated version of the RoR2's original SerializableContentPack, it contains all the missing fields that where added in Survivors of the Void alongside safety procedures to avoid adding null entries to the finalized content pack.
    * Note: R2APISerializableContentPack does not inherit from SerializableContentPack, and the ContentManagement system doesnt support any other kind of SerializableContentPack, wether the vanilla one or a custom one.
* By adding a content pack to the ContentManagement, R2API will automatically handle the following things:
    * Avoid null entries on content packs.
    * Avoid empty strings as asset names, which fixes certain issues such as SkillDef preferences.
    * Systems for connecting a ContentPack to the assembly that added it, and viceversa.
    * Automatic loading of the ContentPack using a ContentPackProvider (Optional)
* A ContentAddition class that can be used for adding ContentPieces using the ContentManager, the class comes with error checking functionality which will inform the mod creator if something is wrong with their content piece (IE: An artifact def that does not have icons. (Causes exceptions at runtime));
    * While ItemDefs, EquipmentDefs and EliteDefs can be added by ContentAddition, it is heavily recommended to use the Items and Elites modules respectively.

## Changelog

### '1.0.10'
* Enhances modded Game Mode support
    * `ContentAddition.AddGameMode()` now takes an additional `gameModeDescription` argument instead of requiring modders to add the component themselves.
    * Now sorts modded game modes separately, so there's no need to add an `x` to the beginning of Game Mode prefabs

### '1.0.9'
* Adds better support for modded Game Modes
    * Adds fixes for modded Game Modes not showing up in the multiplayer menu
    * Adds sorting for Game Modes to display them in the proper order (modded modes after vanilla)
    * Adds automatic button addition to the "Alternate GameModes" screen
    * Adds custom component for additional Game Mode info

### '1.0.8'
* Adds additional null checks to the ItemRelationshipProvider content.

### '1.0.7'
* Adds ItemRelationshipProviders to the ContentPack as intended.

### '1.0.6'
* Fix SystemInitializer infinite loop.

### '1.0.5'
* Initial fixes for SOTS DLC2 Release.

### '1.0.4'
* Fix content getting erroneously attributed to R2API's contentpack.

### '1.0.3'
* Re-opt-in to system-initializers,fixing behavior related to late-registration of content.

### '1.0.2'
* Make the API safer.

### '1.0.1'
* Fix some R2API nuget packages that had their dependencies version numbers set incorrectly.

### '1.0.0'
* Split from the main R2API.dll into its own submodule.
