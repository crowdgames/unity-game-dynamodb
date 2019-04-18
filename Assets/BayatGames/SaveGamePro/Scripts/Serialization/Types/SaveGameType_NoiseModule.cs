using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type NoiseModule serialization implementation.
    /// </summary>
    public class SaveGameType_NoiseModule : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.ParticleSystem.NoiseModule);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.ParticleSystem.NoiseModule noiseModule = (UnityEngine.ParticleSystem.NoiseModule)value;
            writer.WriteProperty("enabled", noiseModule.enabled);
            writer.WriteProperty("separateAxes", noiseModule.separateAxes);
            writer.WriteProperty("strength", noiseModule.strength);
            writer.WriteProperty("strengthMultiplier", noiseModule.strengthMultiplier);
            writer.WriteProperty("strengthX", noiseModule.strengthX);
            writer.WriteProperty("strengthXMultiplier", noiseModule.strengthXMultiplier);
            writer.WriteProperty("strengthY", noiseModule.strengthY);
            writer.WriteProperty("strengthYMultiplier", noiseModule.strengthYMultiplier);
            writer.WriteProperty("strengthZ", noiseModule.strengthZ);
            writer.WriteProperty("strengthZMultiplier", noiseModule.strengthZMultiplier);
            writer.WriteProperty("frequency", noiseModule.frequency);
            writer.WriteProperty("damping", noiseModule.damping);
            writer.WriteProperty("octaveCount", noiseModule.octaveCount);
            writer.WriteProperty("octaveMultiplier", noiseModule.octaveMultiplier);
            writer.WriteProperty("octaveScale", noiseModule.octaveScale);
            writer.WriteProperty("quality", noiseModule.quality);
            writer.WriteProperty("scrollSpeed", noiseModule.scrollSpeed);
            writer.WriteProperty("scrollSpeedMultiplier", noiseModule.scrollSpeedMultiplier);
            writer.WriteProperty("remapEnabled", noiseModule.remapEnabled);
            writer.WriteProperty("remap", noiseModule.remap);
            writer.WriteProperty("remapMultiplier", noiseModule.remapMultiplier);
            writer.WriteProperty("remapX", noiseModule.remapX);
            writer.WriteProperty("remapXMultiplier", noiseModule.remapXMultiplier);
            writer.WriteProperty("remapY", noiseModule.remapY);
            writer.WriteProperty("remapYMultiplier", noiseModule.remapYMultiplier);
            writer.WriteProperty("remapZ", noiseModule.remapZ);
            writer.WriteProperty("remapZMultiplier", noiseModule.remapZMultiplier);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "positionAmount", noiseModule.positionAmount );
			writer.WriteProperty ( "rotationAmount", noiseModule.rotationAmount );
			writer.WriteProperty ( "sizeAmount", noiseModule.sizeAmount );
#endif
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.ParticleSystem.NoiseModule noiseModule = new UnityEngine.ParticleSystem.NoiseModule();
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "enabled":
                        noiseModule.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "separateAxes":
                        noiseModule.separateAxes = reader.ReadProperty<System.Boolean>();
                        break;
                    case "strength":
                        noiseModule.strength = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "strengthMultiplier":
                        noiseModule.strengthMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "strengthX":
                        noiseModule.strengthX = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "strengthXMultiplier":
                        noiseModule.strengthXMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "strengthY":
                        noiseModule.strengthY = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "strengthYMultiplier":
                        noiseModule.strengthYMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "strengthZ":
                        noiseModule.strengthZ = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "strengthZMultiplier":
                        noiseModule.strengthZMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "frequency":
                        noiseModule.frequency = reader.ReadProperty<System.Single>();
                        break;
                    case "damping":
                        noiseModule.damping = reader.ReadProperty<System.Boolean>();
                        break;
                    case "octaveCount":
                        noiseModule.octaveCount = reader.ReadProperty<System.Int32>();
                        break;
                    case "octaveMultiplier":
                        noiseModule.octaveMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "octaveScale":
                        noiseModule.octaveScale = reader.ReadProperty<System.Single>();
                        break;
                    case "quality":
                        noiseModule.quality = reader.ReadProperty<UnityEngine.ParticleSystemNoiseQuality>();
                        break;
                    case "scrollSpeed":
                        noiseModule.scrollSpeed = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "scrollSpeedMultiplier":
                        noiseModule.scrollSpeedMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "remapEnabled":
                        noiseModule.remapEnabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "remap":
                        noiseModule.remap = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "remapMultiplier":
                        noiseModule.remapMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "remapX":
                        noiseModule.remapX = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "remapXMultiplier":
                        noiseModule.remapXMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "remapY":
                        noiseModule.remapY = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "remapYMultiplier":
                        noiseModule.remapYMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "remapZ":
                        noiseModule.remapZ = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "remapZMultiplier":
                        noiseModule.remapZMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "positionAmount":
#if UNITY_2017_1_OR_NEWER
                        noiseModule.positionAmount = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
#else
                        reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
#endif
                        break;
                    case "rotationAmount":
#if UNITY_2017_1_OR_NEWER
                        noiseModule.rotationAmount = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
#else
                        reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
#endif
                        break;
                    case "sizeAmount":
#if UNITY_2017_1_OR_NEWER
                        noiseModule.sizeAmount = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
#else
                        reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
#endif
                        break;
                }
            }
            return noiseModule;
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