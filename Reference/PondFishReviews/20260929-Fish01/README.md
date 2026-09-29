# Fish01 — four Bird-responsive pond shoals

This bounded pass replaces the sixteen still diamonds with 24 original fish in
four six-fish shoals. The ordinary `PondSchool/Pond shoals.prefab` contains saved
fish, an original 88-triangle mesh, three pigment materials and a shallow basin
bed. The scene instance binds its one unsynced Udon behavior to the existing
personal Bird station. Water is translucent over an opaque bed. No new network
stream, collider, realtime light or third-party art is introduced.

Source and rationale are in the light repository's
`Integrations/VRChat/BirdPondSchool.cs` and `docs/modernization/POND-FISH.md`.
The component is downstream of logical Bird points and does not alter fitting,
filters, range, cursor inflation, clicks, acquisition or companion hand colors.
Do not rerun the one-time authoring migration over the saved scene.

## Interaction contract and verification

Each client runs its own cosmetic fish simulation at 10 Hz with interpolated
rendered motion. Individual fish trajectories are not shared authoritative
state. Schools approach valid local or remote Bird endpoints inside the actual
curved water footprint and shallow depth interval. Distant display proxies and
remote interpolation crossings cannot create water contact. Withdrawal,
tracking loss, stale packets, put-away and departure release attraction.

`Android` and `StandaloneWindows64` contain final compiled-Udon result/exit files,
focused views, motion-frame sequences and timing notes. These exercise the real
Udon VM and SDK-created PlayerObjects with synthetic transport. Four remote
visitors/eight hands are a workload fixture, not a real multiplayer session.
The 100-step timing excludes frame yields but includes editor Udon dispatch; it
is not a Quest performance measurement. The 220-step timing includes assertions
and yields. Existing social and lighting regressions pass separately. Android
pond support/clearance checks also pass all 319 samples; architecture and walking
collision did not change, so the earlier 18-route walker was not repeated.

The first motion fixture measured a manually advanced state before publishing it
to renderers. That fixture jump was corrected before measuring ordinary frames.
A subsequent fixture used the proxy-array type instead of Udon's erased backing
array; the test now reads the correct object array. Neither failure was a
deployed runtime candidate. Only test code changed after the final Android
export to add the four-visitor workload and a closer supported camera view.

## Independent visual review

Candidate01 was rejected for tightly overlapping, nearly circular gatherings.
Its four saved images document that rejected presentation; its empty timing
file is not a completed test result. The revision separates across shoals and
uses unequal slow wandering and depth variation. The critic accepts the looser
gathering, recognizable silhouettes and restrained gold/cream/teal palette.
Windows views 03/04 match the accepted Android presentation. Windows view 06
shows improved spacing close up. The first actual Quest stereo capture shows
fish clearly in both eyes without obvious shoreline clipping or sorting errors.

Remaining polish: subtle underwater depth cues, projected fish overlap, the
angular basin-color boundary, rail occlusion in some views, and broader terrace
support/rail-join/planting work. Sparse motion frames and static Quest captures
do not establish perceived smoothness. Full-world scores remain **6.5 aesthetics
/ 8 navigability / 7 hangout suitability / 6.5 overall**. The >=8-each target is
not met; this is acceptance of a bounded fish pass.

## Device evidence and limits

Raw headset images and logs remain private under ignored `Validation` folders.
The tracked device JSON files retain only build hashes, UTC observations,
battery data, matched-Udon-error counts and selected stationary frame samples.
The inspection payload uses a temporary floor/headroom-checked spawn near water,
then restores the source scene. It is a normal SDK export loaded by normal
VRChat Android Build & Test; no client patch, authentication change, online
upload or validation bypass is involved.

The 01:02 UTC Quest capture shows visible fish. A later fixed-view capture has
no fish in frame and is not counted as smooth-motion or visible-fish proof.
Incomplete Wi-Fi screenshot transfers were rejected. The helper now attempts
one on-device-file capture when direct capture fails, still checking all PNG
chunks/CRCs. Failed captures remain distinct observations.

Stationary inspection samples are 72–73 FPS against 72, zero tear/stale, with
reported app times around 2.45–2.70 ms. This is not active-Bird, attraction,
crowded-world, sustained or isolated fish-cost measurement. Existing fallback/
error avatar visuals remain. Physical hand attraction, click feel and real
multi-client behavior remain unverified. Avatar click and teleport gates stay
OFF. Further final build and device observations are recorded below.

## Final platform results

Both final fish fixtures pass **25,246 assertions / 297 frames**. Mean eastern
shoal distance falls from 7.253 to 0.753 m in the driven approach scenario.
100 synchronous eight-stimulus steps take 796.31 ms under the Android editor
target and 845.92 ms under Windows. Social checks pass 41 assertions (318 Android
frames / 320 Windows frames). Both lighting checks pass 167 receivers/eight views.
The rebake retains two non-directional maps and 219 probes, with 131 UV-overlap
warnings still outstanding. Pond instance geometry is 12,290 triangles; the
new fish and bed add 2,352 triangles, with old diamonds disabled.

Normal SDK exports pass size, processed-scene and catalog gates, exit zero:

| Payload | Bytes | SHA256 |
| --- | ---: | --- |
| Android arrival | 1,848,959 | C8F5D0562CCD70027CAA3C3B6580E2A81180E675576055D1A1B663CACB967279 |
| Windows arrival | 2,065,940 | 82294771847F5EB14121276B55A3E719B377CDEE44A6DACDB53C967B0D300778 |
| Android inspection | 1,849,719 | 9D702843531FA1DBE5AAB5A2C13E2C5EAB27CF8F32C009EC75513C8E2DF21502 |

Processed scene: 399 objects, 1,219 components, 29 unsynced Udon programs plus
one manual per-player stream, no persistence or missing/project scripts.
Android target is restored. Inspection source restoration is exact. Windows
export later permuted only the SDK DynamicMaterials list; membership and all
other scene content were checked before restoring the original bytes again.
The older combined Windows scene/capture shutdown defect remains separate;
focused checks and normal export complete successfully.

At 01:15 UTC, an explicitly fault-injected incomplete direct PNG exercised the
new helper fallback; the on-device screenshot/pull succeeded and passed all
integrity checks. That actual image shows a shoal farther around the pond than
the first observation. This confirms fish remain visible later in the session,
but still does not establish smoothness from sparse captures. An earlier forced
fallback attempt failed on the Wi-Fi pull and was retained as a failed attempt.

The first normal-arrival launch stayed on Connecting through two read-only
checks. One normal cold relaunch recovered: the 01:19 UTC inspected stereo
image shows normal arrival, pedestal and beacon. Device and source hashes match;
this production build is LEFT RUNNING. Battery 76%, AC, weak charger false,
38 C; no matched Udon error lines. This does not imply globally clean client
logs. The earlier stalled observations are explicitly not world-load passes.
