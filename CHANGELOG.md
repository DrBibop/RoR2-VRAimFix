### 1.0.0
- Initial release of the mod.

### 1.1.0
- All menus are now visible in VR.
- Enemy health bars are now correctly positioned above enemies.
- Ping icons have been pushed further away from the camera.
- Added a config setting to disable VR.

### 1.1.1
- Fixed some indicator icons that were too large.

### 1.1.2
- Fixed yet another oversized indicator.
- Removed R2API dependency.
- Lowered the top part of the HUD (was reverted due to the anniversary update).
- Fixed a bug that caused the game to launch in VR after disabling or uninstalling the mod.
- Removed the need for launch options (this causes the game to launch in SteamVR by default).
- Added a config setting to launch in Oculus mode.
- Removed the "Enable VR" setting.

### 1.2.0
- Added a bindable key to recenter the HMD (Default: RCtrl/Dpad-Up).
- Added HUD config settings for UI scale and anchor placements.
- Fixed a bug that caused the map name to display too high up.
- Added MMHOOK Standalone as dependency (was previously included with the mod).

### 1.2.1
- Icons no longer have a fixed distance.
- Fixed a bug that caused icons to not correctly appear above targets.
- Fixed targeting indicator placements (Huntress primary, Engineer missile launcher, recycler, capacitor, etc.).

### 1.3.0
- Added first person config setting.
- Added snap turn and snap turn angle config settings.
- Added camera pitch lock config setting.
- Removed camera recoil effects.
- The pause menu now follows the camera rotation.
- Changed MMHOOK dependency to HookGenPatcher.

### 2.0.0
- Added motion controls support.
- Added a vignette during high-mobility abilities to reduce motion sickness (can be disabled).
- A dialog box now opens in the main menu telling the player how to recenter the HMD.
- The sprint icon on the bottom right turns yellow while sprinting to compensate for the lack of visual cues like the crosshair.
- The HUD should now appear at the same size no matter your resolution/FOV.
- Added HUD width and height config settings (HUD anchor settings need to be reset to default if you have downloaded a previous version).
- Fixed a bug that caused some targeting indicators to not face the camera properly.
- Fixed a bug that caused the dialog box in the pause menu to not follow the menu rotation.

### 2.0.1
- Reduced the size of multiple muzzle flashes and effects.
- New setting: "Hide broken decal textures".
- Added "Survivor Settings" config category:
	- New setting: "Commando: Dual wield".
	- New setting: "Bandit: Weapon grip snap angle".
	- New setting: "Mercenary: Swing speed threshold".
	- New setting: "Loader: Swing speed threshold".
	- New setting: "Acrid: Swing speed threshold".
- The pop-up appearing when selecting a lobby in multiplayer now correctly appears in the headset.
- The black transition screens now correctly appear in the headset.
- The credits now appear in the headset (it is currently stuck on the headset but this will change soon).
- Fixed a bug that caused inputs to not register when no profiles are selected.
- Fixed a bug that caused the profile creation pop-up to be uninteractable.

### 2.1.0
- Added a wrist HUD setting that attaches the health bar, money display and skills to the wrist.
- Added a watch HUD setting that attaches the inventory, chat, difficulty, objective and allies to a watch-like HUD.
- Added a smooth HUD setting that adds smoothing to the camera HUD when moving the headset.
- Added a spectator screen that appears in front of you when spectating players.
- Added "Ray color" and "Ray opacity" settings to customize the aim ray.
- Added more detailed models for Loader's hands, Bandit's shotgun and Bandit's revolver.
- Removed "UI scale" setting as it already exists in-game.
- Removed the center smoke effect on Bandit's stealth ability for improved visibility.
- Possibly fixed a bug that caused the Heretic wings to appear on the wrong player which would break some abilities.
- Fixed a bug that caused Heretic's primary skill projectiles to not appear from the hand after transforming.
- Fixed a bug that caused Vive Cosmos controllers to use the standard Vive controller binds.

### 2.1.1
- The credits no longer stick to the camera.
- The spectator screen is now fully opaque.
- Loader's aim rays have been aligned better with the mech arms.
- Fixed a bug that caused the spectator screen to not appear in multiplayer for non-host players.
- Fixed a bug that caused the shield effect to appear abnormally large on Bandit's new weapon models.
- Fixed a bug that caused MUL-T's left hand animations to break when activating power mode right before transport mode.

### 2.2.0
- Compatibility with the new VR API which adds the possibility of VR compatible mods such as custom characters.
- New hand models for all survivors.
- Equipments, items and body effects that were obstructing vision are now hidden for better visibility.
- Fixed a bug that made bullets and projectiles no longer appear from weapon muzzles after reviving.
- Fixed a bug that made bullets no longer appear from the main weapon's muzzle on Bandit when disabling Commando's dual wield setting.

### 2.2.1
- Fixed a bug that caused the Smooth HUD config to be ineffective.
- Fixed a bug that caused floating equipments to re-appear when teleporting to a new stage.

### 2.3.0
- The scoreboard and the profile menu can now be accessed by holding the menu button.
- Snap turns will now repeat when holding a direction.
- Added a "Snap Turn Hold Delay" setting.
- Added a "Camera Health Bar" setting which puts the health bar at the bottom-middle of the camera HUD for better visibility.
- Added a new EXPERIMENTAL "Roomscale Tracking Space" setting.
- Added a new EXPERIMENTAL "Player Height" setting.
- The aim ray will now activate on the appropriate hand when you have an aimable equipment or heresy skills.
- The Soulbound Catalyst and the Frost Relic no longer appear around the player.
- Removed "Hide broken decal textures" config.
- Fixed a bug that caused decals to only render on the left eye.
- Fixed a bug that caused the camera HUD to freeze in place while paused.
- Fixed a bug that caused parts of the multiplayer menu to not render properly creating an offset.

### 2.4.0
- You can now freely bind your controls with SteamVR.
	- Every single action can be bound to separate inputs.
	- This new system removes the need to download binds for Index Knuckles and Reverb G2 controllers.
	- A few extra bindable actions have been added for these mods: ExtraSkillSlots, VoiceChat, SkillsPlusPlus and ProperSave.
- Added haptic feedback (controller rumble). The intensity can be adjusted with the in-game gamepad setting.
- In-game "cutscenes" that take control of the camera have been improved to reduce risks of nausea and clipping.
- Fixed a bug that caused inputs to break after selecting a profile.
- Fixed a bug that placed and scaled enemy health bars and some indicators incorrectly when using the roomscale tracking setting.

### 2.5.0
- Added the LIV SDK for XR capture support.
	- Only available with SteamVR and with the "Roomscale tracking space" setting enabled.
	- A setting has been added to display the classic HUD on the XR camera.
- All mod configs can now be edited with the in-game settings menu. Some will only be applied on the next stage or after restarting.
- Elements in the intro cutscene and the escape cutscene have been scaled and placed in a more realistic way.
- The grip sensitivity has been reduced on the default Index Knuckles bindings.
- The "Roomscale tracking space" setting is no longer in an experimental stage and is now enabled by default.
- The default value of Loader's melee swing speed threshold has been slightly reduced.
- Reduced the size of the charging Nano-Bomb effect on Artificer's hand for better visibility.
- Fixed a bug that prevented cutscene subtitles to display correctly in VR.
- Fixed a bug that caused the camera to be placed too high in menus when using roomscale tracking.
- Fixed a bug that caused the Visions on Heresy skill to be activated by swinging your controller when equipped on melee survivors.

### 2.5.1
- The pickup notification and the spectator label have been moved up above the central health bar to prevent them from being hidden behind status icons.
- Fixed a bug that caused some setting sliders to parse decimals incorrectly when using certain languages.

### 2.5.2
- Fixed a bug that caused the credits to appear during the escape cutscene.
- Fixed a bug that prevented the LIV plugin from being correctly copied into the game directory during the patching process.

### 2.6.0
- The UI navigation system has been revamped to use your dominant hand as a pointer instead of using gamepad controls.
- The player and character height can now also scale the camera view with the roomscale tracking space setting disabled.
- The mouse can no longer move the camera when using motion controls.
- Fixed a bug that prevented the default Vive Cosmos controller binds from loading correctly which made the Vive Cosmos controllers unusable.
- Fixed a bug that would sometimes break inputs with the Oculus Mode setting enabled.
- Fixed a bug that caused the SteamVR overlay to pause the game which created sync issues in multiplayer.
- Fixed a bug that caused corruption of some menu backgrounds when using LIV XR capture.
- Fixed a bug that caused the hand tracking to be slightly inaccurate when using SteamVR.
- Possibly fixed a bug that prevented the spectator screen from appearing in some occasions.

### 2.6.1
- Fixed a bug that prevented the spectator screen from appearing.
- The spectator screen will now always render on the foreground.
- Fixed a bug that broke some hand animations after using the command or scrapper panel.
- Fixed a bug that prevented the kick message from displaying correctly.
- Fixed a bug that made the buttons in the lobby details panel unclickable.
- Fixed a bug that broke all inputs when no profile has been created.

### 2.6.2
- Fixed a bug that caused some menus to have unreachable buttons near the edges when playing with a lower resolution per eye.
- Fixed a bug that prevented the watch HUD from appearing or disappearing while paused.
- Fixed a bug that caused the spectator camera to have the wrong field of view.
- Fixed a bug that caused Bandit's revolver animation to cancel by mistake when other Bandit players in the lobby would start sprinting.

### 2.6.3
- The momentum direction is now controlled by the non-dominant hand when using Loader's grapple hook.
- A warning now appears when the game window loses focus.
- Fixed a bug that prevented the use of the triggers or the X button to interact with menus on Oculus Touch controllers when Oculus mode is enabled.
- Fixed a bug that showed the wrong control glyphs when playing with Vive or WMR controllers.

### 2.6.4
- VR settings that depend on other settings will no longer get forcibly switched. For example:
	- Turning off first person deactivates motion controls, but the motion controls setting will stay intact so it stays enabled when re-enabling first person.
	- Turning off motion controls means the wrist and watch HUDs cannot be used, but the settings will now stay enabled.
- Fixed a bug that broke controller inputs when the controllers are no longer detected with Oculus mode on.

### 2.6.5
- Fixed compatibility with the Survivor of the Void update.
- Players spectating a VR player should now properly see towards the direction they're looking at.
- The smooth HUD now follows the camera slightly faster.
- The top and bottom faded black bars in the character selection menu have been removed.
- Fixed a bug that prevented SteamVR from initializing the first time the mod was loaded.

### 2.6.6
- Fixed a bug that would crash the game if attempting to start a run with snap turn disabled.
- Fixed a harmless bug that would spam the console with errors.

### 2.6.7
- Depth of field effects have been completely removed in all locations.
- The round cursor is now hidden when playing with a gamepad.
- Fixed a bug that caused the camera to tilt in some situations.
- Fixed a bug that caused the spectating camera to point towards the wrong direction.
- Fixed a bug that caused the vanilla aim-assist to reduce smooth turn speed when looking towards an enemy.
- Fixed a bug that caused motion controllers to rumble when not using them.
- Fixed a harmless bug that would spam the console with errors in the main menu.

### 2.7.0
- Railgunner and Void Fiend are now fully VR supported.
- Three settings have been added for Railgunner:
	- "Railgunner: Weapon grip snap angle".
	- "Railgunner: Zoom multiplier".
	- "Railgunner: Hide ray while scoping".
- Added aim stabilisation to improve overall accuracy.
	- Rotational stabilisation is applied everywhere, but positional stabilisation is also applied when holding two-handed weapons.
	- The amount of stabilisation can be changed with the new "Aim stabiliser amount" setting.
- Sprinting and scoping no longer affect the smooth turn speed.
- The shield generator, plasma shrimp and shaped glass overlay effects on the hands are now smaller and more transparent.
- Fixed a bug that made the melee swing threshold settings affect only one hand on Loader and Acrid on future runs after changing it.
- Possibly fixed a bug that sometimes prevented some animations from playing.
- Possibly fixed a bug that sometimes prevented binding overrides from applying correctly on Loader.
- Fixed more bugs spamming errors in the console.

### 2.7.1
- Fixed a bug that broke the UI pointer when no profile was loaded.
- Fixed a bug that prevented players from controlling their vertical flying direction with Milky Chrysalis when using controller direction for movement.
- Fixed a bug that broke the command/scrapper UI when closing it.

### 2.8.0
- Added custom skins support through the VRAPI.
- Added alternate models on Bandit's and Void Fiend's mastery skin.
- The FixPluginTypesSerialization mod is now a dependency in order to support custom skins.
- Aim rays for equipments now only appear when the equipment is off cooldown.
- Fixed a bug that prevented the game report screen from appearing after the credits.
- Fixed a bug that prevented the spectator camera from rotating vertically when the "Locked camera pitch" setting was on.
- Fixed a bug that prevented the equipment aim ray or heresy item aim ray from appearing when first loading into a stage.
- Fixed a bug that prevented the difficulty icon, stage count, enemy level and simulacrum waves from appearing on the right watch HUD.

### 2.8.1
- Replaced the "Player height in meters" setting with a simpler "Height multiplier" setting. Increasing the new slider will make you feel taller.
- Replaced the "Roomscale tracking space" setting with a "Seated mode" setting to better communicate its functionality.
- Fixed a bug that forced the physics update rate to match the headset's refresh rate when using SteamVR which impacted performance.

### 2.8.2
- Removed FixPluginTypesSerialization dependency as it is now included with BepInEx.
- Railgunner's scope crosshair texture is no longer affected by graphic settings.
- Fixed some animations on Bandit's revolver when using the Bandit Tweaks mod.

### 2.9.0
- Added haptic feedback for Bhaptics and Shockwave suits.
	- Features directional feedback and other stimulating patterns.
	- A new setting has been added to select which haptic suit is being used. Scroll to the bottom of the VR settings menu to select your suit then restart the game.
- Fixed a bug where kick messages couldn't be interacted with in the main menu.

### 2.9.1
- Fixed the VR patching system that was incomplete in the last update.

### 2.9.2
- Fixed a bug that caused tracking issues with Reverb G2 controllers.
- Reduced default swing speed threshold on all melee survivors.