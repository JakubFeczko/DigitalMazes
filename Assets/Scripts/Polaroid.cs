using UnityEngine;

/// <summary>
/// This class manages the functionality of a Polaroid camera, including taking photos and creating render textures.
/// </summary>
public class Polaroid : MonoBehaviour
{
    /// <summary>
    /// The prefab to use for photos.
    /// </summary>
    public GameObject photoPrefab = null;

    /// <summary>
    /// The MeshRenderer used for the screen.
    /// </summary>
    public MeshRenderer screenRenderer = null;

    /// <summary>
    /// The location at which photos should spawn.
    /// </summary>
    public Transform spawnLocation = null;

    /// <summary>
    /// The camera used for rendering.
    /// </summary>
    private Camera renderCamera = null;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        renderCamera = GetComponentInChildren<Camera>();
    }

    /// <summary>
    /// Start is called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        CreateRenderTexture();
        TurnOff();
    }

    /// <summary>
    /// Create a new RenderTexture and assign it to the render camera and screen material.
    /// </summary>
    private void CreateRenderTexture()
    {
        RenderTexture newTexture = new RenderTexture(256, 256, 32, RenderTextureFormat.Default, RenderTextureReadWrite.sRGB);
        newTexture.antiAliasing = 4;

        renderCamera.targetTexture = newTexture;
        screenRenderer.material.mainTexture = newTexture;
    }

    /// <summary>
    /// Take a photo using the Polaroid camera.
    /// </summary>
    public void TakePhoto()
    {
        Photo newPhoto = CreatePhoto();
        SetPhotoImage(newPhoto);
    }

    /// <summary>
    /// Create a new photo at the spawn location.
    /// </summary>
    /// <returns>The Photo component of the new photo.</returns>
    private Photo CreatePhoto()
    {
        GameObject photoObject = Instantiate(photoPrefab, spawnLocation.position, spawnLocation.rotation, transform);
        return photoObject.GetComponent<Photo>();
    }

    /// <summary>
    /// Set the image of a photo using the render camera.
    /// </summary>
    /// <param name="photo">The photo for which to set the image.</param>
    private void SetPhotoImage(Photo photo)
    {
        Texture2D newTexture = RenderCameraToTexture(renderCamera);
        photo.SetImage(newTexture);
    }

    /// <summary>
    /// Render the camera view to a Texture2D.
    /// </summary>
    /// <param name="camera">The camera to render.</param>
    /// <returns>A Texture2D of the camera view.</returns>
    private Texture2D RenderCameraToTexture(Camera camera)
    {
        camera.Render();
        RenderTexture.active = camera.targetTexture;

        Texture2D photo = new Texture2D(256, 256, TextureFormat.RGB24, false);
        photo.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        photo.Apply();

        return photo;
    }

    /// <summary>
    /// Turn on the Polaroid camera.
    /// </summary>
    public void TurnOn()
    {
        renderCamera.enabled = true;
        screenRenderer.material.color = Color.white;
    }

    /// <summary>
    /// Turn off the Polaroid camera.
    /// </summary>
    public void TurnOff()
    {
        renderCamera.enabled = false;
        screenRenderer.material.color = Color.black;
    }
}
