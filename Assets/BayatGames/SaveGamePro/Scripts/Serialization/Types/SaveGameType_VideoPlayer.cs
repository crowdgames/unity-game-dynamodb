using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

#if !UNITY_SAMSUNGTV && !UNITY_SWITCH && !UNITY_PSP2

    /// <summary>
    /// Save Game Type VideoPlayer serialization implementation.
    /// </summary>
    public class SaveGameType_VideoPlayer : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Video.VideoPlayer);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Video.VideoPlayer videoPlayer = (UnityEngine.Video.VideoPlayer)value;
            writer.WriteProperty("source", videoPlayer.source);
            writer.WriteProperty("url", videoPlayer.url);
            writer.WriteProperty("clip", videoPlayer.clip);
            writer.WriteProperty("renderMode", videoPlayer.renderMode);
            writer.WriteProperty("targetCamera", videoPlayer.targetCamera);
            writer.WriteProperty("targetTexture", videoPlayer.targetTexture);
            writer.WriteProperty("targetMaterialRenderer", videoPlayer.targetMaterialRenderer);
            writer.WriteProperty("targetMaterialProperty", videoPlayer.targetMaterialProperty);
            writer.WriteProperty("aspectRatio", videoPlayer.aspectRatio);
            writer.WriteProperty("targetCameraAlpha", videoPlayer.targetCameraAlpha);
            writer.WriteProperty("waitForFirstFrame", videoPlayer.waitForFirstFrame);
            writer.WriteProperty("playOnAwake", videoPlayer.playOnAwake);
            writer.WriteProperty("time", videoPlayer.time);
            writer.WriteProperty("frame", videoPlayer.frame);
            writer.WriteProperty("playbackSpeed", videoPlayer.playbackSpeed);
            writer.WriteProperty("isLooping", videoPlayer.isLooping);
            writer.WriteProperty("timeSource", videoPlayer.timeSource);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty("timeReference", videoPlayer.timeReference);
            writer.WriteProperty("externalReferenceTime", videoPlayer.externalReferenceTime);
#endif
            writer.WriteProperty("skipOnDrop", videoPlayer.skipOnDrop);
            writer.WriteProperty("controlledAudioTrackCount", videoPlayer.controlledAudioTrackCount);
            writer.WriteProperty("audioOutputMode", videoPlayer.audioOutputMode);
            writer.WriteProperty("sendFrameReadyEvents", videoPlayer.sendFrameReadyEvents);
            writer.WriteProperty("enabled", videoPlayer.enabled);
            writer.WriteProperty("tag", videoPlayer.tag);
            writer.WriteProperty("name", videoPlayer.name);
            writer.WriteProperty("hideFlags", videoPlayer.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.Video.VideoPlayer videoPlayer = SaveGameType.CreateComponent<UnityEngine.Video.VideoPlayer>();
            ReadInto(videoPlayer, reader);
            return videoPlayer;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.Video.VideoPlayer videoPlayer = (UnityEngine.Video.VideoPlayer)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "source":
                        videoPlayer.source = reader.ReadProperty<UnityEngine.Video.VideoSource>();
                        break;
                    case "url":
                        videoPlayer.url = reader.ReadProperty<System.String>();
                        break;
                    case "clip":
                        if (videoPlayer.clip == null)
                        {
                            videoPlayer.clip = reader.ReadProperty<UnityEngine.Video.VideoClip>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Video.VideoClip>(videoPlayer.clip);
                        }
                        break;
                    case "renderMode":
                        videoPlayer.renderMode = reader.ReadProperty<UnityEngine.Video.VideoRenderMode>();
                        break;
                    case "targetCamera":
                        if (videoPlayer.targetCamera == null)
                        {
                            videoPlayer.targetCamera = reader.ReadProperty<UnityEngine.Camera>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Camera>(videoPlayer.targetCamera);
                        }
                        break;
                    case "targetTexture":
                        if (videoPlayer.targetTexture == null)
                        {
                            videoPlayer.targetTexture = reader.ReadProperty<UnityEngine.RenderTexture>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.RenderTexture>(videoPlayer.targetTexture);
                        }
                        break;
                    case "targetMaterialRenderer":
                        if (videoPlayer.targetMaterialRenderer == null)
                        {
                            videoPlayer.targetMaterialRenderer = reader.ReadProperty<UnityEngine.Renderer>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Renderer>(videoPlayer.targetMaterialRenderer);
                        }
                        break;
                    case "targetMaterialProperty":
                        videoPlayer.targetMaterialProperty = reader.ReadProperty<System.String>();
                        break;
                    case "aspectRatio":
                        videoPlayer.aspectRatio = reader.ReadProperty<UnityEngine.Video.VideoAspectRatio>();
                        break;
                    case "targetCameraAlpha":
                        videoPlayer.targetCameraAlpha = reader.ReadProperty<System.Single>();
                        break;
                    case "waitForFirstFrame":
                        videoPlayer.waitForFirstFrame = reader.ReadProperty<System.Boolean>();
                        break;
                    case "playOnAwake":
                        videoPlayer.playOnAwake = reader.ReadProperty<System.Boolean>();
                        break;
                    case "time":
                        videoPlayer.time = reader.ReadProperty<System.Double>();
                        break;
                    case "frame":
                        videoPlayer.frame = reader.ReadProperty<System.Int64>();
                        break;
                    case "playbackSpeed":
                        videoPlayer.playbackSpeed = reader.ReadProperty<System.Single>();
                        break;
                    case "isLooping":
                        videoPlayer.isLooping = reader.ReadProperty<System.Boolean>();
                        break;
                    case "timeSource":
                        videoPlayer.timeSource = reader.ReadProperty<UnityEngine.Video.VideoTimeSource>();
                        break;
                    case "timeReference":
#if UNITY_2017_1_OR_NEWER
                        videoPlayer.timeReference = reader.ReadProperty<UnityEngine.Video.VideoTimeReference>();
#endif
                        break;
                    case "externalReferenceTime":
#if UNITY_2017_1_OR_NEWER
                        videoPlayer.externalReferenceTime = reader.ReadProperty<System.Double>();
#else
                        reader.ReadProperty<System.Double>();
#endif
                        break;
                    case "skipOnDrop":
                        videoPlayer.skipOnDrop = reader.ReadProperty<System.Boolean>();
                        break;
                    case "controlledAudioTrackCount":
                        videoPlayer.controlledAudioTrackCount = reader.ReadProperty<System.UInt16>();
                        break;
                    case "audioOutputMode":
                        videoPlayer.audioOutputMode = reader.ReadProperty<UnityEngine.Video.VideoAudioOutputMode>();
                        break;
                    case "sendFrameReadyEvents":
                        videoPlayer.sendFrameReadyEvents = reader.ReadProperty<System.Boolean>();
                        break;
                    case "enabled":
                        videoPlayer.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "tag":
                        videoPlayer.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        videoPlayer.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        videoPlayer.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

#endif

}