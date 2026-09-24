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


ClientSim checkpoint (2026-09-24 UTC): the real running probe reports 16/16 bones per hand on the default desktop avatar and its Udon counts agree with marker visibility. The lifecycle harness currently fails automatic disable cleanup; directly dispatching the compiled cleanup event works. The root cause is still under investigation. See lightweight tests/UnityClientSimProbeChecks.cs and the modernization checkpoint. No physical hand-tracking claim follows from desktop avatar bone availability.


Explicit probe controls are now tested in ClientSim: send PauseProbe to stop sampling and clear markers/counts, and ResumeProbe to restart. Use pause before deactivation when the status label must clear. The frame-based automatic-disable diagnostic remains separate; its status is recorded in the lightweight checkpoint. Generated validation helpers now belong in Assets/BirdGenerated/Runtime under UNITY_EDITOR guards, not the Editor folder.


Controlled missing-avatar recovery also passes in ClientSim: UnityClientSimProbeChecks.RunMissingBones temporarily removes the local simulator avatar animator reference, verifies SDK zero positions for all 32 sampled bones and Udon marker/count/label clearing, then restores the reference and verifies 16/16 availability per hand. This SDK-specific runtime fixture saves no scene changes and does not establish actual avatar-switch, selective missing-bone, scale or physical tracking-loss behavior. See the lightweight tests README for reproduction.


ClientSim scaling also passes via UnityClientSimProbeChecks.RunScale: runtime eye height 1.9 -> 0.95 -> 2.85 -> 1.9 m, all 32 Udon markers matching SDK bone positions within 2 mm, wrist-relative lengths scaling/recovering, and counts remaining 16/16 per hand. This proves probe following on the simulator avatar; it does not establish solver calibration, real avatar changes or hardware tracking. Original eye height is restored and no scene/global preferences are saved.


The lightweight integration now also contains BirdSphereFit.cs and its stable meta: a caller-fed Udon sphere fitter, separate from the hand probe. Its UnityUdonSphereFitChecks.Run fixture passes 18 synthetic cases through compiled Udon, including original algebraic-reference agreement and invalid/degenerate recovery. Restore the source/meta and editor-only helper to Assets/BirdGenerated/Runtime as described in the lightweight integration README. The test creates an ignored program asset and unsaved object; the authored world scenes do not yet contain a fitted cursor or click interaction.


BirdCursorState now composes the fitter with the original unfiltered range law and click hysteresis. UnityUdonCursorChecks.Run passes 51 compiled-Udon assertions using two independent, temporary synthetic cursor instances. Restore cursor/fitter sources and metas plus the editor-only helper to Assets/BirdGenerated/Runtime; see the lightweight integration README for setup and sample-pulse semantics. This is unsmoothed caller-fed state, not an authored visible demo, avatar input integration or physical tracking validation.


## Visible synthetic demo

Open Assets/BirdWorld/Scenes/BirdSyntheticDemo.unity for two labeled automatic cursors, cyan/pink tapered trails and gold press feedback with click counters. Before opening a fresh checkout, restore BirdSphereFit.cs, BirdCursorState.cs, BirdSyntheticDemo.cs and their stable metas from the lightweight Integrations/VRChat folder into Assets/BirdGenerated/Runtime, then compile UdonSharp. Each trail is capped at 64 points. These are synthetic tetrahedral poses, not tracked hands; there is no avatar input, filtering or multiplayer synchronization yet.

Reusable generator/validator: lightweight tests/UnityUdonDemoChecks.cs. Generate refuses existing scene/program assets; Validate reopens the scene in ClientSim, checks clicks/bounded trails/pause/recovery, and captures a camera image with only authored demo visuals (temporarily excludes simulator avatar/UI). Validation does not bypass or acknowledge the simulator disclaimer and does not change global preferences. A normal interactive Play session may require accepting ClientSim's introductory panel. No VRChat upload/client test is implied.


The synthetic demo now has local PAUSE/RESUME and CLEAR TRAILS interaction buttons (3 m proximity). Clear preserves click counters and pause state. Restore the fourth source/meta pair, BirdDemoControl, together with BirdSphereFit, BirdCursorState and BirdSyntheticDemo on fresh checkout. Reproduction order: Generate, AddControls, Validate; AddControls refuses duplicate upgrades. Compiled Interact handler checks are separate from physical pointer/controller activation and in-headset usability.


Both saved synthetic cursor instances now enable optional Kalman smoothing. The Udon recurrence uses Bird's Q=0.001 and distance-dependent R=270*d^3; first input and recovery after loss/cancel seed directly at the new measurement. This intentionally differs from the legacy zero/stale initialization. The cursor fixture passes 97 compiled-Udon assertions including comparison with the original C# filter and synthetic jitter/recovery checks. Copy the original KalmanFilterVector3.cs into the ignored generated runtime directory only when running that comparison fixture; production Udon does not depend on it. To reproduce the smoothed scene after Generate/AddControls, run EnableSmoothing before Validate. Physical comfort, sample-rate tuning and avatar input remain unvalidated.


Experimental avatar input is available in the lightweight BirdAvatarInput source and UnityAvatarInputChecks fixture, but is not wired into this synthetic scene. Default ClientSim avatar bones mapped correctly and recovered from controlled missing-avatar data, yet produced roughly 1.25 km cursor ranges under the existing range law. The adapter rejects results above a configurable 3 m preview limit and disables clicks because distal bones are not fingertips. Avatar calibration is required before enabling an end-user mode; no hand-tracking claim follows. BirdCursorState now exposes clicksAllowed (default true) so an approximate input source can suppress/release clicks explicitly.
