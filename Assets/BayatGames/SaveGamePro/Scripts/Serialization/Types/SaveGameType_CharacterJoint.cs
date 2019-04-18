using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type CharacterJoint serialization implementation.
    /// </summary>
    public class SaveGameType_CharacterJoint : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.CharacterJoint);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.CharacterJoint characterJoint = (UnityEngine.CharacterJoint)value;
            writer.WriteProperty("swingAxis", characterJoint.swingAxis);
            writer.WriteProperty("twistLimitSpring", characterJoint.twistLimitSpring);
            writer.WriteProperty("swingLimitSpring", characterJoint.swingLimitSpring);
            writer.WriteProperty("lowTwistLimit", characterJoint.lowTwistLimit);
            writer.WriteProperty("highTwistLimit", characterJoint.highTwistLimit);
            writer.WriteProperty("swing1Limit", characterJoint.swing1Limit);
            writer.WriteProperty("swing2Limit", characterJoint.swing2Limit);
            writer.WriteProperty("enableProjection", characterJoint.enableProjection);
            writer.WriteProperty("projectionDistance", characterJoint.projectionDistance);
            writer.WriteProperty("projectionAngle", characterJoint.projectionAngle);
            writer.WriteProperty("connectedBody", characterJoint.connectedBody);
            writer.WriteProperty("axis", characterJoint.axis);
            writer.WriteProperty("anchor", characterJoint.anchor);
            writer.WriteProperty("connectedAnchor", characterJoint.connectedAnchor);
            writer.WriteProperty("autoConfigureConnectedAnchor", characterJoint.autoConfigureConnectedAnchor);
            writer.WriteProperty("breakForce", characterJoint.breakForce);
            writer.WriteProperty("breakTorque", characterJoint.breakTorque);
            writer.WriteProperty("enableCollision", characterJoint.enableCollision);
            writer.WriteProperty("enablePreprocessing", characterJoint.enablePreprocessing);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "massScale", characterJoint.massScale );
            writer.WriteProperty("connectedMassScale", characterJoint.connectedMassScale);
#endif
            writer.WriteProperty("tag", characterJoint.tag);
            writer.WriteProperty("name", characterJoint.name);
            writer.WriteProperty("hideFlags", characterJoint.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.CharacterJoint characterJoint = SaveGameType.CreateComponent<UnityEngine.CharacterJoint>();
            ReadInto(characterJoint, reader);
            return characterJoint;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.CharacterJoint characterJoint = (UnityEngine.CharacterJoint)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "swingAxis":
                        characterJoint.swingAxis = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "twistLimitSpring":
                        characterJoint.twistLimitSpring = reader.ReadProperty<UnityEngine.SoftJointLimitSpring>();
                        break;
                    case "swingLimitSpring":
                        characterJoint.swingLimitSpring = reader.ReadProperty<UnityEngine.SoftJointLimitSpring>();
                        break;
                    case "lowTwistLimit":
                        characterJoint.lowTwistLimit = reader.ReadProperty<UnityEngine.SoftJointLimit>();
                        break;
                    case "highTwistLimit":
                        characterJoint.highTwistLimit = reader.ReadProperty<UnityEngine.SoftJointLimit>();
                        break;
                    case "swing1Limit":
                        characterJoint.swing1Limit = reader.ReadProperty<UnityEngine.SoftJointLimit>();
                        break;
                    case "swing2Limit":
                        characterJoint.swing2Limit = reader.ReadProperty<UnityEngine.SoftJointLimit>();
                        break;
                    case "enableProjection":
                        characterJoint.enableProjection = reader.ReadProperty<System.Boolean>();
                        break;
                    case "projectionDistance":
                        characterJoint.projectionDistance = reader.ReadProperty<System.Single>();
                        break;
                    case "projectionAngle":
                        characterJoint.projectionAngle = reader.ReadProperty<System.Single>();
                        break;
                    case "connectedBody":
                        if (characterJoint.connectedBody == null)
                        {
                            characterJoint.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Rigidbody>(characterJoint.connectedBody);
                        }
                        break;
                    case "axis":
                        characterJoint.axis = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "anchor":
                        characterJoint.anchor = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "connectedAnchor":
                        characterJoint.connectedAnchor = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "autoConfigureConnectedAnchor":
                        characterJoint.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean>();
                        break;
                    case "breakForce":
                        characterJoint.breakForce = reader.ReadProperty<System.Single>();
                        break;
                    case "breakTorque":
                        characterJoint.breakTorque = reader.ReadProperty<System.Single>();
                        break;
                    case "enableCollision":
                        characterJoint.enableCollision = reader.ReadProperty<System.Boolean>();
                        break;
                    case "enablePreprocessing":
                        characterJoint.enablePreprocessing = reader.ReadProperty<System.Boolean>();
                        break;
                    case "massScale":
#if UNITY_2017_1_OR_NEWER
                        characterJoint.massScale = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "connectedMassScale":
#if UNITY_2017_1_OR_NEWER
                        characterJoint.connectedMassScale = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "tag":
                        characterJoint.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        characterJoint.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        characterJoint.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}