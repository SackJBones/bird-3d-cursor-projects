# Pond01 — curved basin and continuous promenade

2026-09-28. The fish pond now sweeps around the lower terrace, with curved
water and outer banks and a continuous waterside walk returning to the old
lower promenade. Existing stairs, rooms, beacons, Bird controls, inflation and
complementary hand palettes are preserved. Original project geometry only;
no third-party assets or attribution dependency.

## Editable result

`BirdWorld/Assets/BirdWorld/CoastalPond` contains a nested prefab, seven ordinary
mesh assets (9,938 triangles including safety boundaries and underside) and an
editor-only profile. It uses the existing water, plaster and stone materials.
The 3.3 m walk leaves about 3.2 m clear between rail bars; water is 0.6 m below
the floor. The original rectangular pieces remain as inactive scene overrides.
Sixteen existing still fish studies are redistributed; schooling remains future
work. No runtime generator, additional scripts, lights or network streams.

The explicit mesh-update command preserves GUIDs, prefab transforms and material
edits, validates every generated mesh before writing assets, and refreshes open
scene collider cooking. It does not automatically relocate existing landings.
Workflow: light repository `docs/modernization/COASTAL-POND.md`.

Saved lighting has two non-directional maps, 219 probes and 177 receivers.
141 UV-overlap warnings remain in `uv-overlap-warnings.txt`; blocky alternating
rail shading is still visible. The new deck reports three overlapping texels.

## Evidence and rejected candidates

`Android` and `Windows` each hold nine final normal-quality 1600x1000 views and
an inventory. `BeforeBake` retains three diagnostic controls. The original
03-high-lookout view shows floor occlusion and is not sightline proof. Final
03-high-beacon-stance uses supported footing and shows the water target through
the high rail. Final 09 documents the broad western return and remaining seam.

The first tight centerline folded its inner offset and failed before scene
mutation. The accepted broader curve avoids this. Initial straight apron joins
left crescent-shaped gaps; the final terrace follows the exact rounded cap
edges to the old promenade. Rail tails that crowded the inspection footing
were removed. The slab underside is closed.

The older general editability fixture regenerated five original meshes and
discarded their later-authored UV2 channels. Asset-diff inspection caught this
after the first exports. Those intermediate Android payloads were never
deployed. Exact baseline mesh assets were restored, matching the inputs used
for the saved bake. The fixture now backs up/restores and asserts complete mesh
bytes, including UV2, and recooks live colliders. The final Android scene check
passes; original mesh diffs are empty. `preservation.json` records the 266
existing assets compared with baseline bfbb5df.

## Validation

Both platforms pass focused pond checks: 319 floor/standing-clearance samples,
no invisible walking lid over water, unchanged beacon/inspection footing,
separate precise pointing rails and continuous player boundaries. Lighting
checks pass with eight actual renders and 177 mapped receivers. Compiled beacon
checks pass (Android 341 assertions/193 frames; Windows 343/192), retaining the
27 upper-return stance/height cases and gated travel. All saved click and travel
actions remain off pending physical validation.

Android general scene checking passes seven complete navigation destinations,
338 wing-clearance samples, repair assertions, 29 captures and the corrected
editability preservation check. Total scene instance geometry is 48,182
triangles with 16 materials. Normal-frame CharacterController traversal and SDK
export results are retained separately. The old Windows combined scene/check/
capture native shutdown defect remains unresolved; this cycle uses focused
checks plus the independent walker and normal SDK exporter on Windows.

Both normal-frame walking runs pass all 18 routes outward and back in 17,774
frames, followed by four player-guard push cases. Their 40-row traversal CSVs
match. Windows normal SDK export and audit also pass, exit 0: 2,050,586 bytes,
SHA256 `D52621BC5B34DBDD2F28A8FBAD3078C4B6A0B7183CB6253F884D71AEE46F50E1`.
Its object/component/Udon inventory matches Android.
The Android target and ordinary SDK settings were restored afterward, exit 0.

Final Android normal SDK export, size gates, processed-scene audit and catalog
checks pass. Production: 1,839,264 bytes, SHA256
`136E114FDFF52D109ED8506C92FC03D33775931677511AC2A6F022AC0AB69D30`.
Inspection: 1,836,669 bytes, SHA256
`AFE704C814E5F013BB2C356BEC2F1973AB407516FE53C935DD76715FB5285B24`.
Both contain 373 objects, 1,142 components, 28 unsynced Udon programs and one
manual per-player stream, no persistence or missing/project scripts. Inspection
temporarily changes only the initial spawn for a separate normal SDK export;
`inspection-restoration.json` verifies exact source restoration. No SDK/client
patch, validation bypass, account change or online upload.

## Actual Quest observations

Both final Android payloads were transferred with matching device hashes and
loaded in the actual VRChat client. The first inspection capture was black;
one read-only retry failed PNG integrity, and the next recovered. The inspected
23:13 UTC stereo view shows the new terrace, rail and narrow water edge against
the cliff. The unattended headset's fixed tilt/view does not show the complete
curve; editor views supply that separate layout evidence. The 23:14 UTC normal
arrival capture shows the pedestal, beacon and architecture. That production
build is left running. Existing fallback/error avatar visuals remain.

Battery 75%, AC powered, weak charger false, 38 C. Six recent stationary
inspection samples report 72–73 FPS against 72 target, zero tear/stale. See
`device-observations.json` for exact app times and sanitized observations. No
matched Udon error lines were found in these captures; this is not a claim of
globally clean client logs. Raw logs/screens stay private and ignored. Bird was
not acquired; physical gestures, active Bird cost, VR comfort, actual client
locomotion around the loop and real multiplayer are unverified.

## Independent design review

The critic accepts the bounded Pond01 layout: both water and bank curves read,
the path is continuous, rounded ends explain the return, the stair landing
remains broad, and the tide-room outlook remains usable. Full-world scores
remain **6.5 aesthetics / 8 navigability / 7 hangout suitability / 6.5 overall**;
the target of at least 8 on every axis is unmet.

The separate Windows parity review of views 02, 05 and 09 accepts the same
layout, lighting hierarchy, water color and seated tide-room framing without a
material platform regression. These are editor comparisons, not PC-client or
physical acceptance.

The near-concentric U resembles a racetrack around an empty deck. Later favor
bank-width variation, a purposeful stopping bay and sparse planting, rather
than random curve noise. The seaward overhang needs a convincing support or
underside treatment. Repetitive rails, alternating rail shading, the exposed
west rail end and thin bright join seam need refinement. Old doubled/mirrored
beacon labels remain a separate UI issue. Schooling fish responsive to local
and remote logical Bird positions remain a later runtime task.
