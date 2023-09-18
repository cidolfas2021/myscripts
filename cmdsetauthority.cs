using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Mirror;

public class cmdsetauthority : NetworkBehaviour
{
    [Command]
    void CmdSetAuthority(NetworkIdentity grabID, NetworkIdentity playerID)
    {
        grabID.AssignClientAuthority(connectionToClient);
    }
}