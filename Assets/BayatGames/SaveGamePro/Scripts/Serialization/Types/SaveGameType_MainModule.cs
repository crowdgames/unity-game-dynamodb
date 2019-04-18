using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type MainModule serialization implementation.
    /// </summary>
    public class SaveGameType_MainModule : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.ParticleSystem.MainModule);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.ParticleSystem.MainModule mainModule = (UnityEngine.ParticleSystem.MainModule)value;
            writer.WriteProperty("duration", mainModule.duration);
            writer.WriteProperty("loop", mainModule.loop);
            writer.WriteProperty("prewarm", mainModule.prewarm);
            writer.WriteProperty("startDelay", mainModule.startDelay);
            writer.WriteProperty("startDelayMultiplier", mainModule.startDelayMultiplier);
            writer.WriteProperty("startLifetime", mainModule.startLifetime);
            writer.WriteProperty("startLifetimeMultiplier", mainModule.startLifetimeMultiplier);
            writer.WriteProperty("startSpeed", mainModule.startSpeed);
            writer.WriteProperty("startSpeedMultiplier", mainModule.startSpeedMultiplier);
            writer.WriteProperty("startSize3D", mainModule.startSize3D);
            writer.WriteProperty("startSize", mainModule.startSize);
            writer.WriteProperty("startSizeMultiplier", mainModule.startSizeMultiplier);
            writer.WriteProperty("startSizeX", mainModule.startSizeX);
            writer.WriteProperty("startSizeXMultiplier", mainModule.startSizeXMultiplier);
            writer.WriteProperty("startSizeY", mainModule.startSizeY);
            writer.WriteProperty("startSizeYMultiplier", mainModule.startSizeYMultiplier);
            writer.WriteProperty("startSizeZ", mainModule.startSizeZ);
            writer.WriteProperty("startSizeZMultiplier", mainModule.startSizeZMultiplier);
            writer.WriteProperty("startRotation3D", mainModule.startRotation3D);
            writer.WriteProperty("startRotation", mainModule.startRotation);
            writer.WriteProperty("startRotationMultiplier", mainModule.startRotationMultiplier);
            writer.WriteProperty("startRotationX", mainModule.startRotationX);
            writer.WriteProperty("startRotationXMultiplier", mainModule.startRotationXMultiplier);
            writer.WriteProperty("startRotationY", mainModule.startRotationY);
            writer.WriteProperty("startRotationYMultiplier", mainModule.startRotationYMultiplier);
            writer.WriteProperty("startRotationZ", mainModule.startRotationZ);
            writer.WriteProperty("startRotationZMultiplier", mainModule.startRotationZMultiplier);
            //writer.WriteProperty("randomizeRotationDirection", mainModule.flipRotation);
            writer.WriteProperty("startColor", mainModule.startColor);
            writer.WriteProperty("gravityModifier", mainModule.gravityModifier);
            writer.WriteProperty("gravityModifierMultiplier", mainModule.gravityModifierMultiplier);
            writer.WriteProperty("simulationSpace", mainModule.simulationSpace);
            writer.WriteProperty("customSimulationSpace", mainModule.customSimulationSpace);
            writer.WriteProperty("simulationSpeed", mainModule.simulationSpeed);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty("useUnscaledTime", mainModule.useUnscaledTime);
#endif
            writer.WriteProperty("scalingMode", mainModule.scalingMode);
            writer.WriteProperty("playOnAwake", mainModule.playOnAwake);
            writer.WriteProperty("maxParticles", mainModule.maxParticles);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty("emitterVelocityMode", mainModule.emitterVelocityMode);
#endif
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.ParticleSystem.MainModule mainModule = new UnityEngine.ParticleSystem.MainModule();
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "duration":
                        mainModule.duration = reader.ReadProperty<System.Single>();
                        break;
                    case "loop":
                        mainModule.loop = reader.ReadProperty<System.Boolean>();
                        break;
                    case "prewarm":
                        mainModule.prewarm = reader.ReadProperty<System.Boolean>();
                        break;
                    case "startDelay":
                        mainModule.startDelay = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "startDelayMultiplier":
                        mainModule.startDelayMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startLifetime":
                        mainModule.startLifetime = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "startLifetimeMultiplier":
                        mainModule.startLifetimeMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startSpeed":
                        mainModule.startSpeed = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "startSpeedMultiplier":
                        mainModule.startSpeedMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startSize3D":
                        mainModule.startSize3D = reader.ReadProperty<System.Boolean>();
                        break;
                    case "startSize":
                        mainModule.startSize = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "startSizeMultiplier":
                        mainModule.startSizeMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startSizeX":
                        mainModule.startSizeX = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "startSizeXMultiplier":
                        mainModule.startSizeXMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startSizeY":
                        mainModule.startSizeY = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "startSizeYMultiplier":
                        mainModule.startSizeYMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startSizeZ":
                        mainModule.startSizeZ = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "startSizeZMultiplier":
                        mainModule.startSizeZMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startRotation3D":
                        mainModule.startRotation3D = reader.ReadProperty<System.Boolean>();
                        break;
                    case "startRotation":
                        mainModule.startRotation = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "startRotationMultiplier":
                        mainModule.startRotationMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startRotationX":
                        mainModule.startRotationX = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "startRotationXMultiplier":
                        mainModule.startRotationXMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startRotationY":
                        mainModule.startRotationY = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "startRotationYMultiplier":
                        mainModule.startRotationYMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startRotationZ":
                        mainModule.startRotationZ = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "startRotationZMultiplier":
                        mainModule.startRotationZMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "randomizeRotationDirection": // Removed in Unity 2017.4
                        reader.ReadProperty<System.Single>();
                        break;
                    case "startColor":
                        mainModule.startColor = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxGradient>();
                        break;
                    case "gravityModifier":
                        mainModule.gravityModifier = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "gravityModifierMultiplier":
                        mainModule.gravityModifierMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "simulationSpace":
                        mainModule.simulationSpace = reader.ReadProperty<UnityEngine.ParticleSystemSimulationSpace>();
                        break;
                    case "customSimulationSpace":
                        if (mainModule.customSimulationSpace == null)
                        {
                            mainModule.customSimulationSpace = reader.ReadProperty<UnityEngine.Transform>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Transform>(mainModule.customSimulationSpace);
                        }
                        break;
                    case "simulationSpeed":
                        mainModule.simulationSpeed = reader.ReadProperty<System.Single>();
                        break;
                    case "useUnscaledTime":
#if UNITY_2017_1_OR_NEWER
                        mainModule.useUnscaledTime = reader.ReadProperty<System.Boolean>();
#else
                        reader.ReadProperty<System.Boolean>();
#endif
                        break;
                    case "scalingMode":
                        mainModule.scalingMode = reader.ReadProperty<UnityEngine.ParticleSystemScalingMode>();
                        break;
                    case "playOnAwake":
                        mainModule.playOnAwake = reader.ReadProperty<System.Boolean>();
                        break;
                    case "maxParticles":
                        mainModule.maxParticles = reader.ReadProperty<System.Int32>();
                        break;
                    case "emitterVelocityMode":
#if UNITY_2017_1_OR_NEWER
                        mainModule.emitterVelocityMode = reader.ReadProperty<UnityEngine.ParticleSystemEmitterVelocityMode>();
#endif
                        break;
                }
            }
            return mainModule;
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