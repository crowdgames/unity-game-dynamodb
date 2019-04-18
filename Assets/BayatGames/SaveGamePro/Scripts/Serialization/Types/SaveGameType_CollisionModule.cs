using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type CollisionModule serialization implementation.
    /// </summary>
    public class SaveGameType_CollisionModule : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.ParticleSystem.CollisionModule);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.ParticleSystem.CollisionModule collisionModule = (UnityEngine.ParticleSystem.CollisionModule)value;
            writer.WriteProperty("enabled", collisionModule.enabled);
            writer.WriteProperty("type", collisionModule.type);
            writer.WriteProperty("mode", collisionModule.mode);
            writer.WriteProperty("dampen", collisionModule.dampen);
            writer.WriteProperty("dampenMultiplier", collisionModule.dampenMultiplier);
            writer.WriteProperty("bounce", collisionModule.bounce);
            writer.WriteProperty("bounceMultiplier", collisionModule.bounceMultiplier);
            writer.WriteProperty("lifetimeLoss", collisionModule.lifetimeLoss);
            writer.WriteProperty("lifetimeLossMultiplier", collisionModule.lifetimeLossMultiplier);
            writer.WriteProperty("minKillSpeed", collisionModule.minKillSpeed);
            writer.WriteProperty("maxKillSpeed", collisionModule.maxKillSpeed);
            writer.WriteProperty("collidesWith", collisionModule.collidesWith);
            writer.WriteProperty("enableDynamicColliders", collisionModule.enableDynamicColliders);
            writer.WriteProperty("maxCollisionShapes", collisionModule.maxCollisionShapes);
            writer.WriteProperty("quality", collisionModule.quality);
            writer.WriteProperty("voxelSize", collisionModule.voxelSize);
            writer.WriteProperty("radiusScale", collisionModule.radiusScale);
            writer.WriteProperty("sendCollisionMessages", collisionModule.sendCollisionMessages);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "colliderForce", collisionModule.colliderForce );
			writer.WriteProperty ( "multiplyColliderForceByCollisionAngle", collisionModule.multiplyColliderForceByCollisionAngle );
			writer.WriteProperty ( "multiplyColliderForceByParticleSpeed", collisionModule.multiplyColliderForceByParticleSpeed );
			writer.WriteProperty ( "multiplyColliderForceByParticleSize", collisionModule.multiplyColliderForceByParticleSize );
#endif

        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.ParticleSystem.CollisionModule collisionModule = new UnityEngine.ParticleSystem.CollisionModule();
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "enabled":
                        collisionModule.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "type":
                        collisionModule.type = reader.ReadProperty<UnityEngine.ParticleSystemCollisionType>();
                        break;
                    case "mode":
                        collisionModule.mode = reader.ReadProperty<UnityEngine.ParticleSystemCollisionMode>();
                        break;
                    case "dampen":
                        collisionModule.dampen = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "dampenMultiplier":
                        collisionModule.dampenMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "bounce":
                        collisionModule.bounce = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "bounceMultiplier":
                        collisionModule.bounceMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "lifetimeLoss":
                        collisionModule.lifetimeLoss = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "lifetimeLossMultiplier":
                        collisionModule.lifetimeLossMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "minKillSpeed":
                        collisionModule.minKillSpeed = reader.ReadProperty<System.Single>();
                        break;
                    case "maxKillSpeed":
                        collisionModule.maxKillSpeed = reader.ReadProperty<System.Single>();
                        break;
                    case "collidesWith":
                        collisionModule.collidesWith = reader.ReadProperty<UnityEngine.LayerMask>();
                        break;
                    case "enableDynamicColliders":
                        collisionModule.enableDynamicColliders = reader.ReadProperty<System.Boolean>();
                        break;
                    case "maxCollisionShapes":
                        collisionModule.maxCollisionShapes = reader.ReadProperty<System.Int32>();
                        break;
                    case "quality":
                        collisionModule.quality = reader.ReadProperty<UnityEngine.ParticleSystemCollisionQuality>();
                        break;
                    case "voxelSize":
                        collisionModule.voxelSize = reader.ReadProperty<System.Single>();
                        break;
                    case "radiusScale":
                        collisionModule.radiusScale = reader.ReadProperty<System.Single>();
                        break;
                    case "sendCollisionMessages":
                        collisionModule.sendCollisionMessages = reader.ReadProperty<System.Boolean>();
                        break;
                    case "colliderForce":
#if UNITY_2017_1_OR_NEWER
                        collisionModule.colliderForce = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "multiplyColliderForceByCollisionAngle":
#if UNITY_2017_1_OR_NEWER
                        collisionModule.multiplyColliderForceByCollisionAngle = reader.ReadProperty<System.Boolean>();
#else
                        reader.ReadProperty<System.Boolean>();
#endif
                        break;
                    case "multiplyColliderForceByParticleSpeed":
#if UNITY_2017_1_OR_NEWER
                        collisionModule.multiplyColliderForceByParticleSpeed = reader.ReadProperty<System.Boolean>();
#else
                        reader.ReadProperty<System.Boolean>();
#endif
                        break;
                    case "multiplyColliderForceByParticleSize":
#if UNITY_2017_1_OR_NEWER
                        collisionModule.multiplyColliderForceByParticleSize = reader.ReadProperty<System.Boolean>();
#else
                        reader.ReadProperty<System.Boolean>();
#endif
                        break;
                }
            }
            return collisionModule;
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