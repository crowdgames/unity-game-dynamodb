using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type TrailModule serialization implementation.
    /// </summary>
    public class SaveGameType_TrailModule : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.ParticleSystem.TrailModule);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.ParticleSystem.TrailModule trailModule = (UnityEngine.ParticleSystem.TrailModule)value;
            writer.WriteProperty("enabled", trailModule.enabled);
            writer.WriteProperty("ratio", trailModule.ratio);
            writer.WriteProperty("lifetime", trailModule.lifetime);
            writer.WriteProperty("lifetimeMultiplier", trailModule.lifetimeMultiplier);
            writer.WriteProperty("minVertexDistance", trailModule.minVertexDistance);
            writer.WriteProperty("textureMode", trailModule.textureMode);
            writer.WriteProperty("worldSpace", trailModule.worldSpace);
            writer.WriteProperty("dieWithParticles", trailModule.dieWithParticles);
            writer.WriteProperty("sizeAffectsWidth", trailModule.sizeAffectsWidth);
            writer.WriteProperty("sizeAffectsLifetime", trailModule.sizeAffectsLifetime);
            writer.WriteProperty("inheritParticleColor", trailModule.inheritParticleColor);
            writer.WriteProperty("colorOverLifetime", trailModule.colorOverLifetime);
            writer.WriteProperty("widthOverTrail", trailModule.widthOverTrail);
            writer.WriteProperty("widthOverTrailMultiplier", trailModule.widthOverTrailMultiplier);
            writer.WriteProperty("colorOverTrail", trailModule.colorOverTrail);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty ( "generateLightingData", trailModule.generateLightingData );
#endif
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.ParticleSystem.TrailModule trailModule = new UnityEngine.ParticleSystem.TrailModule();
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "enabled":
                        trailModule.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "ratio":
                        trailModule.ratio = reader.ReadProperty<System.Single>();
                        break;
                    case "lifetime":
                        trailModule.lifetime = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "lifetimeMultiplier":
                        trailModule.lifetimeMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "minVertexDistance":
                        trailModule.minVertexDistance = reader.ReadProperty<System.Single>();
                        break;
                    case "textureMode":
                        trailModule.textureMode = reader.ReadProperty<UnityEngine.ParticleSystemTrailTextureMode>();
                        break;
                    case "worldSpace":
                        trailModule.worldSpace = reader.ReadProperty<System.Boolean>();
                        break;
                    case "dieWithParticles":
                        trailModule.dieWithParticles = reader.ReadProperty<System.Boolean>();
                        break;
                    case "sizeAffectsWidth":
                        trailModule.sizeAffectsWidth = reader.ReadProperty<System.Boolean>();
                        break;
                    case "sizeAffectsLifetime":
                        trailModule.sizeAffectsLifetime = reader.ReadProperty<System.Boolean>();
                        break;
                    case "inheritParticleColor":
                        trailModule.inheritParticleColor = reader.ReadProperty<System.Boolean>();
                        break;
                    case "colorOverLifetime":
                        trailModule.colorOverLifetime = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxGradient>();
                        break;
                    case "widthOverTrail":
                        trailModule.widthOverTrail = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "widthOverTrailMultiplier":
                        trailModule.widthOverTrailMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "colorOverTrail":
                        trailModule.colorOverTrail = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxGradient>();
                        break;
                    case "generateLightingData":
#if UNITY_2017_1_OR_NEWER
                        trailModule.generateLightingData = reader.ReadProperty<System.Boolean>();
#else
                        reader.ReadProperty<System.Boolean>();
#endif
                        break;
                }
            }
            return trailModule;
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