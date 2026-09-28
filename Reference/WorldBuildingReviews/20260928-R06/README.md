# Coastal R06 repair evidence

Frozen editor renders and validation records, 2026-09-28 UTC. The saved coastal
scene contains the existing personal/social Bird integration. R06 repairs its
conversation pit and arrival enclosure through three ordinary prefab assets;
it does not regenerate the world or change Bird's geometry/filter/sizing path.
All new geometry uses existing project-authored materials.

The old pit's upper riser missed all 192 baseline rays. A closed stepped bowl
now joins the terrace to a matching circular floor, and partial-ring seating
has closed ends/undersides. A crown-shaped white rear closure fixes the cyan
slit. A separate hollow rock shoulder covers the cavern without moving rooms.
Seven repaired meshes pass closed, consistently directed edge checks (6,696
edges), 2,268 riser/tread/crown/rear-wall rays, wing-roof and standing-volume
checks. The 338 prior wing passage samples still pass.

The independent critic rejected the first tall, planar rock shoulder. Two
rejected exterior images are retained in `RejectedFirstPass`. The revised low
coastal shoulder rises/recedes inland and uses broader facets. The full review
and its historical scores are maintained in the light repository's
`docs/modernization/COASTAL-WORLD-REVIEW-R06.md`. R06 restores R05's ratings:
aesthetics 6/10, navigability 8/10, hangout suitability 6.5/10, overall 6.5/10.
The 8/10 overall target remains unmet. The dark extruded rock base/cavity,
rear facets, stacked terrace massing, soft white lighting and primitive coast
remain future work; passing closure checks does not make them finished design.

Views 01–21 preserve existing camera positions. New views 22–24 and 29 inspect
pit descent, seated use, low risers and return through the seating opening.
Views 25–28 inspect enclosure from above/east/rear/west; rear/west cameras were
reframed after the first pass. View 10 deliberately hides roofs/rock to show
circulation and must not be used as an exterior enclosure image.

The independent final follow-up accepts the bounded repairs. The replacement
west view is valid and shows the cavern enclosed consistently with the other
exteriors. Final matching traversal records close the earlier review conditions;
the numerical scores and remaining broader design criticisms are unchanged.

The standing CharacterController suite covers seven destination paths plus
eight radial pit descents, an inner-ring circuit and entry through the seating
gap. Each route runs outward and back without a turnaround reset, jump or
collision bypass. These are sampled geometry tests, not actual client walking
or physical comfort. Both targets pass with exit 0: 14,059 normal Update calls,
14,058 route-leg frames, 34 complete legs, maximum endpoint error 0.2339 m;
their CSV records are byte-identical. The capsule can span adjacent shallow pit
treads, so these standing routes do not establish fine foot placement or comfort.
Android's compiled-Udon Bird check passes 334 assertions
over 296 normal frames using synthetic SDK bones. Accepted Lab 14 settings,
acquisition, independent local rigs, cursors/trails and tracking recovery pass;
this does not establish actual two-client networking or finger-click behavior.

The inventory is 226 mesh filters (including two known runtime trail slots),
34,128 authored instance triangles, 14 materials and 121 colliders. It is not a
whole-device workload measurement. Normal SDK build records contain hashes,
size gates, scene catalog checks and processed component audits. This is local
Build & Test, not an online upload. The previously recorded Windows combined
scene/capture shutdown failure remains unresolved; independent Windows walking
and export must not be presented as a pass of that failing combined operation.

Final exports both pass with exit 0. Android is 633,281 bytes, SHA256
`46BA39ABAB4B9D91FB82CE80CF2AD7103E06A18388A8E342F45F91591462D124`;
Windows is 676,526 bytes, SHA256
`11554BCC00465D3E331DFDD7850697D46A1EABE5B20F4E69A0DAEC343955322E`.
Processed audits each report 302 objects, 933 components, 17 unsynced Udon
programs and one manual per-player stream, with no missing/project scripts.

The final Android bundle was transferred/hash-verified and launched through the
normal Quest VRChat client. An inspected post-load stereo image shows the
arrival and Bird pedestal. Raw screenshots/logs stay private under ignored
`Validation/CoastalWorld/DeviceR06-20260928-*`. One capture failed during Unity's
target switch; retrying capture alone succeeded. The initial post-launch image
showed initialization and is not the rendering proof. Recent logs have no
matched Udon exception but contain platform/voice/Oculus startup errors.

`spawn-frame-observation.json` is a limited actual-device observation: 98 VrApi
samples from the single idle arrival view, 72–73 FPS against 72 FPS target.
It does not cover active Bird use, all viewpoints, multiple visitors or physical
feel. No such acceptance is claimed by these images or automated records.
