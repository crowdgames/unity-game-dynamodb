using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type ShapeModule serialization implementation.
    /// </summary>
    public class SaveGameType_ShapeModule : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.ParticleSystem.ShapeModule);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.ParticleSystem.ShapeModule shapeModule = (UnityEngine.ParticleSystem.ShapeModule)value;
            writer.WriteProperty("enabled", shapeModule.enabled);
            writer.WriteProperty("shapeType", shapeModule.shapeType);
            writer.WriteProperty("randomDirectionAmount", shapeModule.randomDirectionAmount);
            writer.WriteProperty("sphericalDirectionAmount", shapeModule.sphericalDirectionAmount);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "randomPositionAmount", shapeModule.randomPositionAmount );
#endif
            writer.WriteProperty("alignToDirection", shapeModule.alignToDirection);
            writer.WriteProperty("radius", shapeModule.radius);
            writer.WriteProperty("radiusMode", shapeModule.radiusMode);
            writer.WriteProperty("radiusSpread", shapeModule.radiusSpread);
            writer.WriteProperty("radiusSpeed", shapeModule.radiusSpeed);
            writer.WriteProperty("radiusSpeedMultiplier", shapeModule.radiusSpeedMultiplier);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty("radiusThickness", shapeModule.radiusThickness);
#endif
            writer.WriteProperty("angle", shapeModule.angle);
            writer.WriteProperty("length", shapeModule.length);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty("boxThickness", shapeModule.boxThickness);
#endif
            writer.WriteProperty("meshShapeType", shapeModule.meshShapeType);
            writer.WriteProperty("mesh", shapeModule.mesh);
            writer.WriteProperty("meshRenderer", shapeModule.meshRenderer);
            writer.WriteProperty("skinnedMeshRenderer", shapeModule.skinnedMeshRenderer);
            writer.WriteProperty("useMeshMaterialIndex", shapeModule.useMeshMaterialIndex);
            writer.WriteProperty("meshMaterialIndex", shapeModule.meshMaterialIndex);
            writer.WriteProperty("useMeshColors", shapeModule.useMeshColors);
            writer.WriteProperty("normalOffset", shapeModule.normalOffset);
            writer.WriteProperty("arc", shapeModule.arc);
            writer.WriteProperty("arcMode", shapeModule.arcMode);
            writer.WriteProperty("arcSpread", shapeModule.arcSpread);
            writer.WriteProperty("arcSpeed", shapeModule.arcSpeed);
            writer.WriteProperty("arcSpeedMultiplier", shapeModule.arcSpeedMultiplier);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty("donutRadius", shapeModule.donutRadius);
            writer.WriteProperty("position", shapeModule.position);
            writer.WriteProperty("rotation", shapeModule.rotation);
            writer.WriteProperty("scale", shapeModule.scale);
#endif

        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.ParticleSystem.ShapeModule shapeModule = new UnityEngine.ParticleSystem.ShapeModule();
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "enabled":
                        shapeModule.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "shapeType":
                        shapeModule.shapeType = reader.ReadProperty<UnityEngine.ParticleSystemShapeType>();
                        break;
                    case "randomDirectionAmount":
                        shapeModule.randomDirectionAmount = reader.ReadProperty<System.Single>();
                        break;
                    case "sphericalDirectionAmount":
                        shapeModule.sphericalDirectionAmount = reader.ReadProperty<System.Single>();
                        break;
                    case "randomPositionAmount":
#if UNITY_2017_1_OR_NEWER
                        shapeModule.randomPositionAmount = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "alignToDirection":
                        shapeModule.alignToDirection = reader.ReadProperty<System.Boolean>();
                        break;
                    case "radius":
                        shapeModule.radius = reader.ReadProperty<System.Single>();
                        break;
                    case "radiusMode":
                        shapeModule.radiusMode = reader.ReadProperty<UnityEngine.ParticleSystemShapeMultiModeValue>();
                        break;
                    case "radiusSpread":
                        shapeModule.radiusSpread = reader.ReadProperty<System.Single>();
                        break;
                    case "radiusSpeed":
                        shapeModule.radiusSpeed = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "radiusSpeedMultiplier":
                        shapeModule.radiusSpeedMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "radiusThickness":
#if UNITY_2017_1_OR_NEWER
                        shapeModule.radiusThickness = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "angle":
                        shapeModule.angle = reader.ReadProperty<System.Single>();
                        break;
                    case "length":
                        shapeModule.length = reader.ReadProperty<System.Single>();
                        break;
                    case "boxThickness":
#if UNITY_2017_1_OR_NEWER
                        shapeModule.boxThickness = reader.ReadProperty<UnityEngine.Vector3>();
#else
                        reader.ReadProperty<UnityEngine.Vector3>();
#endif
                        break;
                    case "meshShapeType":
                        shapeModule.meshShapeType = reader.ReadProperty<UnityEngine.ParticleSystemMeshShapeType>();
                        break;
                    case "mesh":
                        if (shapeModule.mesh == null)
                        {
                            shapeModule.mesh = reader.ReadProperty<UnityEngine.Mesh>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Mesh>(shapeModule.mesh);
                        }
                        break;
                    case "meshRenderer":
                        if (shapeModule.meshRenderer == null)
                        {
                            shapeModule.meshRenderer = reader.ReadProperty<UnityEngine.MeshRenderer>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.MeshRenderer>(shapeModule.meshRenderer);
                        }
                        break;
                    case "skinnedMeshRenderer":
                        if (shapeModule.skinnedMeshRenderer == null)
                        {
                            shapeModule.skinnedMeshRenderer = reader.ReadProperty<UnityEngine.SkinnedMeshRenderer>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.SkinnedMeshRenderer>(shapeModule.skinnedMeshRenderer);
                        }
                        break;
                    case "useMeshMaterialIndex":
                        shapeModule.useMeshMaterialIndex = reader.ReadProperty<System.Boolean>();
                        break;
                    case "meshMaterialIndex":
                        shapeModule.meshMaterialIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "useMeshColors":
                        shapeModule.useMeshColors = reader.ReadProperty<System.Boolean>();
                        break;
                    case "normalOffset":
                        shapeModule.normalOffset = reader.ReadProperty<System.Single>();
                        break;
                    case "arc":
                        shapeModule.arc = reader.ReadProperty<System.Single>();
                        break;
                    case "arcMode":
                        shapeModule.arcMode = reader.ReadProperty<UnityEngine.ParticleSystemShapeMultiModeValue>();
                        break;
                    case "arcSpread":
                        shapeModule.arcSpread = reader.ReadProperty<System.Single>();
                        break;
                    case "arcSpeed":
                        shapeModule.arcSpeed = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve>();
                        break;
                    case "arcSpeedMultiplier":
                        shapeModule.arcSpeedMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "donutRadius":
#if UNITY_2017_1_OR_NEWER
                        shapeModule.donutRadius = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "position":
#if UNITY_2017_1_OR_NEWER
                        shapeModule.position = reader.ReadProperty<UnityEngine.Vector3>();
#else
                        reader.ReadProperty<UnityEngine.Vector3>();
#endif
                        break;
                    case "rotation":
#if UNITY_2017_1_OR_NEWER
                        shapeModule.rotation = reader.ReadProperty<UnityEngine.Vector3>();
#else
                        reader.ReadProperty<UnityEngine.Vector3>();
#endif
                        break;
                    case "scale":
#if UNITY_2017_1_OR_NEWER
                        shapeModule.scale = reader.ReadProperty<UnityEngine.Vector3>();
#else
                        reader.ReadProperty<UnityEngine.Vector3>();
#endif
                        break;
                }
            }
            return shapeModule;
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