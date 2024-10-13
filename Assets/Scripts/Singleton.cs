using UnityEngine;

namespace Source
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        // Property to access the singleton instance
        public static T Instance
        {
            get
            {
                // If the instance is null, try to find an existing instance in the scene
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();

                    // If no instance is found, create a new GameObject and add the component
                    if (instance == null)
                    {
                        GameObject obj = new GameObject(typeof(T).Name);
                        instance = obj.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        protected virtual void Awake()
        {
            // Ensure there is only one instance of this class
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject); 
            }
            else
            {
                Destroy(gameObject); // If another instance already exists, destroy this one
            }
        }
    }
}