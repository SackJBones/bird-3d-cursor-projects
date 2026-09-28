# Beacon targeting preview, 2026-09-28

Six runtime camera renders show arrival separation, water-to-upper sightlines,
the constrained lookout-to-water return, an honest inboard lookout view, and
actual idle/hover ring colors. These are compiled-Udon ClientSim renders, not
headset images. The same folder contains platform check/build results and exit
codes. `device-observation.json` records a separate inspected Quest capture;
raw device images and logs stay in ignored Validation storage.

The saved scene contains five beacons with two after-IK logical pointer adapters.
The normal SDK audit reports 340 GameObjects, 1021 components, 27 unsynced Udon
programs and one manual per-player social stream; no persistence, missing
components or project MonoBehaviours survive export. Finger clicks and saved
teleport permission remain off. Explicit test presses exercise local travel
only in runtime fixtures.

The rings, torus mesh and material are original project assets; no external
assets or new licenses were introduced. Existing architecture and collision
meshes were not changed. Edit the saved travel-network prefab and scene
bindings rather than rerunning its one-time authoring command.

The first development pass exposed a temporary construction object saved beside
the prefab, a landing on threshold steps, and obstructed upper sightlines.
Those were corrected before export. Saved-scene uniqueness and the supported
landing checks protect the resulting contract. Private development logs retain
those failures; these final files do not claim a first-attempt success.

Independent critic accepts the bounded targeting preview. Addition scores:
6.5 aesthetics, 5.5 discoverability/navigation, 7 hangout fit, 6 preview usability.
Full-world scores remain 6/8/6.5/6.5. The water return is partly obscured from
the near-edge raised-hand stance and invisible from the inboard view. It is not
yet a comfortably discoverable ordinary click-travel network. Next placement
work should expose that target without removing guards or compromising landings.

Physical clicking, active-device performance and multiplayer acceptance remain
separate. The older Windows combined coastal scene/capture shutdown defect was
not exercised or resolved by these focused beacon checks. Reproduction and API
details are in the lightweight repository's `docs/modernization/TELEPORT-BEACONS.md`.
