using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type HingeJoint serialization implementation.
    /// </summary>
    public class SaveGameType_HingeJoint : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.HingeJoint);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.HingeJoint hingeJoint = (UnityEngine.HingeJoint)value;
            writer.WriteProperty("motor", hingeJoint.motor);
            writer.WriteProperty("limits", hingeJoint.limits);
            writer.WriteProperty("spring", hingeJoint.spring);
            writer.WriteProperty("useMotor", hingeJoint.useMotor);
            writer.WriteProperty("useLimits", hingeJoint.useLimits);
            writer.WriteProperty("useSpring", hingeJoint.useSpring);
            writer.WriteProperty("connectedBody", hingeJoint.connectedBody);
            writer.WriteProperty("axis", hingeJoint.axis);
            writer.WriteProperty("anchor", hingeJoint.anchor);
            writer.WriteProperty("connectedAnchor", hingeJoint.connectedAnchor);
            writer.WriteProperty("autoConfigureConnectedAnchor", hingeJoint.autoConfigureConnectedAnchor);
            writer.WriteProperty("breakForce", hingeJoint.breakForce);
            writer.WriteProperty("breakTorque", hingeJoint.breakTorque);
            writer.WriteProperty("enableCollision", hingeJoint.enableCollision);
            writer.WriteProperty("enablePreprocessing", hingeJoint.enablePreprocessing);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "massScale", hingeJoint.massScale );
			writer.WriteProperty ( "connectedMassScale", hingeJoint.connectedMassScale );
#endif
            writer.WriteProperty("tag", hingeJoint.tag);
            writer.WriteProperty("name", hingeJoint.name);
            writer.WriteProperty("hideFlags", hingeJoint.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.HingeJoint hingeJoint = SaveGameType.CreateComponent<UnityEngine.HingeJoint>();
            ReadInto(hingeJoint, reader);
            return hingeJoint;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.HingeJoint hingeJoint = (UnityEngine.HingeJoint)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "motor":
                        hingeJoint.motor = reader.ReadProperty<UnityEngine.JointMotor>();
                        break;
                    case "limits":
                        hingeJoint.limits = reader.ReadProperty<UnityEngine.JointLimits>();
                        break;
                    case "spring":
                        hingeJoint.spring = reader.ReadProperty<UnityEngine.JointSpring>();
                        break;
                    case "useMotor":
                        hingeJoint.useMotor = reader.ReadProperty<System.Boolean>();
                        break;
                    case "useLimits":
                        hingeJoint.useLimits = reader.ReadProperty<System.Boolean>();
                        break;
                    case "useSpring":
                        hingeJoint.useSpring = reader.ReadProperty<System.Boolean>();
                        break;
                    case "connectedBody":
                        if (hingeJoint.connectedBody == null)
                        {
                            hingeJoint.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Rigidbody>(hingeJoint.connectedBody);
                        }
                        break;
                    case "axis":
                        hingeJoint.axis = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "anchor":
                        hingeJoint.anchor = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "connectedAnchor":
                        hingeJoint.connectedAnchor = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "autoConfigureConnectedAnchor":
                        hingeJoint.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean>();
                        break;
                    case "breakForce":
                        hingeJoint.breakForce = reader.ReadProperty<System.Single>();
                        break;
                    case "breakTorque":
                        hingeJoint.breakTorque = reader.ReadProperty<System.Single>();
                        break;
                    case "enableCollision":
                        hingeJoint.enableCollision = reader.ReadProperty<System.Boolean>();
                        break;
                    case "enablePreprocessing":
                        hingeJoint.enablePreprocessing = reader.ReadProperty<System.Boolean>();
                        break;
                    case "massScale":
#if UNITY_2017_1_OR_NEWER
                        hingeJoint.massScale = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "connectedMassScale":
#if UNITY_2017_1_OR_NEWER
                        hingeJoint.connectedMassScale = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "tag":
                        hingeJoint.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        hingeJoint.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        hingeJoint.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}