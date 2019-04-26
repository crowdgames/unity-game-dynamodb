using System.Collections;
using System.Collections.Generic;
#if NET_4_6 || NET_STANDARD_2_0
using System.Threading.Tasks;
#endif
using UnityEngine;

namespace BayatGames.SaveGamePro.Examples
{

    /// <summary>
    /// AudioClip save asynchronous.
    /// </summary>
    public class AudioClipSaveAsync : MonoBehaviour
    {

        /// <summary>
        /// The data structure to fetch AudioClip informtion in Main Thread and save it in Async.
        /// </summary>
        public struct ClipData
        {
            public string name;
            public float[] samples;
            public int channels;
            public int frequency;
        }

        /// <summary>
        /// The identifier.
        /// </summary>
        public string identifier = "audioClipSaveSync.txt";

        /// <summary>
        /// The audio clip.
        /// </summary>
        public AudioClip audioClip;

        /// <summary>
        /// Save the data.
        /// </summary>
        public void Save()
        {
#if NET_4_6 || NET_STANDARD_2_0
            Debug.Log("Saving ...");
            ClipData data = new ClipData();
            data.name = this.audioClip.name;
            data.samples = new float[this.audioClip.samples];
            audioClip.GetData(data.samples, 0);
            data.channels = this.audioClip.channels;
            data.frequency = this.audioClip.frequency;
            SaveGame.SaveAsync(this.identifier, data).ContinueWith((task) =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("Save Task - Cancelled");
                }
                else if (task.IsFaulted)
                {
                    Debug.LogError("Save Tsak - Faulted");
                    Debug.LogException(task.Exception);
                }
                else
                {
                    Debug.Log("Saved");
                }
            });
#endif
        }

        /// <summary>
        /// Load the data.
        /// </summary>
        public void Load()
        {
#if NET_4_6 || NET_STANDARD_2_0
            Debug.Log("Loading ...");
            Task<ClipData> task = SaveGame.LoadAsync<ClipData>(this.identifier);
            task.ContinueWith((result) =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("Load Task - Cancelled");
                }
                else if (task.IsFaulted)
                {
                    Debug.LogError("Load Tsak - Faulted");
                    Debug.LogException(task.Exception);
                }
                else
                {
                    Debug.Log("Loaded");

                    // The loaded data is available at Task.Result property, so we assign it to our data variable when loaded, for more informtion check out the below link:
                    // https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1.result
                    //ClipData data = result.Result;
                }
            });
            task.Wait();
            ClipData data = task.Result;
            this.audioClip = AudioClip.Create(data.name, data.samples.Length, data.channels, data.frequency, false);
            audioClip.SetData(data.samples, 0);
#endif
        }

    }

}