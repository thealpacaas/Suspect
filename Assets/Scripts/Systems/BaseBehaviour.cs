using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBehaviour : MonoBehaviour
{
	private GameObject savedGameObject;
	private Transform savedTransform;

	protected Boolean IsQuitting { get; private set; } = false;

	public GameObject GameObject
	{
		get
		{
			if (this.savedGameObject == null || this.savedGameObject != this.gameObject)
			{
				this.savedGameObject = this.gameObject;
			}

			return this.savedGameObject;
		}
	}

	public Transform Transform
	{
		get
		{
			if (this.savedTransform == null || this.savedTransform != this.transform)
			{
				this.savedTransform = this.transform;
			}

			return this.savedTransform;
		}
	}

	public static implicit operator GameObject (BaseBehaviour source) => source.GameObject;

	public static implicit operator Transform (BaseBehaviour source) => source.Transform;

	protected virtual void OnAwake () { }

	protected virtual void OnStart () { }

	protected virtual void OnReset () { }

	protected virtual void OnDeath () { }

	protected virtual void OnClose () { }

	protected virtual void OnState (Boolean enable) { }

	protected virtual void OnUpdateFrame (Single deltaTime) { }

	protected virtual void OnUpdateFrameLate (Single deltaTime) { }

	protected virtual void OnUpdatePhysics (Single deltaTime) { }

	public void SetActive (Boolean value) => this.GameObject.SetActive (value);

	public void SetActiveComponent<T> (Boolean value) where T : Behaviour
	{
		if (typeof (T) == typeof (GameObject))
		{
			this.SetActive (value);
			return;
		}

		this.GameObject.GetComponent<T> ().enabled = value;
	}

	public Component AddComponent (Type componentType) => this.GameObject.AddComponent (componentType);

	public Component [] AddComponents (Type componentType , Int32 count)
	{
		var result = new List<Component> ();

		for (var c = 0 ; c < count ; c++)
		{
			result.Add (this.GameObject.AddComponent (componentType));
		}

		return result.ToArray ();
	}

	public Component[] AddComponents (params Type [] componentTypes)
	{
		var result = new List<Component> ();

		for (var c = 0 ; c < componentTypes.Length ;c++)
		{
			result.Add (this.GameObject.AddComponent (componentTypes [c]));
		}

		return result.ToArray ();
	}

	public T AddComponent<T> () where T : Component => this.GameObject.AddComponent<T> ();

	public T[] AddComponents<T>(Int32 count) where T : Component
	{
		var result = new List<T> ();

		for (var c = 0 ; c < count ; c++)
		{
			result.Add (this.GameObject.AddComponent<T> ());
		}

		return result.ToArray ();
	}

	private void Awake () => this.OnAwake ();

	protected void Reset () => this.OnReset ();

	private void Start () => this.OnStart ();

	private void OnApplicationQuit () => this.OnClose ();

	private void OnDestroy () => this.OnDeath ();

	private void OnDisable () => this.OnState (false);

	private void OnEnable () => this.OnState (true);

	private void Update () => this.OnUpdateFrame (Time.deltaTime);

	private void LateUpdate () => this.OnUpdateFrameLate (Time.deltaTime);

	private void FixedUpdate () => this.OnUpdatePhysics (Time.deltaTime);
}