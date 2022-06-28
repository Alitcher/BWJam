using UnityEngine;

public abstract class GenericSingleton : MonoBehaviour
{
    public abstract void Destroy();
}

public class GenericSingleton<T> : GenericSingleton where T : MonoBehaviour
{
    private static bool isDestroyed = false;
    private static T instance = null;

    public static T I
    {
        get
        {
            if (isDestroyed)
            {
                return null;
            }

            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (FindObjectsOfType(typeof(T)).Length > 1)
                {
                    print("has duplicated singleton");
                    return instance;
                }

                if (instance == null)
                {
                    //GameObject singleton = new GameObject();
                    //instance = singleton.AddComponent<T>();
                    //singleton.name = instance.GetType().Name;
                }
            }

            return instance;
        }

        private set { instance = value; }
    }

    public static bool HasInstance { get { return instance != null; } }

    public virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
        isDestroyed = false;
    }

    public virtual void OnDestroy()
    {
        if (instance == this)
        {
            isDestroyed = true;
        }
    }

    public override void Destroy()
    {
        instance = null;
        Destroy(gameObject);
    }
}
