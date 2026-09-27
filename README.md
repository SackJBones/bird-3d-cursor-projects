# bird-3d-cursor

> Current modernization branch: `BirdWorld/Assets/BirdWorld/Scenes/BirdTrackingLab.unity`
> is a Unity 2022.3.22f1 VRChat lab with calibrated avatar-finger Bird input,
> separate estimated-tip/point presentation and a point-through target. Lab 05
> corrects the backwards palm normal and adds a togglable X-ray fitted sphere,
> center, fit ray and resulting Bird ray/diamond. It starts RAW, with legacy
> filtering available on a native control. See the light repository checkpoint
> for final checks and device evidence; physical feel, click fidelity and online
> publishing remain separate.
> Maintained sources, restore/build helpers and the detailed checkpoint are in
> the sibling `bird-3d-cursor` repository under `Integrations/VRChat`, `tests`
> and `docs/modernization`. The historical descriptions below concern the older
> Oculus demos. Standalone Bird Live Hands remains v0.10.


The Bird is a tool for controlling a point in 3D space using one hand, designed for use in virtual reality. It's like pointing at things with a ray cast, but you can control how far away they are.

*This repository contains two full Unity projects, each with a demo scene, for use with version 2020.3.33f1. The two core scripts, Bird.cs and BirdInteractable.cs, may be downloaded individually and used independently in any Unity project. They are also in this repository's top-level directory for convenience. Also because repo big. :)*

## Description

*NOTE: This asset only works for Oculus Quest hand tracking through the OVR SDK!*


**What is the "Bird"?**

The Bird is a tool for controlling a point in 3D space using one hand, designed primarily for use in virtual reality. The Bird stays directly in front of the user's palm, and can be sent farther away or brought closer by extending and closing the fingers. As with a 2D computer mouse, the pointer finger is reserved for selecting. You can use it to pick stuff up, and put it anywhere else.

**Why is it called that?**

The name Bird stems from its similarity to a computer mouse, named for an animal occupying the ground, evolved with the addition of a third degree of freedom into an animal occupying the air.

**How does it work?**

We use the Oculus OVR SDK to track the points of the hand. Then, using the position of each tracked point of the fingers, we do some math to determine a "sphere of best fit" across all of your fingers. The distance of the Bird from the hand is determined by the position of the center of the sphere.

**Do I have to understand that math to use it?**

No.

*Demo for Oculus Quest 2 only.*
Depends on Oculus OVR SDK:
https://developer.oculus.com/downloads/package/unity-integration
For more information, see the MIT Masters Thesis that forms the basis of this work: https://dspace.mit.edu/handle/1721.1/142815
