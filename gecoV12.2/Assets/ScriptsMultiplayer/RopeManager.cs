using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RopeManager : MonoBehaviour
{
    PhotonView view;
    private Dictionary<GameObject, GameObject> gBindings; // Store G keybind bindings
    private Dictionary<GameObject, GameObject> hBindings; // Store H keybind bindings
    public GameObject ropePrefab;

    private void Awake()
    {
        gBindings = new Dictionary<GameObject, GameObject>();
        hBindings = new Dictionary<GameObject, GameObject>();
    }

    private void Update()
    {

    }

    public void HandleBindInput(KeyCode key)
    {
        Debug.Log("aqui");
        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");
        // Check if the currentPlayer is already bound to another player
        if (key == KeyCode.G && gBindings.ContainsKey(currentPlayer))
        {
            BreakRopeBinding(currentPlayer, key);
        }
        else if (key == KeyCode.H && hBindings.ContainsKey(currentPlayer))
        {
            BreakRopeBinding(currentPlayer, key);
        }
        else
        {
            Debug.Log("dentro de bind");
            GameObject targetPlayer = FindInteractablePlayer();

            // If there is a valid target player, establish a new rope bind
            if (targetPlayer != null)
            {
                Debug.Log("encontro player");
                EstablishRopeBinding(currentPlayer, targetPlayer, key);
            }
        }
    }

    private GameObject FindInteractablePlayer()
    {
        Debug.Log("aqui find player");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 9f); // Adjust the radius as needed
        foreach (Collider2D collider in colliders)
        {
            GameObject player = collider.gameObject;
            if (player.CompareTag("Player") && !player.GetComponent<PhotonView>().IsMine  && (!gBindings.ContainsValue(player) || !hBindings.ContainsValue(player)))
            {
                return player;
            }
        }
        return null;
    }
/*
    private void EstablishRopeBinding(GameObject currentPlayer, GameObject targetPlayer, KeyCode key)
    {
        if (key == KeyCode.G)
        {
            gBindings.Add(currentPlayer, targetPlayer);
            Debug.Log(currentPlayer.name + " is now bound to " + targetPlayer.name + " using G keybind.");
        }
        else if (key == KeyCode.H)
        {
            hBindings.Add(currentPlayer, targetPlayer);
            Debug.Log(currentPlayer.name + " is now bound to " + targetPlayer.name + " using H keybind.");
        }
    }
*/
    private void EstablishRopeBinding(GameObject currentPlayer, GameObject targetPlayer, KeyCode key)
    {
        Debug.Log("aqui estb bind");
        if (key == KeyCode.G)
        {
            gBindings.Add(currentPlayer, targetPlayer);
            Debug.Log(currentPlayer.name + " is now bound to " + targetPlayer.name + " using G keybind.");

            // Spawn the rope prefab and pass player references
            GameObject ropeObject = PhotonNetwork.Instantiate(ropePrefab.name, currentPlayer.transform.position, Quaternion.identity);
            RopeScript ropeScript = ropeObject.GetComponent<RopeScript>();
            ropeScript.ConnectPlayers(currentPlayer, targetPlayer);
        }
        else if (key == KeyCode.H)
        {
            hBindings.Add(currentPlayer, targetPlayer);
            Debug.Log(currentPlayer.name + " is now bound to " + targetPlayer.name + " using H keybind.");

            // Spawn the rope prefab and pass player references
            GameObject ropeObject = Instantiate(ropePrefab, currentPlayer.transform.position, Quaternion.identity);
            RopeScript ropeScript = ropeObject.GetComponent<RopeScript>();
            ropeScript.ConnectPlayers(currentPlayer, targetPlayer);
        }
    }

    private void BreakRopeBinding(GameObject currentPlayer, KeyCode key)
    {
        if (key == KeyCode.G)
        {
            if (gBindings.ContainsKey(currentPlayer))
            {
                GameObject targetPlayer = gBindings[currentPlayer];

                // Destroy the rope object associated with the binding
                DestroyRopeObject(currentPlayer, targetPlayer);

                // Remove the binding from the dictionary
                gBindings.Remove(currentPlayer);

                Debug.Log(currentPlayer.name + " broke the G keybind with " + targetPlayer.name + ".");
            }
        }
        else if (key == KeyCode.H)
        {
            if (hBindings.ContainsKey(currentPlayer))
            {
                GameObject targetPlayer = hBindings[currentPlayer];

                // Destroy the rope object associated with the binding
                DestroyRopeObject(currentPlayer, targetPlayer);

                // Remove the binding from the dictionary
                hBindings.Remove(currentPlayer);

                Debug.Log(currentPlayer.name + " broke the H keybind with " + targetPlayer.name + ".");
            }
        }
    }

    private void DestroyRopeObject(GameObject player1, GameObject player2)
    {
        // Find the rope object that connects the two players
        RopeScript[] ropeObjects = FindObjectsOfType<RopeScript>();

        foreach (RopeScript ropeScript in ropeObjects)
        {
            if ((ropeScript.player1Rigidbody == player1.GetComponent<Rigidbody2D>() && ropeScript.player2Rigidbody == player2.GetComponent<Rigidbody2D>()) ||
                (ropeScript.player1Rigidbody == player2.GetComponent<Rigidbody2D>() && ropeScript.player2Rigidbody == player1.GetComponent<Rigidbody2D>()))
            {
                // Destroy the rope joints
                Destroy(ropeScript.distanceJoint1);
                Destroy(ropeScript.distanceJoint2);

                // Destroy the rope object
                Destroy(ropeScript.gameObject);
                break;
            }
        }
    }
}

