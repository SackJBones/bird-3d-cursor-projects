# Bird World feasibility project

Open with **Unity 2022.3.22f1**. Created through the official VPM CLI from the World template; Worlds/Base SDK versions are pinned in `Packages/vpm-manifest.json` (3.10.5). This is the beginning of a feasibility world, not a working Bird world.

On a fresh checkout, restore the VPM dependencies through Creator Companion or `vpm resolve project <absolute BirdWorld path>`. The official VPM resolver is included as supplied by the template. SDK directories, Unity caches, logs and builds are not committed. Do not copy legacy Bird MonoBehaviours into a world and assume they execute under Udon.

The scaffold scene is `Assets/BirdWorld/Scenes/BirdFeasibility.unity`: a floor, spawn point, world descriptor, light and orientation landmark. Its generator is maintained in the lightweight repository at `tests/UnityVRChatWorldChecks.cs`. To generate it in a new dedicated SDK project, copy that file into `Assets/BirdGenerated/Editor`, then launch Unity in batch mode with `-executeMethod UnityVRChatWorldChecks.Run`. It refuses to overwrite an existing scene. The copied editor script is ignored here; edit the lightweight source instead.

Next: add a UdonSharp hand-data diagnostic, compile it with the real SDK, and check it in ClientSim before a client/headset test. Missing avatar bones, fingertip estimation, scale and actual tracking quality require explicit handling. No world has been uploaded, no VRChat account login has been performed, and no multiplayer or physical hand validation has passed.

The separately installed **Bird Quest Smoke** APK is a synthetic standalone Unity deployment test, not this VRChat world.

Setup references: [official VPM CLI](https://vcc.docs.vrchat.com/vpm/cli/), [VRChat editor version](https://creators.vrchat.com/sdk/upgrade/current-unity-version/).


## Hand-data diagnostic

`Assets/BirdWorld/Scenes/BirdHandProbe.unity` adds a local-only UdonSharp availability probe with 32 initially hidden, collider-free avatar-bone markers and a world-space status label. It is not a Bird solver. Before opening this scene from a fresh checkout, copy `BirdHandDataProbe.cs` **and its .meta** from the lightweight repository's `Integrations/VRChat` into `Assets/BirdGenerated/Runtime/`, then compile UdonSharp. The program asset keeps a stable reference to that script GUID; generated source copies and serialized bytecode are ignored here. See the lightweight integration README for complete setup and limitations.

The reusable generator/checker is `tests/UnityVRChatProbeChecks.cs` in the lightweight repository. Its `Run` entry point creates a new probe scene without overwriting one; `ValidateSaved` reopens an existing scene and checks the saved marker, label and compiled-program references. Compilation and saved-reference validation do not establish ClientSim or device behavior.
