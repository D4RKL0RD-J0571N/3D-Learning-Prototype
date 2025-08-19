using Actors;
using Attributes;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }


    public Actor SpawnActor(GameObject actorPrefab)
    {

        var actorInstance = SpawnEntity(actorPrefab);

        if (!actorInstance.GetComponent<Actor>())
        {
            CustomUtilities.WriteLog($"[{GetType().Name}] {actorPrefab.name} is missing an actor component.");
            return null;
        }

        return actorInstance.GetComponent<Actor>();
    }

    public Actor SpawnActor(GameObject actorPrefab, Vector3 position, Quaternion rotation)
    {
        var actorInstance = SpawnEntity(actorPrefab, position, rotation, false);

        if (!actorInstance.GetComponent<Actor>())
        {
            CustomUtilities.WriteLog($"[{GetType().Name}] {actorPrefab.name} is missing an actor component.");
            return null;
        }

        return actorInstance.GetComponent<Actor>();
    }



    public Attribute SpawnAttribute(GameObject attributePrefab, bool remainActive)
    {
        var attributeInstance = SpawnEntity(attributePrefab, remainActive);

        if (!attributeInstance.GetComponent<Attribute>())
        {
            CustomUtilities.WriteLog($"[{GetType().Name}] {attributePrefab.name} is missing an attribute component.");
            return null;
        }

        return attributeInstance.GetComponent<Attribute>();
    }

    public Attribute SpawnAttribute(GameObject attributePrefab, Vector3 position, Quaternion rotation)
    {
        var attributeInstance = SpawnEntity(attributePrefab, position, rotation, false);
        if (!attributeInstance.GetComponent<Attribute>())
        {
            CustomUtilities.WriteLog($"[{GetType().Name}] {attributePrefab.name} is missing an attribute component.");
            return null;
        }

        return attributeInstance.GetComponent<Attribute>();
    }

    public Attribute SpawnAttribute(GameObject attributePrefab, Vector3 position, Quaternion rotation, Transform parent)
    {
        var attributeInstance = SpawnEntity(attributePrefab, position, rotation, parent, false);
        
        if (!attributeInstance.GetComponent<Attribute>())
        {
            CustomUtilities.WriteLog($"[{GetType().Name}] {attributePrefab.name} is missing an attribute component.");
            return null;
        }

        return attributeInstance.GetComponent<Attribute>();
    }

/// <summary>
    /// Spawn a copy of a prefab at 0,0,0, by default, the entity is active.
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="active"></param>
    /// <returns></returns>
    public GameObject SpawnEntity(GameObject prefab, bool active = true)
    {
        if (!prefab)
        {
            CustomUtilities.WriteLog($"[{GetType().Name}] Prefab is not assigned or invalid.");
            return null;
        }
        var instance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        CustomUtilities.WriteLog($"[{GetType().Name}] Spawned entity {instance.name} at {instance.transform.position}.");
        if (!active)
        {
            CustomUtilities.WriteLog($"[{GetType().Name}] Spawned entity {instance.name} deactivated.");
            instance.gameObject.SetActive(false);
        }
        return instance;
    }
    
    

    /// <summary>
    /// Spawn a copy of a prefab with positioning; by default, the entity is active. 
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <param name="active"></param>
    /// <returns></returns>
    public GameObject SpawnEntity(GameObject prefab, Vector3 position, Quaternion rotation, bool active = true)
    {
        if (!prefab)
        {
            CustomUtilities.WriteLog($"[{GetType().Name}] Prefab is not assigned or invalid.");
            return null;
        }
        var instance = Instantiate(prefab, position, rotation);
        CustomUtilities.WriteLog($"[{GetType().Name}] Spawned entity {instance.name} at {instance.transform.position}.");
        if (!active)
        {
            CustomUtilities.WriteLog($"[{GetType().Name}] Spawned entity {instance.name} deactivated.");
            instance.gameObject.SetActive(false);
        }
        return instance;
    }

    /// <summary>
    /// Spawn a copy of a prefab with positioning and parent hierarchy if any; by default, the entity is active. 
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <param name="active"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject SpawnEntity(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null, bool active = true
        )
    {
        if (!prefab)
        {
            CustomUtilities.WriteLog($"[{GetType().Name}] Prefab is not assigned or invalid.");
            return null;
        }
        var instance = Instantiate(prefab, position, rotation, parent);
        CustomUtilities.WriteLog($"[{GetType().Name}] Spawned entity {instance.name} at {instance.transform.position}.");
        if (!active)
        {
            CustomUtilities.WriteLog($"[{GetType().Name}] Spawned entity {instance.name} deactivated.");
            instance.gameObject.SetActive(false);
        }
        return instance;
    }
}