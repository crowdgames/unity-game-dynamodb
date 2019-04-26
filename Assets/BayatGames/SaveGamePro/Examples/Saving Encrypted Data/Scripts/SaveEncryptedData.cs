using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BayatGames.SaveGamePro.Examples
{

    /// <summary>
    /// Saving encrypted data example.
    /// </summary>
    public class SaveEncryptedData : MonoBehaviour
    {

        public string identifier = "encrypted.dat";
        public InputField password;
        public InputField dataField;

        protected SaveGameSettings saveSettings;

        private void Awake()
        {
            this.saveSettings = new SaveGameSettings();
            this.saveSettings.Encrypt = true;
        }

        public void Save()
        {
            this.saveSettings.EncryptionPassword = this.password.text;
            SaveGame.Save(this.identifier, this.dataField.text, this.saveSettings);
            Debug.Log("Encrypted Data has been saved successfully");
        }

        public void Load()
        {
            this.saveSettings.EncryptionPassword = this.password.text;
            this.dataField.text = SaveGame.Load<string>(this.identifier, "Default Data", this.saveSettings);
            Debug.Log("Encrypted Data has been loaded successfully");
            Debug.Log(this.dataField.text);
        }

    }

}