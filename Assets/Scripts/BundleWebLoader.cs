using System.Collections;
using UnityEngine;

public class BundleWebLoader : MonoBehaviour
{
    public string bundleUrl ;
    public string assetName ;
    public GameObject parentObj;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        using (WWW web = new WWW(bundleUrl))
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if (remoteAssetBundle == null)
            {
                Debug.LogError("Failed to download AssetBundle!");
                yield break;
            }
            GameObject ob=Instantiate(remoteAssetBundle.LoadAsset(assetName)) as GameObject;
            ob.transform.parent = parentObj.transform;
            ob.transform.position = new Vector2(1600, 250);
            remoteAssetBundle.Unload(false);
        }
    }


}