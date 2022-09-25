///PART OF SPHERE FIT BIRD
///Sphere Fit Bird is a collaboration between Dana Gretton (good at math) and
///Aubrey Simonson (his boyfriend, inventor) based on Aubrey's 2021 MIT Media Lab Thesis project, Bird.
///For more information on Bird, see: https://drive.google.com/file/d/1p6IUu9QIzWNBERz3IW_yVcojQjVz06rl/view?usp=sharing
///This project works with the OVR Toolkit, and once OpenXR is more stable, someone should probably make an OpenXR version.
/// 
/// TeleportToHere is a minor helper script which makes BirdBeacons work.
/// Essential for the demo scene, but not essential for most applications of bird.
/// 
///???---> asimonso@mit.edu/followspotfour@gmail.com // dgretton@mit.edu/dana.gretton@gmail.com
///Last edited May 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToHere : MonoBehaviour
{
    public GameObject player;

    public void TeleportHere()
    {
        //if your camera is using floor as reference for tracking, make origin of object be on floor.
        player.transform.position = gameObject.transform.position;
    }

    public void ReloadScene() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
