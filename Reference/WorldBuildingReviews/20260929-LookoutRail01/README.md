# LookoutRail01 - continuous high-lookout railing

2026-09-29. The high-lookout ellipse now uses one closed square-section top rail
instead of 48 abutting boxes. Its original saved player boundary supplies the
path and all 48 post positions. The top is still 0.13 m square at a 1.05 m center
height; posts remain 0.065 m square and 1.06 m high. The saved rail mesh identity,
placement and exact visible pointing proxy remain. There are 960 triangles
instead of the original 1,152, with no new renderer, material, light, runtime
component or network stream. The source mesh builder is original project code.

The one-time finish also raises only this renderer's existing scene lightmap
scale override from 0.35 to 4. Explicit later updates preserve authored lighting
choices. The separate player-boundary and walking-slab serialized mesh bytes
are unchanged; the two accepted pond rail assets are unchanged too. The shared
builder's default output is compared directly with their saved triangle geometry.
Broader architecture, accepted Bird feel/filter/range/inflation, acquisition and
complementary hand colors remain unchanged.

## Geometry, lighting and views

Each platform's focused check covers 960 triangles / 1,440 closed oriented edges,
192 top rays including the former joins, all 48 posts and all 48 open spans,
original height/width/transform, UV2/unit normals and exact visible collision.
Existing pond rail checks and default-builder output parity also pass. A normal
lighting rebake produces two maps and 219 probes. Both quality settings check
177 receivers and render eight lighting views. Unity reports 137 UV-overlap
warning objects, down from the prior 140; the changed lookout edge is absent
from that list. Other shading/UV warnings remain unresolved.

Before and final Android/Windows each preserve seven matched views. View 01 is
the supported return stance; 02/03/05 inspect other parts of the loop; 04 is a
free closure diagnostic and 06 a free exterior view. View 07 checks arrival for
rebake regression. These are editor renders, not headset comfort acceptance.
No full walker was repeated: slab, route and player-boundary geometry are
unchanged. Separate normal-frame compiled tests cover the supported 27-palm
return neighborhood and now push against the actual lookout boundary using
both player layers, as well as their existing coast-guard cases.

## Independent review and limits

The separate critic review retains the Android repair: the wedge-shaped gap
and per-segment face changes are gone; square corners, post rhythm and the
small water-ring opening remain clear. Tight-end/closure and sampled rebake
views show no material new regression. Existing mottled lower rim/roof shading
remains. Whole-world scores stay 6.5 aesthetics / 8 navigation / 7 hangout / 6.5
overall; the at-least-eight target remains unmet. See critic-review.md for the
Windows follow-up and exact evidence limits.

The next bounded recommendation is one near-cliff shoulder prototype, using a
few broad asymmetrical planes outside existing room/cavern clearance and routes.
It should address the large flat rock face without redesigning the complex or
adding repetitive rock noise. Compare lookout, pond and exterior views before
retaining it. Physical feel/comfort/client walking and multiplayer remain
unverified. Avatar click AND teleport gates remain off pending physical tests.
No online upload, account change, client/SDK modification or bypass is involved.

At the cycle's first actual Quest capture (10:36 UTC), Meta still reports the
room too dim for tracking; VRChat is not running. This is a blocked device check.
Raw device media/logs remain ignored/private; only sanitized observations belong
here. Final exports, source-restoration proof and end-of-cycle device outcome
are recorded separately below and in the accompanying reports.

## Final platform exports and restoration

Compiled Udon tests pass 345 assertions on each platform over 230 Android /
229 Windows normal frames. These include the new lookout guard pushes, not
physical finger-click acceptance. Both SDK production exports and the separate
Android inspection pass with process exit zero, compressed/uncompressed size
gates, processed-scene component audit and bundle catalog validation. Each has
427 objects / 1,311 components / 29 unsynced Udon programs plus one manual
per-player stream. Exact bundle sizes and SHA256 values are in builds.json.

The Android inspection starts on the existing high-lookout floor near the
supported return stance, without temporary geometry. It restored the production
source exactly. Both SDK passes' remaining DynamicMaterials-order changes were
compared canonically with the saved post-bake source before restoring its exact
order. The intended scene lighting override and baked data remain. See
inspection-restoration.json; no production spawn or unrelated scene change is
retained. Android target restoration completed before the final device checks; source bytes still match the saved post-bake scene.

## Actual Quest checks after tracking recovered

At 11:01 UTC the normal production world visibly rendered its arrival area.
The separate lookout inspection visibly rendered at 11:05 and 11:06. Root and
independent critic inspected its stereo image: the visible foreground rail is
continuous, with square top/side faces and connected posts. Fixed headset tilt
and the existing fallback avatar limit coverage. It is not a whole-loop, physical
walking, comfort, active pointing or multiplayer test. The initial tracking
failure remains a real failure; no boundary/tracking bypass was used to recover.

Six late stationary inspection samples show 72-73 FPS against a 72 target,
App 1.59-1.67 ms, zero tear and stale frames. Startup samples are excluded;
these are not active Bird or crowded-world performance results. Battery is 77%,
AC powered with no weak-charger flag, at 40 C. Zero matched Udon-error lines
is not a claim that all client logs are clean.

The original, already installed Label01 inspection bundle was hash-checked and
normally relaunched for a bounded delayed check at 11:07 UTC. Both reviewers
see Water garden / Point through to highlight once, correctly oriented and
readable in both eyes. This is appearance evidence for that one approach, not
reverse-face/occlusion/motion or physical reading-comfort acceptance. Its older
world geometry and lighting are not the latest LookoutRail01 production. The
normal LookoutRail01 arrival is restored separately after this inspection.

Sanitized device JSON files record each observation. Raw device images and logs
stay ignored/private. No headset capture is treated as proof of physical finger
input, click acceptance or social interaction.

Latest LookoutRail01 production was transferred with matching device hash and
normally launched at 11:08 UTC. Root inspected its stereo capture at 11:09:
the normal arrival, Bird pedestal, cyan arrival beacon and architecture are
visible. **Production is restored and left running.** See
device-Production-Restored.json. Battery remains 77%, AC, no weak-charger flag,
40 C. This supersedes the earlier blocked state as the latest observation.
