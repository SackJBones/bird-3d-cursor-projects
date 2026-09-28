# Coastal world R05 review evidence

Frozen final Android editor renders and validation records from 2026-09-28 UTC.
All geometry/materials are project-authored; no new third-party assets were used.
The source is the ordinary prefab-based `BirdCoastalWorld.unity` scene. The Bird
tracking lab and its deployed Lab 14 bundle are separate and unchanged.

R05 replaces the arrival wings' flat connector beams with continuous circular
bores, removes the cliff lounge's competing inner portal and floor intrusion,
reduces vertex-light hotspots, and reorients/rearranges the tide lounge toward
open water. Independent first-pass review prompted matched bore tessellation
and a 25-degree coastward room turn with a wider guarded approach. These edits
were applied through two scoped stages to existing prefabs, preserving saved
asset identities and unrelated content; the world was not regenerated.

The independent critic's final scores are aesthetics **6/10**, navigability
**8/10**, hangout suitability **6.5/10**, overall VRChat world quality **6.5/10**.
See the maintained light repository's `docs/modernization/COASTAL-WORLD-REVIEW-R05.md`
for rationale and the unchanged historical R01/R02/R04 scores. The overall
8/10 target is not met. Main inhabited curved massing, coastal depth and broad
white form lighting remain priorities. A small cyan enclosure slit remains
visible high in view 18; its precise cause has not been established.

Views 01–15 retain the R04 camera positions for comparison. Because the tide
room moved/turned, view 12 no longer follows its outward axis. View 16 is the
current seated coastal outlook, 17 is the entry/return approach, 18–19 inspect
the wing passages laterally, and 20 shows the upper floor at standing height.
View 10 explicitly hides roofs/upper slabs to show circulation routes.

`geometry-budget.txt` counts 223 mesh instances, 30,028 instance triangles,
ten shared materials and 123 active colliders; this is not a GPU cost estimate.
`passage-clearance.txt` records 338 sampled standing-capsule clearances and
supporting floors across both wing passages. `routes.csv` contains seven
complete NavMesh paths. The separate walkthrough records use actual
CharacterController movement out and back, with no turnaround teleport.
Both platform processes exited zero and their CSV records match: 12,515 summed
route-leg frames, maximum endpoint error 0.0879 m. The runner reports 12,516
normal Update calls because it also counts the final completion call.
The profile edit check preserves mesh identity, scene transforms and additions;
stairs/rails/anchors still do not automatically reflow after profile changes.

The normal unmodified SDK exports are architecture-only test bundles, not an
online upload. Their build records include hashes, size gates, catalog checks
and processed-scene component audits. The previous Windows combined scene/
capture/editability shutdown failure remains unresolved and was not retried in
this cycle; independent Windows walk/export do not turn that failure into a pass.

These records do not establish physical VR comfort, varied-avatar or multiplayer
behavior, stereo stability, or measured Quest performance. Bird/UI/Hanoi/mandala
are reserved experience anchors in this scene, not implemented activities.
