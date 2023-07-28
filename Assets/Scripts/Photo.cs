using System.Collections;
using UnityEngine;

/// <summary>
/// A class responsible for managing photos, including their ejection over a certain period of time and setting their image texture.
/// </summary>
[RequireComponent(typeof(ApplyPhysics))]
public class Photo : MonoBehaviour
{
    /// <summary>
    /// The MeshRenderer of the image.
    /// </summary>
    public MeshRenderer imageRenderer = null;

    /// <summary>
    /// The current collider of the photo.
    /// </summary>
    private Collider currentCollider = null;

    /// <summary>
    /// The ApplyPhysics component of the photo.
    /// </summary>
    private ApplyPhysics applyPhysics = null;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        currentCollider = GetComponent<Collider>();
        applyPhysics = GetComponent<ApplyPhysics>();
    }

    /// <summary>
    /// Start is called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        StartCoroutine(EjectOverSeconds(1.5f));
    }

    /// <summary>
    /// Eject the photo over a certain number of seconds.
    /// </summary>
    /// <param name="seconds">The number of seconds over which to eject the photo.</param>
    /// <returns>An IEnumerator for use in a coroutine.</returns>
    public IEnumerator EjectOverSeconds(float seconds)
    {
        applyPhysics.DisablePhysics();
        currentCollider.enabled = false;

        float elapsedTime = 0;
        while (elapsedTime < seconds)
        {
            transform.position += transform.forward * Time.deltaTime * 0.1f;
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        currentCollider.enabled = true;
    }

    /// <summary>
    /// Set the image texture of the photo.
    /// </summary>
    /// <param name="texture">The texture to set.</param>
    public void SetImage(Texture2D texture)
    {
        imageRenderer.material.color = Color.white;
        imageRenderer.material.mainTexture = texture;
    }

    /// <summary>
    /// Enable physics for the photo and unparent it from its current parent.
    /// </summary>
    public void EnablePhysics()
    {
        applyPhysics.EnablePhysics();
        transform.parent = null;
    }
}
