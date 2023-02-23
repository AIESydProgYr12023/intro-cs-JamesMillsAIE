using Raylib_cs;

namespace AIE47_AssetFolderScanning
{
    public static class Assets
    {
        private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public static Texture2D Find(string _id)
        {
            if(textures.ContainsKey(_id))
                return textures[_id];

            throw new FileNotFoundException($"Texture with ID '{_id}' does not exist!");
        }

        #region Loading Asset Handling
        public static void Load()
        {
            LoadAllOfType<Texture2D>(textures, "Textures", "png", Raylib.LoadTexture);
        } 

        private static void LoadAllOfType<ASSET_TYPE>(Dictionary<string, ASSET_TYPE> _assets, string _folder, string _extension, Func<string, ASSET_TYPE> _loadAction)
        {
            List<string> files = LocateFiles(_folder, _extension);

            foreach (string file in files)
            {
                string id = string.Concat($"{_folder}/", file.AsSpan(file.LastIndexOf(_folder, StringComparison.Ordinal) + _folder.Length + 1));
                id = id.Replace($".{_extension}", "").Replace('\\', '/');

                _assets.Add(id, _loadAction(file));
            }
        }

        private static List<string> LocateFiles(string _folder, string _extension)
        {
            List<string> files = new List<string>();

            string path = $"{Directory.GetCurrentDirectory()}\\{Path.Combine("Assets\\", _folder)}";

            // If the directory doesn't exist, we will ignore it.
            if(!Directory.Exists(path))
                return files;

            // Get all files within the directory that match the extension, considering sub folders
            foreach (string file in Directory.GetFiles(path, $"*.{_extension}", SearchOption.AllDirectories))
            {
                files.Add(file);
            }

            return files;
        }
        #endregion

        #region Unloading Asset Handling
        public static void Unload()
        {
            ClearMemoryFor<Texture2D>(textures, Raylib.UnloadTexture);
        }

        private static void ClearMemoryFor<ASSET_TYPE>(Dictionary<string, ASSET_TYPE> _assets, Action<ASSET_TYPE> _unloadFnc)
        {
            foreach (ASSET_TYPE asset in _assets.Values)
                _unloadFnc(asset);

            _assets.Clear();
        } 
        #endregion
    }
}
