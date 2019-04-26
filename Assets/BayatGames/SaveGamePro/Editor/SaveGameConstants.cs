using UnityEditor;

namespace BayatGames.SaveGamePro.Editor
{

    public static class SaveGameConstants
    {

        private static string _BayatGamesFolder;

        public static string BayatGamesFolder
        {
            get
            {
                if (string.IsNullOrEmpty(_BayatGamesFolder))
                {
                    _BayatGamesFolder = AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("BayatGames")[0]);
                }
                return _BayatGamesFolder;
            }
        }
        public static string SaveGameProFolder = BayatGamesFolder + "/SaveGamePro";
        public static string IntegrationFolder = SaveGameProFolder + "/Integrations";

    }

}