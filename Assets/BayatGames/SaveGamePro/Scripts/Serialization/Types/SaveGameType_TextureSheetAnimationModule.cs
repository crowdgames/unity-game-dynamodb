using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type TextureSheetAnimationModule serialization implementation.
    /// </summary>
    public class SaveGameType_TextureSheetAnimationModule : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.ParticleSystem.TextureSheetAnimationModule);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.ParticleSystem.TextureSheetAnimationModule textureSheetAnimationModule = (UnityEngine.ParticleSystem.TextureSheetAnimationModule)value;
            writer.WriteProperty("enabled", textureSheetAnimationModule.enabled);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "mode", textureSheetAnimationModule.mode );
#endif
            writer.WriteProperty("numTilesX", textureSheetAnimationModule.numTilesX);
            writer.WriteProperty("numTilesY", textureSheetAnimationModule.numTilesY);
            writer.WriteProperty("animation", textureSheetAnimationModule.animation);
            writer.WriteProperty("useRandomRow", textureSheetAnimationModule.useRandomRow);
            writer.WriteProperty("frameOverTime", textureSheetAnimationModule.frameOverTime);
            writer.WriteProperty("frameOverTimeMultiplier", textureSheetAnimationModule.frameOverTimeMultiplier);
            writer.WriteProperty("startFrame", textureSheetAnimationModule.startFrame);
            writer.WriteProperty("startFrameMultiplier", textureSheetAnimationModule.startFrameMultiplier);
            writer.WriteProperty("cycleCount", textureSheetAnimationModule.cycleCount);
            writer.WriteProperty("rowIndex", textureSheetAnimationModule.rowIndex);
            writer.WriteProperty("uvChannelMask", textureSheetAnimationModule.uvChannelMask);
            writer.WriteProperty("flipU", textureSheetAnimationModule.flipU);
            writer.WriteProperty("flipV", textureSheetAnimationModule.flipV);

        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.ParticleSystem.TextureSheetAnimationModule textureSheetAnimationModule = new UnityEngine.ParticleSystem.TextureSheetAnimationModule();
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "enabled":
                        textureSheetAnimationModule.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "mode":
#if UNITY_2017_1_OR_NEWER
                        textureSheetAnimationModule.mode = reader.ReadProperty<UnityEngine.ParticleSystemAnimationMode>();
#endif
                        break;
                    case "numTilesX":
                        textureSheetAnimationModule.numTilesX = reader.ReadProperty<System.Int32>();
                        break;
                    case "numTilesY":
                        textureSheetAnimationModule.numTilesY = reader.ReadProperty<System.Int32>();
                        break;
                    case "animation":
                        textureSheetAnimationModule.animation = reader.ReadProperty<UnityEngine.ParticleSystemAnimationType>();
                        break;
                    case "useRandomRow":
                        textureSheetAnimationModule.useRandomRow = reader.ReadProperty<System.Boolean>();
                        break;
                    case "frameOverTime":
                        textureSheetAnimationModule.frameOverTime = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "frameOverTimeMultiplier":
                        textureSheetAnimationModule.frameOverTimeMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startFrame":
                        textureSheetAnimationModule.startFrame = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "startFrameMultiplier":
                        textureSheetAnimationModule.startFrameMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "cycleCount":
                        textureSheetAnimationModule.cycleCount = reader.ReadProperty<System.Int32>();
                        break;
                    case "rowIndex":
                        textureSheetAnimationModule.rowIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "uvChannelMask":
                        textureSheetAnimationModule.uvChannelMask = reader.ReadProperty<UnityEngine.Rendering.UVChannelFlags>();
                        break;
                    case "flipU":
                        textureSheetAnimationModule.flipU = reader.ReadProperty<System.Single>();
                        break;
                    case "flipV":
                        textureSheetAnimationModule.flipV = reader.ReadProperty<System.Single>();
                        break;
                }
            }
            return textureSheetAnimationModule;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            base.ReadInto(value, reader);
        }

    }

}