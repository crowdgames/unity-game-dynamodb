using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BayatGames.SaveGamePro.Events;

namespace BayatGames.SaveGamePro
{

    /// <summary>
    /// Save Game Behaviour.
    /// </summary>
    public abstract class SaveGameBehaviour : MonoBehaviour
    {

        #region Fields

        [SerializeField]
        protected SaveGameSettings m_SaveSettings;
        [SerializeField]
        protected SaveEvent m_OnSaved;
        [SerializeField]
        protected LoadEvent m_OnLoaded;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the save settings.
        /// </summary>
        /// <value>The save settings.</value>
        public virtual SaveGameSettings SaveSettings
        {
            get
            {
                if (string.IsNullOrEmpty(m_SaveSettings.Identifier))
                {
                    m_SaveSettings.Identifier = this.name + "/" + this.GetInstanceID().ToString();
                }
                return m_SaveSettings;
            }
            set
            {
                m_SaveSettings = value;
            }
        }

        /// <summary>
        /// Gets the on saved.
        /// </summary>
        /// <value>The on saved.</value>
        public virtual SaveEvent OnSaved
        {
            get
            {
                return m_OnSaved;
            }
        }

        /// <summary>
        /// Gets the on loaded.
        /// </summary>
        /// <value>The on loaded.</value>
        public virtual LoadEvent OnLoaded
        {
            get
            {
                return m_OnLoaded;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Save this instance.
        /// </summary>
        public virtual void Save()
        {
            SaveGame.Save(SaveSettings.Identifier, this, SaveSettings);
            m_OnSaved.Invoke(SaveSettings.Identifier, this, SaveSettings);
        }

        /// <summary>
        /// Load this instance.
        /// </summary>
        public virtual void Load()
        {
            SaveGame.LoadInto(SaveSettings.Identifier, this, SaveSettings);
            m_OnLoaded.Invoke(SaveSettings.Identifier, this, SaveSettings);
        }

        #endregion

    }

}