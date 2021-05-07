﻿using RoR2;
using RoR2.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRMod
{
    internal static class UIFixes
    {
        private static readonly Vector3 menuPosition = new Vector3(0, 0, 15);
        private static readonly Vector3 characterSelectPosition = new Vector3(0, 0, 5);

        private static readonly Vector3 menuScale = new Vector3(0.01f, 0.01f, 0.01f);
        private static readonly Vector3 characterSelectScale = new Vector3(0.005f, 0.005f, 0.005f);

        private static readonly Vector2 menuPivot = new Vector2(0.5f, 0.5f);

        private static readonly Vector2 menuResolution = new Vector2(1500, 1000);
        private static readonly Vector2 hdResolution = new Vector2(1920, 1080);

        private static Camera cachedUICam;

        private static Vector3 camRotation = Vector3.zero;

        private static List<Type> vignetteAbilities = new List<Type>()
        {
            typeof(EntityStates.Commando.DodgeState),
            typeof(EntityStates.Commando.SlideState),
            typeof(EntityStates.Huntress.BlinkState),
            typeof(EntityStates.Huntress.MiniBlinkState),
            typeof(EntityStates.Toolbot.ToolbotDash),
            typeof(EntityStates.Mage.FlyUpState),
            typeof(EntityStates.Merc.Assaulter2),
            typeof(EntityStates.Merc.EvisDash),
            typeof(EntityStates.Merc.FocusedAssaultDash),
            typeof(EntityStates.Merc.EvisDash),
            typeof(EntityStates.Loader.SwingChargedFist),
            typeof(EntityStates.Loader.SwingZapFist),
            typeof(EntityStates.Loader.GroundSlam),
            typeof(EntityStates.Croco.Leap),
            typeof(EntityStates.Croco.ChainableLeap)
        };

        internal static void Init()
        {
            On.RoR2.UI.HUD.Awake += AdjustHUD;

            On.RoR2.UI.CombatHealthBarViewer.UpdateAllHealthbarPositions += UpdateAllHealthBarPositionsVR;

            On.RoR2.Indicator.PositionForUI += PositionForUIOverride;
            On.RoR2.PositionIndicator.UpdatePositions += UpdatePositionsOverride;

            On.RoR2.UI.MainMenu.BaseMainMenuScreen.OnEnter += (orig, self, controller) =>
            {
                orig(self, controller);
                SetRenderMode(self.gameObject, menuResolution, menuPosition, menuScale);
            };
            On.RoR2.UI.LogBook.LogBookController.Start += (orig, self) =>
            {
                orig(self);
                SetRenderMode(self.gameObject, hdResolution, menuPosition, menuScale);
            };
            On.RoR2.UI.EclipseRunScreenController.Start += (orig, self) =>
            {
                orig(self);
                SetRenderMode(self.gameObject, hdResolution, menuPosition, menuScale);
            };
            On.RoR2.UI.CharacterSelectController.Start += (orig, self) =>
            {
                orig(self);
                SetRenderMode(self.gameObject, hdResolution, characterSelectPosition, characterSelectScale);
            };
            On.RoR2.UI.PauseScreenController.OnEnable += (orig, self) =>
            {
                orig(self);
                if (!cachedUICam)
                {
                    GameObject cameraObject = Camera.main.transform.parent.gameObject;
                    cachedUICam = cameraObject.name.Contains("Wrapper") ? cameraObject.GetComponent<VRCameraWrapper>().cameraRigController.uiCam : cameraObject.GetComponent<CameraRigController>().uiCam;
                }
                camRotation = new Vector3(0, cachedUICam.transform.eulerAngles.y, 0);
                SetRenderMode(self.gameObject, hdResolution, menuPosition, menuScale, true);
            };
            On.RoR2.UI.SimpleDialogBox.Start += (orig, self) =>
            {
                orig(self);
                SetRenderMode(self.transform.root.gameObject, hdResolution, menuPosition, menuScale, PauseManager.isPaused);
            };
            On.RoR2.UI.GameEndReportPanelController.Awake += (orig, self) =>
            {
                orig(self);
                if (!cachedUICam)
                {
                    GameObject cameraObject = Camera.main.transform.parent.gameObject;
                    cachedUICam = cameraObject.name.Contains("Wrapper") ? cameraObject.GetComponent<VRCameraWrapper>().cameraRigController.uiCam : cameraObject.GetComponent<CameraRigController>().uiCam;
                }
                camRotation = new Vector3(0, cachedUICam.transform.eulerAngles.y, 0);
                SetRenderMode(self.gameObject, hdResolution, menuPosition, menuScale, true);
            };
            On.RoR2.SplashScreenController.Start += (orig, self) =>
            {
                orig(self);
                Camera.main.clearFlags = CameraClearFlags.SolidColor;
                Camera.main.backgroundColor = Color.black;
                GameObject splash = GameObject.Find("SpashScreenCanvas");
                if (splash)
                    SetRenderMode(splash, hdResolution, menuPosition, menuScale);
            };

            On.RoR2.GameOverController.Awake += (orig, self) =>
            {
                orig(self);
                self.gameEndReportPanelPrefab.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            };
        }

        private static void UpdatePositionsOverride(On.RoR2.PositionIndicator.orig_UpdatePositions orig, UICamera uiCamera)
        {
            orig(uiCamera);
            if (!HUD.cvHudEnable.value || !PositionIndicator.cvPositionIndicatorsEnable.value)
                return;

            foreach (PositionIndicator indicator in PositionIndicator.instancesList)
            {
                Vector3 position = indicator.targetTransform ? indicator.targetTransform.position : indicator.defaultPosition;
                position.y += indicator.yOffset;

                bool isPingIndicator = PingIndicator.instancesList.Exists((x) => x.positionIndicator == indicator);

                Transform rigTransform = VRCameraWrapper.instance ? VRCameraWrapper.instance.transform : uiCamera.cameraRigController.transform;
                indicator.transform.position = rigTransform.InverseTransformDirection(position - rigTransform.position);
                indicator.transform.localScale = (isPingIndicator ? 1: 0.2f) * Vector3.Distance(rigTransform.position, position) * Vector3.one;
            }
        }

        private static void PositionForUIOverride(On.RoR2.Indicator.orig_PositionForUI orig, Indicator self, Camera sceneCamera, Camera uiCamera)
        {
            if (self.targetTransform)
            {
                Vector3 position = self.targetTransform.position;
                
                Vector3 vector = sceneCamera.transform.parent.InverseTransformDirection(position - sceneCamera.transform.parent.position);
                if (self.visualizerTransform != null)
                {
                    self.visualizerTransform.position = vector;
                    self.visualizerTransform.rotation = Quaternion.LookRotation((vector - uiCamera.transform.position).normalized);
                    self.visualizerTransform.localScale = (self is EntityStates.Engi.EngiMissilePainter.Paint.EngiMissileIndicator ? 1 : 0.1f) * Vector3.Distance(sceneCamera.transform.position, position) * Vector3.one;
                }
            }
        }

        private static void SetRenderMode(GameObject uiObject, Vector2 resolution, Vector3 positionOffset, Vector3 scale, bool followRotation = false)
        {
            if (!cachedUICam)
            {
                GameObject cameraObject = Camera.main.transform.parent.gameObject;
                cachedUICam = cameraObject.name.Contains("Wrapper") ? cameraObject.GetComponent<VRCameraWrapper>().cameraRigController.uiCam : cameraObject.GetComponent<CameraRigController>().uiCam;
            }

            Canvas canvas = uiObject.GetComponent<Canvas>();

            if (canvas.renderMode != RenderMode.WorldSpace)
            {
                if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
                    canvas.renderMode = RenderMode.ScreenSpaceOverlay;

                canvas.renderMode = RenderMode.WorldSpace;
                canvas.worldCamera = cachedUICam;

                Vector3 offset = positionOffset;

                if (followRotation)
                {
                    offset = Quaternion.Euler(camRotation) * offset;

                    if (uiObject.transform.root != uiObject.transform)
                        uiObject.transform.parent.rotation = Quaternion.Euler(uiObject.transform.parent.eulerAngles + camRotation);
                    else
                        uiObject.transform.rotation = Quaternion.Euler(uiObject.transform.eulerAngles + camRotation);

                }

                if (uiObject.transform.parent)
                    uiObject.transform.parent.position = cachedUICam.transform.position + offset;

                uiObject.transform.position = cachedUICam.transform.position + offset;
                uiObject.transform.localScale = scale;

                RectTransform rect = uiObject.GetComponent<RectTransform>();
                if (rect)
                {
                    rect.pivot = menuPivot;
                    rect.sizeDelta = resolution;
                }
            }
        }

        private static void AdjustHUD(On.RoR2.UI.HUD.orig_Awake orig, RoR2.UI.HUD self)
        {
            orig(self);

            if (ModConfig.UseMotionControls.Value)
            {
                CrosshairManager crosshairManager = self.GetComponent<CrosshairManager>();

                if (crosshairManager)
                {
                    crosshairManager.container.gameObject.SetActive(false);
                    crosshairManager.hitmarker.gameObject.SetActive(false);
                }
            }

            CanvasScaler scaler = self.canvas.gameObject.AddComponent<CanvasScaler>();
            scaler.scaleFactor = ModConfig.UIScale.Value;

            Transform[] uiElements = new Transform[] {
                self.mainUIPanel.transform.Find("SpringCanvas"),
                self.mainContainer.transform.Find("NotificationArea"),
                self.mainContainer.transform.Find("MapNameCluster")
            };

            foreach (Transform uiElement in uiElements)
            {
                RectTransform rect = uiElement.GetComponent<RectTransform>();
                rect.anchorMin = ModConfig.AnchorMin;
                rect.anchorMax = ModConfig.AnchorMax;
            }
        }

        private static void UpdateAllHealthBarPositionsVR(On.RoR2.UI.CombatHealthBarViewer.orig_UpdateAllHealthbarPositions orig, RoR2.UI.CombatHealthBarViewer self, Camera sceneCam, Camera uiCam)
        {
            foreach (CombatHealthBarViewer.HealthBarInfo healthBarInfo in self.victimToHealthBarInfo.Values)
            {
                Vector3 position = healthBarInfo.sourceTransform.position;
                position.y += healthBarInfo.verticalOffset;
                Vector3 vector = sceneCam.WorldToScreenPoint(position);
                Vector3 position2 = uiCam.ScreenToWorldPoint(vector);
                healthBarInfo.healthBarRootObjectTransform.position = position2;
                healthBarInfo.healthBarRootObjectTransform.localScale = 0.1f * Vector3.Distance(sceneCam.transform.position, position) * Vector3.one;
            }
        }
    }
}
