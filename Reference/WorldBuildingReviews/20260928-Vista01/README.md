# Vista01 — daylight and layered coastline

2026-09-28. Original, editable scenery for Bird Coastal World. The existing
architecture, walking collision, Bird geometry/filtering/range, visual inflation
and complementary hand palettes are unchanged. No third-party art was acquired.
Source/workflow: light repository `docs/modernization/COASTAL-VISTA.md`.

## Saved result

Three ordinary mesh assets (864 triangles), a vertex-color material, two small
shaders, a daylight sky material and editor-only coast profile. A nested prefab
under the existing coastal region adds an open sea and two receding landforms.
The original rectangular sea renderer is disabled, with its object retained.
No new colliders, lights, Udon programs or network streams. The scene retains
two non-directional baked maps and 219 probes; 180 renderers map into lighting.
The sky's ordinary baked reflection asset was regenerated. 139 UV-overlap
warnings remain and are retained in `uv-overlap-warnings.txt`.

`Android` and `Windows` each contain eight final normal-quality 1200x750 renders
and an inventory. `Candidate01` retains three rejected first-pass images. The
first standard procedural sky looked too dark, the terrain too snowy and the
far land too hidden. The revised gradient sky, explicit sRGB-to-linear vertex
colors and lateral far-coast placement address that feedback. A mesh check also
caught an inverted tip triangle; removing longitudinal jitter fixed its winding.

## Validation

Focused Play Mode vista checks pass on both targets, with process exit 0:
bounded source mesh geometry and normals, supported actual batched rendering,
saved skybox, retained baked maps, no new collision/lights, and eight captures.
The Windows focused lighting check also passes, exit 0. Normal SDK builds,
compressed/uncompressed size gates, processed-scene audits and bundle catalog
checks pass, exit 0. Each bundle contains 365 objects / 1,114 components /
28 unsynced programs plus one manual per-player stream, no persistence or
missing/project scripts. Android was restored after the Windows build.

| Bundle | Bytes | SHA256 |
| --- | ---: | --- |
| Production Android | 1,586,930 | `89FE7C52615E06E25FBE9D8615420695BBDD2EED892E324095C49BDAD8F3AFA4` |
| Production Windows | 1,828,941 | `9CA620F4C3F82ED76F24C65A18D862A1CDE6072673765549AF0EB52E2ED1D974` |
| Inspection first export, viewed on Quest | 1,586,842 | `E3FF2DD71E23AF7AA8C85F7EFD2FBC26120F8102C15F06953875CE8870EC2F22` |
| Inspection rerun, wrapper exit 0 | 1,587,176 | `83632B3EF6185520AF86CB685373DBDBB64AE5101B6F455BC3A35CD0DA0B5C93` |

The inspection uses the normal SDK with only the initial spawn temporarily
moved to the water overlook, after floor/standing-clearance checks. The first
SDK export passed, but its restoration guard rejected the SDK's permutation of
the descriptor's DynamicMaterials list. After verifying that exact difference,
the original scene was restored. The guard now accepts only a permutation with
identical membership and no other field changes. The rerun passes and restores
exact original bytes (`inspection-restoration.json`). The device-viewed first
payload and the later successful wrapper payload are deliberately distinguished.
No client/SDK patch, validation bypass, synthesized hand input or teleport gate
was used. No online upload was performed.

`geometry-preservation.json` records 257 unchanged existing assets and nine
unchanged original scene transforms against heavy baseline a4e6277. New scenery
has no collision, so the previous 17 walking routes were not repeated. The older
combined Windows scene/navigation/capture native shutdown issue remains separate
and unresolved; these focused checks do not claim to repair it.

## Actual dedicated Quest

The first inspection payload was transferred and device-hash verified. ADB
transport failed during the editor lifecycle before its first capture; a
read-only retry succeeded. Manually inspected 21:02:36 UTC stereo imagery shows
the new sky, sea, island and middle/far coasts from the actual VRChat overlook.
Then the production Android payload was transferred/hash verified and launched.
The inspected 21:04:12 UTC stereo capture shows the normal arrival with the new
landscape. This production arrival build is left running. A client Public
instance toast is not evidence of an online world upload.

Battery 75%, AC powered, weak charger false, 38 C. Six recent stationary-overlook
samples were 72–73 FPS against 72 target, zero tear/stale, app 1.82–1.88 ms.
No matched Udon error lines in the captures; not an all-logs-clean assertion.
Existing fallback/error avatar hands remain. Bird was not acquired: physical
clicks, comfort, active Bird workload and real multiplayer remain unverified.
Saved avatar click and teleport gates remain off. Raw device screenshots/logs
stay ignored/private; sanitized observations are retained here.

## Independent critic

Retain the refined bounded pass. Daylight is coherent; near/mid/far layers read
clearly, the water remains open, the seated view is more inviting and arrival
still leads with architecture/pickup. Windows arrival, overlook and seated-room
renders match Android's material hierarchy; this is editor parity, not PC-client
or physical acceptance.

Full-world scores: **6.5 aesthetics / 8 navigability / 7 hangout / 6.5 overall**.
The target of at least 8 each is unmet. Near land remains blunt capped forms,
far land overly clean triangular wedges, and the flat sea/horizon austere. Favor
unequal shoulders/shore indentations before decorative density. Existing cliff
planes, cut shoulder base and stacked architectural disks also limit the score.
View 08 is floor occlusion, not proof of a beacon sightline. View 06 exposes an
existing doubled/mirrored beacon label from the side/back, for later UI polish.
Curved pond/outer bank/path, restrained planting and bounded schooling fish
remain separate future passes.
