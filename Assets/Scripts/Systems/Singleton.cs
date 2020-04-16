using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SysObj = System.Object;

public abstract class Singleton<T> : BaseBehaviour where T : BaseBehaviour
{
	private const String SINGLETON_OBJECTNAME = "[SINGLETON]";
	private const String SINGLETON_SCENE = "[SINGLETON]";

	private static volatile T instance;

	protected static readonly SysObj Sync = new SysObj ();

	public static T Instance
	{
		get
		{
			if (!instance)
			{
				lock (Sync)
				{
					instance = FindObjectOfType<T> ();

					if (!instance)
					{
						var temp = GameObject.Find (SINGLETON_OBJECTNAME);
						//var scene = SceneManager.GetSceneByName(SINGLETON_SCENE);

						//if (!(scene.buildIndex == -1 && scene.isLoaded && (String.Compare(scene.path, String.Empty) == 0)))
						//{
						//	scene = SceneManager.CreateScene(SINGLETON_SCENE);
						//}

						//if (temp)
						//{
						//	if (temp.scene != scene)
						//	{
						//		SceneManager.MoveGameObjectToScene(temp, scene);
						//	}
						//}

						if (!temp)
						{
							temp = new GameObject (SINGLETON_OBJECTNAME);
							//SceneManager.MoveGameObjectToScene(temp, scene);
						}

						DontDestroyOnLoad (temp);
						instance = temp.AddComponent<T> ();
					}
				}
			}

			return instance;
		}
	}

	protected virtual void OnInitialize () { }

	public static void Initialize () => (Instance as Singleton<T>).OnInitialize ();
}