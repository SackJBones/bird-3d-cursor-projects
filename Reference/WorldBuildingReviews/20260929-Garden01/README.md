# Garden01 — a small pond-side conversation corner

2026-09-29. Two unequal angled seats and three unequal planting groups give
the empty inland pond terrace a place to pause. White rounded bases, warm seat
surfaces and restrained foliage follow the existing architecture. The open
center leaves room for visitors and Bird gestures. All new art is original.

The saved `Assets/BirdWorld/CoastalGarden/Pond garden corner.prefab` is an
ordinary nested prefab with editable transforms, seven mesh assets, two new
opaque materials and reused plaster/warm-floor materials. It adds 2,040 instance
triangles, 21 renderers and nine static colliders/lightmap receivers. There are
no new runtime scripts, network streams, lights or animated leaves. Seat tops
are 45 cm above the terrace; these are seating geometry, not VRCStation actions.
Accepted Bird controls, range, filtering, visual inflation and paired hand
colors are unchanged.

## Design iteration

`Before` preserves three Fish01 views of the empty terrace. `Candidate01`
preserves the first wider layout. The independent critic requested moving the
shorter seat and its associated planter one metre inward so the pair reads as
a conversation corner instead of benches across a passage. The final layout
uses that refinement while retaining both approaches and the outer circuit.

The first high inland view was occluded by an upper floor. It remains only in
the candidate controls. The final seaward overview is explicitly a free camera,
not a supported visitor stance. Both seated views and approach views retain the
real geometry; nothing is hidden for their captures. The bank limits the seated
water view to a band, so this is a shared coast-and-pond view, not uninterrupted
fish watching.

## Validation boundaries

The first sightline test incorrectly treated the invisible player fence as a
visual occluder. Its visual mask was corrected to retain real walls, slabs and
the exact visible rail. All body/walking tests still include the safety fence;
no collision was removed to pass a check. Supported furniture footprints,
three-height approach clearance, flat seat height, seated torso/head clearance,
finite meshes, UV2 and opaque-material/triangle budgets receive focused checks.
The ordinary normal-frame CharacterController walker adds two approaches to
the existing 18 routes and traverses all of them outward and back.

Baked receivers have separate UV2 charts, but this does not imply a clean bake:
140 object UV-overlap warnings remain (including nine furniture receivers).
The older combined Windows scene/capture shutdown defect is separate from the
focused checks and normal SDK exporters used here. Physical comfort, real
client walking, physical Bird gestures and multiplayer require separate
acceptance. Saved avatar click and teleport action gates stay off.

Both platforms pass 3,024 supported furniture vertices, 223 approach samples
at three heights, 35 seated-water sightlines, the geometry/material checks and
seven renders. Both lighting checks pass with 176 mapped receivers and eight
renders; the bake retains two non-directional maps and 219 probes. Android's
normal-frame walker passes all 20 routes out and back in 19,206 frames, followed
by four guard push cases. The wider first candidate passed in 19,236 frames.
Windows receives focused support/clearance checks; the full walker was not
repeated there this cycle. The unchanged pond's 319 support/clearance checks
also passed before the seating refinement.

Normal SDK exports, size gates, processed-scene audits and catalogs pass with
exit 0. `builds.json` identifies the production Android (1,896,690 bytes),
Windows (2,113,617 bytes) and separate inspection Android (1,897,240 bytes)
payloads. Each has 426 objects, 1,297 components, 29 unsynced programs and one
manual per-player stream, with no persistence or missing/project scripts.
The inspection changes only a supported initial spawn and restores the source
scene exactly. The later Windows SDK changed only DynamicMaterials order;
identical membership and all other scene bytes were verified before restoring
the Android source bytes. Android target and final seven captures are restored.
No SDK/client modification, validation bypass or online upload.

## Quest observations

The exact inspection payload was transferred and later visibly rendered in
the actual Quest VRChat client at 03:15 UTC. Both seats appear in stereo; the
fixed tilt excludes the planting, which is separately evidenced in editor
views. Initial capture showed Connecting. Two later logcat reads and separate
screen attempts lost the ADB transport. Reconnecting with Unity's bundled
ADB 32.0.0 recovered a full capture; the other client was 31.0.2. The cause of
the drops is not established. Both transport failures and client-load delay
are distinct from a geometry/render failure.

Production Garden01 then loaded visibly at normal arrival at 03:17 UTC, with
pedestal and beacon. Its source/device hashes match, and it is LEFT RUNNING.
Battery 76%, AC powered, weak charger false, 40 C. Recent stationary inspection
samples show 72–73 FPS/72 target, App 2.20–2.29 ms, zero tear and some Stale=1
samples; this is not active-Bird or crowded-world performance. Successful
captures have zero matched Udon-error lines, not a globally clean-log claim.
Existing fallback/error-avatar visuals remain. Bird was not acquired; physical
gestures, seated comfort, real client walking and multiplayer remain unverified.
Sanitized observations are saved here; raw device images/logs remain private.

## Independent review

The critic retains the one-metre refinement: views 03/05 now read as a shared
seating group, with a generous open entrance, separate planting clusters and
clear circulation. The seated water view remains limited but usable; no new
obstruction was identified. View 06 was excluded from that review.

Whole-world scores remain **6.5 aesthetics / 8 navigability / 7 hangout
suitability / 6.5 overall**. The at-least-eight target is still unmet. The new
corner adds warmth and purpose, but the broad terrace feels exposed and the
surrounding structural forms are unfinished. The recommended next bounded
pass is one convincing underside/support transition where the pond terrace
joins the landward mass, keeping the walking surface, basin and routes fixed.
Judge a broad tapered support from seaward and approach views before extending
the idea. Static review does not establish physical seating comfort.

The final Windows 03/05 parity review found no material regression in seating,
plant readability or lighting. The critic accepted the new free-camera seaward
06 as useful layout evidence for the pocket, open approaches and outer circuit;
it is not a standing visitor viewpoint. Scores and the support recommendation
remain unchanged after this review.
