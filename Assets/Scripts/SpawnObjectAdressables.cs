using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.IO;

public class SpawnObjectAdressables : MonoBehaviour
{   //Spawn Ambiente using T and Unload using U
    [SerializeField] private AssetReferenceGameObject assetReferenceGameObject;

    private GameObject spawnedGameObject;
    bool canCreate = true;
    
    private void Start()
    {
        var myAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath,"buildings"));
        if(myAssetBundle == null)
        {
            Debug.Log("Failed!");
            return;
        }
        var prefab = myAssetBundle.LoadAsset<GameObject>("Ambiente");
        Instantiate(prefab);

        myAssetBundle.Unload(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && canCreate == true)
        {
            assetReferenceGameObject.InstantiateAsync().Completed += (AsyncOperation) => spawnedGameObject = AsyncOperation.Result;
            canCreate = false;
        }
        if (Input.GetKeyDown(KeyCode.U) && canCreate == false)
        {
            assetReferenceGameObject.ReleaseInstance(spawnedGameObject);
            canCreate = true;
        }
    }
}
