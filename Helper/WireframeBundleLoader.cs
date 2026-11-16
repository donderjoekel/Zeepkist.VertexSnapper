// C#

using System.IO;
using UnityEngine;

namespace VertexSnapper.Helper;

public static class WireframeBundleLoader
{
    // The bundle is embedded in the DLL (see Zeepkist.VertexSnapper.csproj), so loading doesn't depend on
    // how the mod's zip was packed or extracted (e.g. backslash paths breaking assets/ on Linux).
    private const string BundleResourceName = "VertexSnapper.RuntimeAssets.wireframe";

    private static AssetBundle _bundle;

    public static Material WireframeMaterial { get; private set; }

    // Call once (e.g., on entering editor/tools mode)
    public static bool InitWireframeMaterial()
    {
        if (_bundle)
        {
            return true;
        }

        using (Stream stream = typeof(WireframeBundleLoader).Assembly.GetManifestResourceStream(BundleResourceName))
        {
            if (stream == null)
            {
                Debug.LogError("[Wireframe] Embedded AssetBundle resource not found: " + BundleResourceName);
                return false;
            }

            using (MemoryStream buffer = new MemoryStream())
            {
                stream.CopyTo(buffer);
                _bundle = AssetBundle.LoadFromMemory(buffer.ToArray());
            }
        }

        if (!_bundle)
        {
            Debug.LogError("[Wireframe] Failed to load the embedded AssetBundle " + BundleResourceName);
            return false;
        }

        // Option A: material exported (recommended)
        if (!WireframeMaterial)
        {
            // If you know the exact asset name, use: _bundle.LoadAsset<Material>("WireframeMat");
            foreach (Material mat in _bundle.LoadAllAssets<Material>())
            {
                WireframeMaterial = mat;
                break;
            }
        }

        // Option B: only a shader exported
        if (!WireframeMaterial)
        {
            Shader wireShader = null;
            foreach (Shader sh in _bundle.LoadAllAssets<Shader>())
            {
                wireShader = sh;
                break;
            }

            if (wireShader)
            {
                WireframeMaterial = new Material(wireShader) { name = "Wireframe_Material_Runtime" };
            }
        }

        if (!WireframeMaterial)
        {
            Debug.LogError("[Wireframe] No Material or Shader found in bundle.");
            return false;
        }


        if (!WireframeMaterial)
        {
            return false;
        }

        WireframeMaterial = new Material(WireframeMaterial);
        return true;
    }
}