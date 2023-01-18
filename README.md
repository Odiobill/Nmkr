# Nmkr
Nmkr.cs is a component that helps accessing the Nmkr-Studio API from Unity.

It implements all the current endpoints and schemas as documented at the official API swagger: https://studio-api.nmkr.io/swagger/index.html

### Dependencies
You need to install the open-source RestClient for Unity from Projecto26: https://github.com/proyecto26/RestClient
It is also available in the asset-store: https://assetstore.unity.com/packages/tools/network/rest-client-for-unity-102501

### Warning
I implemented all the available API calls, but I tested only a few of them: the ones I need for the project I'm currently working on.
There may be bugs and typos in the code, and there is a lot of room for improvements. PRs are welcome.

### How to use it
- Add an empty GameObject
- Add the Nmkr component to it
- Fill up the *Nmkr Key* parameter with your Nmkr Studio API key
- Reference the Nmkr component from your scripts using this object, then call methods with the same name as the API endpoints

The REST calls are async and non-blocking. You can use the *Busy* and *Result* properties to check if the operation has been completed and retrieve the results.
Usually this is done either with a coroutine or by providing a callback function.

When accessing the Result property, please remember to cast it to the actual class (schema) that the endpoint returns.
It's not a very elegant solution, but it's lightweight and works perfectly fine.

### Example

```
public class NmkrExample : MonoBehaviour
{
    public Nmkr nmkr; // Remember to drag the Nmkr object here...
    public string projectId; // Insert your Nmkr project ID

    void GetCountsCallback()
    {
        Nmkr.NftCountsClass nftCountsClass = (Nmkr.NftCountsClass)nmkr.Result;
        Debug.Log($"Total: {nftCountsClass.nftTotal}");
    }

    IEnumerator GetCounts()
    {
        nmkr.GetCounts(projectId);
        while (nmkr.Busy)
        {
            yield return null;
        }

        Nmkr.NftCountsClass nftCountsClass = (Nmkr.NftCountsClass)nmkr.Result;
        Debug.Log($"Total: {nftCountsClass.nftTotal}");
    }

    void Start()
    {
        // You can either do this...
        StartCoroutine(GetCounts());

        // or that...
        nmkr.GetCounts(projectId, GetCountsCallback);
    }
}
```
