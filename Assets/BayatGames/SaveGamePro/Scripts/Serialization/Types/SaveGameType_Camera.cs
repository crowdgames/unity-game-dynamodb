using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type Camera serialization implementation.
    /// </summary>
    public class SaveGameType_Camera : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Camera);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Camera camera = (UnityEngine.Camera)value;
            writer.WriteProperty("fieldOfView", camera.fieldOfView);
            writer.WriteProperty("nearClipPlane", camera.nearClipPlane);
            writer.WriteProperty("farClipPlane", camera.farClipPlane);
            writer.WriteProperty("renderingPath", camera.renderingPath);
            writer.WriteProperty("allowHDR", camera.allowHDR);
            writer.WriteProperty("forceIntoRenderTexture", camera.forceIntoRenderTexture);
            writer.WriteProperty("allowMSAA", camera.allowMSAA);
            writer.WriteProperty("orthographicSize", camera.orthographicSize);
            writer.WriteProperty("orthographic", camera.orthographic);
            writer.WriteProperty("opaqueSortMode", camera.opaqueSortMode);
            writer.WriteProperty("transparencySortMode", camera.transparencySortMode);
            writer.WriteProperty("transparencySortAxis", camera.transparencySortAxis);
            writer.WriteProperty("depth", camera.depth);
            writer.WriteProperty("aspect", camera.aspect);
            writer.WriteProperty("cullingMask", camera.cullingMask);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "scene", camera.scene );
#endif
            writer.WriteProperty("eventMask", camera.eventMask);
            writer.WriteProperty("backgroundColor", camera.backgroundColor);
            writer.WriteProperty("rect", camera.rect);
            writer.WriteProperty("pixelRect", camera.pixelRect);
            writer.WriteProperty("targetTexture", camera.targetTexture);
            writer.WriteProperty("worldToCameraMatrix", camera.worldToCameraMatrix);
            writer.WriteProperty("projectionMatrix", camera.projectionMatrix);
            writer.WriteProperty("nonJitteredProjectionMatrix", camera.nonJitteredProjectionMatrix);
            writer.WriteProperty(
                "useJitteredProjectionMatrixForTransparentRendering",
                camera.useJitteredProjectionMatrixForTransparentRendering);
            writer.WriteProperty("clearFlags", camera.clearFlags);
            writer.WriteProperty("stereoSeparation", camera.stereoSeparation);
            writer.WriteProperty("stereoConvergence", camera.stereoConvergence);
            writer.WriteProperty("cameraType", camera.cameraType);
            writer.WriteProperty("stereoTargetEye", camera.stereoTargetEye);
            writer.WriteProperty("targetDisplay", camera.targetDisplay);
            writer.WriteProperty("useOcclusionCulling", camera.useOcclusionCulling);
            writer.WriteProperty("cullingMatrix", camera.cullingMatrix);
            writer.WriteProperty("layerCullDistances", camera.layerCullDistances);
            writer.WriteProperty("layerCullSpherical", camera.layerCullSpherical);
            writer.WriteProperty("depthTextureMode", camera.depthTextureMode);
            writer.WriteProperty("clearStencilAfterLightingPass", camera.clearStencilAfterLightingPass);
            writer.WriteProperty("enabled", camera.enabled);
            writer.WriteProperty("tag", camera.tag);
            writer.WriteProperty("name", camera.name);
            writer.WriteProperty("hideFlags", camera.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.Camera camera = SaveGameType.CreateComponent<UnityEngine.Camera>();
            ReadInto(camera, reader);
            return camera;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.Camera camera = (UnityEngine.Camera)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "fieldOfView":
                        camera.fieldOfView = reader.ReadProperty<System.Single>();
                        break;
                    case "nearClipPlane":
                        camera.nearClipPlane = reader.ReadProperty<System.Single>();
                        break;
                    case "farClipPlane":
                        camera.farClipPlane = reader.ReadProperty<System.Single>();
                        break;
                    case "renderingPath":
                        camera.renderingPath = reader.ReadProperty<UnityEngine.RenderingPath>();
                        break;
                    case "allowHDR":
                        camera.allowHDR = reader.ReadProperty<System.Boolean>();
                        break;
                    case "forceIntoRenderTexture":
                        camera.forceIntoRenderTexture = reader.ReadProperty<System.Boolean>();
                        break;
                    case "allowMSAA":
                        camera.allowMSAA = reader.ReadProperty<System.Boolean>();
                        break;
                    case "orthographicSize":
                        camera.orthographicSize = reader.ReadProperty<System.Single>();
                        break;
                    case "orthographic":
                        camera.orthographic = reader.ReadProperty<System.Boolean>();
                        break;
                    case "opaqueSortMode":
                        camera.opaqueSortMode = reader.ReadProperty<UnityEngine.Rendering.OpaqueSortMode>();
                        break;
                    case "transparencySortMode":
                        camera.transparencySortMode = reader.ReadProperty<UnityEngine.TransparencySortMode>();
                        break;
                    case "transparencySortAxis":
                        camera.transparencySortAxis = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "depth":
                        camera.depth = reader.ReadProperty<System.Single>();
                        break;
                    case "aspect":
                        camera.aspect = reader.ReadProperty<System.Single>();
                        break;
                    case "cullingMask":
                        camera.cullingMask = reader.ReadProperty<System.Int32>();
                        break;
                    case "scene":
#if UNITY_2017_1_OR_NEWER
                        camera.scene = reader.ReadProperty<UnityEngine.SceneManagement.Scene>();
#else
                        reader.ReadProperty<UnityEngine.SceneManagement.Scene>();
#endif
                        break;
                    case "eventMask":
                        camera.eventMask = reader.ReadProperty<System.Int32>();
                        break;
                    case "backgroundColor":
                        camera.backgroundColor = reader.ReadProperty<UnityEngine.Color>();
                        break;
                    case "rect":
                        camera.rect = reader.ReadProperty<UnityEngine.Rect>();
                        break;
                    case "pixelRect":
                        camera.pixelRect = reader.ReadProperty<UnityEngine.Rect>();
                        break;
                    case "targetTexture":
                        if (camera.targetTexture == null)
                        {
                            camera.targetTexture = reader.ReadProperty<UnityEngine.RenderTexture>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.RenderTexture>(camera.targetTexture);
                        }
                        break;
                    case "worldToCameraMatrix":
                        camera.worldToCameraMatrix = reader.ReadProperty<UnityEngine.Matrix4x4>();
                        break;
                    case "projectionMatrix":
                        camera.projectionMatrix = reader.ReadProperty<UnityEngine.Matrix4x4>();
                        break;
                    case "nonJitteredProjectionMatrix":
                        camera.nonJitteredProjectionMatrix = reader.ReadProperty<UnityEngine.Matrix4x4>();
                        break;
                    case "useJitteredProjectionMatrixForTransparentRendering":
                        camera.useJitteredProjectionMatrixForTransparentRendering = reader.ReadProperty<System.Boolean>();
                        break;
                    case "clearFlags":
                        camera.clearFlags = reader.ReadProperty<UnityEngine.CameraClearFlags>();
                        break;
                    case "stereoSeparation":
                        camera.stereoSeparation = reader.ReadProperty<System.Single>();
                        break;
                    case "stereoConvergence":
                        camera.stereoConvergence = reader.ReadProperty<System.Single>();
                        break;
                    case "cameraType":
                        camera.cameraType = reader.ReadProperty<UnityEngine.CameraType>();
                        break;
                    case "stereoTargetEye":
                        camera.stereoTargetEye = reader.ReadProperty<UnityEngine.StereoTargetEyeMask>();
                        break;
                    case "targetDisplay":
                        camera.targetDisplay = reader.ReadProperty<System.Int32>();
                        break;
                    case "useOcclusionCulling":
                        camera.useOcclusionCulling = reader.ReadProperty<System.Boolean>();
                        break;
                    case "cullingMatrix":
                        camera.cullingMatrix = reader.ReadProperty<UnityEngine.Matrix4x4>();
                        break;
                    case "layerCullDistances":
                        camera.layerCullDistances = reader.ReadProperty<System.Single[]>();
                        break;
                    case "layerCullSpherical":
                        camera.layerCullSpherical = reader.ReadProperty<System.Boolean>();
                        break;
                    case "depthTextureMode":
                        camera.depthTextureMode = reader.ReadProperty<UnityEngine.DepthTextureMode>();
                        break;
                    case "clearStencilAfterLightingPass":
                        camera.clearStencilAfterLightingPass = reader.ReadProperty<System.Boolean>();
                        break;
                    case "enabled":
                        camera.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "tag":
                        camera.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        camera.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        camera.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}