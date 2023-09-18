using UnityEngine;
// This complete script can be attached to a camera to make it
// continuously point at another object.

public class mechtarget: MonoBehaviour
{
    public Transform target;
    public Entity entity;
    void Update()
    {
        Player player = Player.localPlayer;
        // Rotate the camera every frame so it keeps looking at the target
        entity.transform.LookAt(target);

        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
        entity.transform.LookAt(player.target.transform.position);
    }
}