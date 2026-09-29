# Rail01 — quieter pond rails and finished ends

2026-09-29. The two existing pond/coast rail meshes now use continuous square
sweeps instead of overlapping short boxes. Their 0.10 m square section, 1.10 m
height and existing posts stay in place. Two exposed ends receive plain caps
and slim terminal posts directly beneath them. The paths and intended openings
are unchanged. There are no decorative caps, extra horizontal bars, new materials,
runtime scripts, lights or network streams. Bird controls and palettes are unchanged.

The independent critic recommended this treatment after Support01 because the
bright/dark blocks and unfinished tails were conspicuous in everyday pond views.
`Before` and `Candidate01-Unbaked` preserve the initial comparison. Candidate
lighting is explicitly stale; the baked results are the lighting evidence.

## Authoring and checks

The saved rail mesh GUIDs remain stable. The ordinary prefab's two renderers
use the same matte plaster with lightmap scale raised from 0.3 to 4. No global
lighting setting changes. This requests more lightmap space for narrow bars;
actual packed texel density is not measured and shadows still require review.
Mesh-only updates preserve lighting and other prefab Inspector choices.

The finish operation verifies identical bytes for five floor/water/fascia and
invisible player-boundary meshes. The renderer's MeshCollider remains an exact
visible pointing proxy on layer 17, separate from unchanged layer-2 walking
protection. Both endpoints stay within the original rail footprint.

Focused rail checks cover 3,828 triangles, 5,742 closed oriented edges, 349 top
path rays, 86 posts, 347 open spans and two capped/posted ends. They also cover
finite geometry, original vertical envelope, UV2/unit normals, material and
renderer lightmap scale, exact visible colliders and player layer policy. Compiled beacon
regression and pond/garden checks provide separate interaction/clearance evidence.

Seven comparison views include west approach, seated water, west terminal from
inland and outside, supported high return, east walk and seaward context. Views
04/07 are free cameras, not visitor stances. The Android inspection export uses
the existing western promenade spawn, with no temporary footing. It follows
ordinary SDK validation and restores the production scene exactly.

Physical gestures, comfort, client walking and multiplayer remain separate
acceptance; avatar click and teleport gates stay off. Raw device images/logs
remain ignored/private. Final platform, bake, critic and Quest results follow.

## Baked review and scope

The independent reviewer retains Rail01. The alternating gray patches on the
pond/coast rails are materially reduced in the seated and east-approach views.
The plain capped ends and slim posts look deliberate without adding bulk.
Fish, water and beacon sightlines remain visible; the upper lookout's foreground
rail joints in view 05 are unchanged and outside this pass.

Whole-world ratings remain **6.5 aesthetics / 8 navigability / 7 hangout
suitability / 6.5 overall**. The target of at least eight in every category is
not met. The next bounded recommendation is the doubled/overlapping beacon
label visible from the east approach, also present in the Before capture.
Fix its front/back visibility and contrast while preserving targeting behavior.
All rail geometry in this pass is original project art; no external assets added.

The fresh bake has two non-directional lightmaps and 219 probes, with 177
receivers. UV-overlap warnings fall from 142 to 140 objects; neither pond rail
is listed in this bake's warning report. Remaining warnings are retained in
`uv-overlap-warnings.txt` and are not claimed resolved.

## Platform validation

Android and Windows pass the focused rail checks, 319 pond floor/standing
samples, 194 submerged side-closure rays, 3,024 supported furniture vertices,
223 approach samples at three heights, 35 seated-water sightlines and the
lighting check. Compiled Udon beacon checks pass 343 assertions on Android and
345 on Windows over 194 frames each, using explicit pointer/depth fixtures.
They exercise rail-gap targeting, player guards, landing/headroom, click-practice
lifecycle and gated travel. These do not establish real finger-click acceptance.
The full normal-frame walker was not repeated; floor and player-guard meshes
were verified byte-identical by the one-time finish operation.

Both production builds and the separate Android promenade inspection pass the
normal SDK export, compressed/uncompressed size gates, processed-scene audit
and bundle catalog checks, all with exit code zero. Each has 427 objects, 1,301
components, 29 unsynced Udon programs and one manual per-player stream. Exact
artifact sizes and SHA256 hashes are in `builds.json`. There is no upload,
client/SDK patch, validation bypass or account change in this cycle.

The inspection source was restored exactly. After Windows export and Android
setup, the SDK's unordered DynamicMaterials permutation was verified before
restoring source order. A final comparison to the initial clean checkout
proved that its only remaining scene difference was also that permutation;
the original scene order was restored to avoid unrelated churn. The saved
rail assets, prefab and bake carry this change. `inspection-restoration.json`
records the stages; Android is the final active target.

## Actual Quest inspection

The first inspection launch and read-only follow-up showed Connecting. One
ordinary cold relaunch then visibly rendered the western promenade in both
eyes in actual VRChat, captured during the 07:06 UTC observation. The continuous
rail, terminal post, water and fish are visible. The existing fallback/error
avatar partly overlaps the scene and the fixed headset tilt limits inspection.
This export starts on the real promenade, without temporary inspection geometry.

The transferred inspection SHA256 matches its source. Battery is 77%, AC powered,
weak charger false, 40 C. Six recent stationary samples report 72-73 FPS,
App 2.09-2.47 ms and zero Tear/Stale counts; these do not establish active-Bird
or occupied-world performance. Captures have zero matched Udon-error lines,
not globally clean logs. Bird was not acquired. Physical gestures, comfort,
client walking and multiplayer remain unverified; both avatar click and
teleport gates remain off. Raw device media/logs remain private and ignored.

Production Rail01 was then transfer-verified and visibly rendered at normal
arrival during the 07:08 UTC observation, personally inspected at 07:09 UTC.
The pedestal, beacons and architecture are present, and the production world is
LEFT RUNNING. Its SHA256 is CC510FE3D8B1E4F3E88E62BCF6AF0EDF71AD8153A67A9287DE1BFCE43BBC03FA.
Power, temperature and matched Udon-error count remain as above. Sanitized
observations preserve the earlier Connecting attempts and successful results.
