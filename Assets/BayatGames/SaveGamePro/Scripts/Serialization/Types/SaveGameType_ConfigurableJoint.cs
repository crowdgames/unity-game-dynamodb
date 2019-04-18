using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type ConfigurableJoint serialization implementation.
    /// </summary>
    public class SaveGameType_ConfigurableJoint : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.ConfigurableJoint);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.ConfigurableJoint configurableJoint = (UnityEngine.ConfigurableJoint)value;
            writer.WriteProperty("secondaryAxis", configurableJoint.secondaryAxis);
            writer.WriteProperty("xMotion", configurableJoint.xMotion);
            writer.WriteProperty("yMotion", configurableJoint.yMotion);
            writer.WriteProperty("zMotion", configurableJoint.zMotion);
            writer.WriteProperty("angularXMotion", configurableJoint.angularXMotion);
            writer.WriteProperty("angularYMotion", configurableJoint.angularYMotion);
            writer.WriteProperty("angularZMotion", configurableJoint.angularZMotion);
            writer.WriteProperty("linearLimitSpring", configurableJoint.linearLimitSpring);
            writer.WriteProperty("angularXLimitSpring", configurableJoint.angularXLimitSpring);
            writer.WriteProperty("angularYZLimitSpring", configurableJoint.angularYZLimitSpring);
            writer.WriteProperty("linearLimit", configurableJoint.linearLimit);
            writer.WriteProperty("lowAngularXLimit", configurableJoint.lowAngularXLimit);
            writer.WriteProperty("highAngularXLimit", configurableJoint.highAngularXLimit);
            writer.WriteProperty("angularYLimit", configurableJoint.angularYLimit);
            writer.WriteProperty("angularZLimit", configurableJoint.angularZLimit);
            writer.WriteProperty("targetPosition", configurableJoint.targetPosition);
            writer.WriteProperty("targetVelocity", configurableJoint.targetVelocity);
            writer.WriteProperty("xDrive", configurableJoint.xDrive);
            writer.WriteProperty("yDrive", configurableJoint.yDrive);
            writer.WriteProperty("zDrive", configurableJoint.zDrive);
            writer.WriteProperty("targetRotation", configurableJoint.targetRotation);
            writer.WriteProperty("targetAngularVelocity", configurableJoint.targetAngularVelocity);
            writer.WriteProperty("rotationDriveMode", configurableJoint.rotationDriveMode);
            writer.WriteProperty("angularXDrive", configurableJoint.angularXDrive);
            writer.WriteProperty("angularYZDrive", configurableJoint.angularYZDrive);
            writer.WriteProperty("slerpDrive", configurableJoint.slerpDrive);
            writer.WriteProperty("projectionMode", configurableJoint.projectionMode);
            writer.WriteProperty("projectionDistance", configurableJoint.projectionDistance);
            writer.WriteProperty("projectionAngle", configurableJoint.projectionAngle);
            writer.WriteProperty("configuredInWorldSpace", configurableJoint.configuredInWorldSpace);
            writer.WriteProperty("swapBodies", configurableJoint.swapBodies);
            writer.WriteProperty("connectedBody", configurableJoint.connectedBody);
            writer.WriteProperty("axis", configurableJoint.axis);
            writer.WriteProperty("anchor", configurableJoint.anchor);
            writer.WriteProperty("connectedAnchor", configurableJoint.connectedAnchor);
            writer.WriteProperty("autoConfigureConnectedAnchor", configurableJoint.autoConfigureConnectedAnchor);
            writer.WriteProperty("breakForce", configurableJoint.breakForce);
            writer.WriteProperty("breakTorque", configurableJoint.breakTorque);
            writer.WriteProperty("enableCollision", configurableJoint.enableCollision);
            writer.WriteProperty("enablePreprocessing", configurableJoint.enablePreprocessing);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "massScale", configurableJoint.massScale );
			writer.WriteProperty ( "connectedMassScale", configurableJoint.connectedMassScale );
#endif
            writer.WriteProperty("tag", configurableJoint.tag);
            writer.WriteProperty("name", configurableJoint.name);
            writer.WriteProperty("hideFlags", configurableJoint.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.ConfigurableJoint configurableJoint = SaveGameType.CreateComponent<UnityEngine.ConfigurableJoint>();
            ReadInto(configurableJoint, reader);
            return configurableJoint;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.ConfigurableJoint configurableJoint = (UnityEngine.ConfigurableJoint)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "secondaryAxis":
                        configurableJoint.secondaryAxis = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "xMotion":
                        configurableJoint.xMotion = reader.ReadProperty<UnityEngine.ConfigurableJointMotion>();
                        break;
                    case "yMotion":
                        configurableJoint.yMotion = reader.ReadProperty<UnityEngine.ConfigurableJointMotion>();
                        break;
                    case "zMotion":
                        configurableJoint.zMotion = reader.ReadProperty<UnityEngine.ConfigurableJointMotion>();
                        break;
                    case "angularXMotion":
                        configurableJoint.angularXMotion = reader.ReadProperty<UnityEngine.ConfigurableJointMotion>();
                        break;
                    case "angularYMotion":
                        configurableJoint.angularYMotion = reader.ReadProperty<UnityEngine.ConfigurableJointMotion>();
                        break;
                    case "angularZMotion":
                        configurableJoint.angularZMotion = reader.ReadProperty<UnityEngine.ConfigurableJointMotion>();
                        break;
                    case "linearLimitSpring":
                        configurableJoint.linearLimitSpring = reader.ReadProperty<UnityEngine.SoftJointLimitSpring>();
                        break;
                    case "angularXLimitSpring":
                        configurableJoint.angularXLimitSpring = reader.ReadProperty<UnityEngine.SoftJointLimitSpring>();
                        break;
                    case "angularYZLimitSpring":
                        configurableJoint.angularYZLimitSpring = reader.ReadProperty<UnityEngine.SoftJointLimitSpring>();
                        break;
                    case "linearLimit":
                        configurableJoint.linearLimit = reader.ReadProperty<UnityEngine.SoftJointLimit>();
                        break;
                    case "lowAngularXLimit":
                        configurableJoint.lowAngularXLimit = reader.ReadProperty<UnityEngine.SoftJointLimit>();
                        break;
                    case "highAngularXLimit":
                        configurableJoint.highAngularXLimit = reader.ReadProperty<UnityEngine.SoftJointLimit>();
                        break;
                    case "angularYLimit":
                        configurableJoint.angularYLimit = reader.ReadProperty<UnityEngine.SoftJointLimit>();
                        break;
                    case "angularZLimit":
                        configurableJoint.angularZLimit = reader.ReadProperty<UnityEngine.SoftJointLimit>();
                        break;
                    case "targetPosition":
                        configurableJoint.targetPosition = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "targetVelocity":
                        configurableJoint.targetVelocity = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "xDrive":
                        configurableJoint.xDrive = reader.ReadProperty<UnityEngine.JointDrive>();
                        break;
                    case "yDrive":
                        configurableJoint.yDrive = reader.ReadProperty<UnityEngine.JointDrive>();
                        break;
                    case "zDrive":
                        configurableJoint.zDrive = reader.ReadProperty<UnityEngine.JointDrive>();
                        break;
                    case "targetRotation":
                        configurableJoint.targetRotation = reader.ReadProperty<UnityEngine.Quaternion>();
                        break;
                    case "targetAngularVelocity":
                        configurableJoint.targetAngularVelocity = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "rotationDriveMode":
                        configurableJoint.rotationDriveMode = reader.ReadProperty<UnityEngine.RotationDriveMode>();
                        break;
                    case "angularXDrive":
                        configurableJoint.angularXDrive = reader.ReadProperty<UnityEngine.JointDrive>();
                        break;
                    case "angularYZDrive":
                        configurableJoint.angularYZDrive = reader.ReadProperty<UnityEngine.JointDrive>();
                        break;
                    case "slerpDrive":
                        configurableJoint.slerpDrive = reader.ReadProperty<UnityEngine.JointDrive>();
                        break;
                    case "projectionMode":
                        configurableJoint.projectionMode = reader.ReadProperty<UnityEngine.JointProjectionMode>();
                        break;
                    case "projectionDistance":
                        configurableJoint.projectionDistance = reader.ReadProperty<System.Single>();
                        break;
                    case "projectionAngle":
                        configurableJoint.projectionAngle = reader.ReadProperty<System.Single>();
                        break;
                    case "configuredInWorldSpace":
                        configurableJoint.configuredInWorldSpace = reader.ReadProperty<System.Boolean>();
                        break;
                    case "swapBodies":
                        configurableJoint.swapBodies = reader.ReadProperty<System.Boolean>();
                        break;
                    case "connectedBody":
                        if (configurableJoint.connectedBody == null)
                        {
                            configurableJoint.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Rigidbody>(configurableJoint.connectedBody);
                        }
                        break;
                    case "axis":
                        configurableJoint.axis = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "anchor":
                        configurableJoint.anchor = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "connectedAnchor":
                        configurableJoint.connectedAnchor = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "autoConfigureConnectedAnchor":
                        configurableJoint.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean>();
                        break;
                    case "breakForce":
                        configurableJoint.breakForce = reader.ReadProperty<System.Single>();
                        break;
                    case "breakTorque":
                        configurableJoint.breakTorque = reader.ReadProperty<System.Single>();
                        break;
                    case "enableCollision":
                        configurableJoint.enableCollision = reader.ReadProperty<System.Boolean>();
                        break;
                    case "enablePreprocessing":
                        configurableJoint.enablePreprocessing = reader.ReadProperty<System.Boolean>();
                        break;
                    case "massScale":
#if UNITY_2017_1_OR_NEWER
                        configurableJoint.massScale = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "connectedMassScale":
#if UNITY_2017_1_OR_NEWER
                        configurableJoint.connectedMassScale = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "tag":
                        configurableJoint.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        configurableJoint.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        configurableJoint.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}