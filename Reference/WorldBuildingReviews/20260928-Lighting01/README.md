# Lighting01: baked coastal daylight

This pass supplies missing interior illumination under normal Windows shadow
settings and brings Windows and Android closer to the same readable world.
The authored complex and accepted Bird controls are preserved. The scene has
ordinary editable LightingSettings, baked sun/room/area lights, a visitor probe
group and lightmap assets. There are no additional runtime lighting scripts.

`Android/` and `Windows/` contain eight actual ClientSim Play Mode renders under
each platform's default VRChat quality. They are not client/headset screenshots.
`Candidate01/` retains selected initial images; `Candidate02/` retains the first
refinement before the targeted shell ray offset. Real Quest observations are
recorded separately in sanitized device evidence; raw logs/screens stay private.

The final setup uses six texels/metre, two non-directional maps (maximum 1024),
181 mapped renderers and 219 probes. All eight authored lights are baked. Distant
landscape has lower lightmap density; invisible walking guards do not contribute
GI. Six curved shells use a 2 cm bake-ray offset. Floor/stair parameters retain
their previous defaults. Existing materials, prefab geometry, original scene
transforms and all collision shapes are unchanged. The 85 procedural meshes gain
UV2 only; positions, normals, triangle indices and bounds match the previous
commit byte-for-byte. See geometry-preservation.json.

Development caught an editor/runtime assembly dependency mistake and then
Unity's direct secondary-UV generator welding nearly coincident seam vertices
(65 nanometres on a planter, 2.57 micrometres on a portal). Those attempts were
restored. The final per-triangle UV-only method preserves the original vertex
and index channels exactly. These are not first-attempt-success claims.

The critic rejected the first candidate's overexposed pickup and dirty-looking
joins. Larger chart margins, more samples, reduced fill and removal of extra AO
recovered pedestal/sculpture detail and improved the lounge. A targeted ray
offset then removed most of the scalloped canopy seam. The independent critic
recommends retaining this final candidate and found no new obvious broad leaks
or floating structures in the inspected arrival, support, stairs and passage.

Lighting-only scores: 6.5 aesthetics / 6.5 white readability / 7 navigation
hierarchy / 7 hangout suitability. Full-world scores remain 6 / 8 / 6.5 / 6.5; the
target of 8 on every dimension is unmet. Remaining work includes support mottling,
faint shell seams, slightly warm whites, downward stair contrast and UV-overlap
warnings. The extracted warning list is retained; this is not a warning-free
final art pass. Keep ordinary editable lighting rather than adding runtime
workarounds to mask these findings.

Per-platform lighting/build result files and process exit records establish the
technical checkpoint. Normal SDK exports retain its size gates, scene/Udon
audit and bundle catalog/hash verification; no client/SDK patch or online upload.
The older combined Windows navigation/capture shutdown issue is separate and
remains unresolved. Geometry is unchanged; this cycle uses byte-preservation
checks rather than repeating the previous 17 complete out-and-back walk routes.
No new physical finger-click, active frame-cost, avatar-lighting or multiplayer
acceptance is inferred. Saved avatar-click and teleport action gates remain OFF.

All geometry and lighting assets are original project work using Unity's built-in
tools. No external asset package was downloaded. Maintained source and workflow:
light repository docs/modernization/COASTAL-LIGHTING.md and latest CHECKPOINT.md.

The critic separately reviewed normal Windows VRC High views 01, 02, 06 and 07.
The previous flat dark-shadow failure is materially resolved, and Windows and
Android share the focal hierarchy and broad shading. This does not establish
actual PC-client rendering or performance. Remaining ratings/findings above
are unchanged by platform parity.

Both normal SDK exports and focused lighting checks passed, process exit 0.
Android: 1,642,902 bytes, SHA256
`460C4C06C05E489D910B4A4935DA8C89049E2CC90224B98334CBBB4E32154F22`.
Windows: 2,053,189 bytes, SHA256
`09A613E32CF33B6A3A0851B7391EA99691D9793AAD062008E3D0FC05EB871F61`.
Both export 361 objects / 1,104 components / 28 None-synced programs plus one
manual per-player stream. Android is restored. Each final render inventory
reports two maps totaling 1,310,720 texels; this is not a frame-time measurement.

Hash-verified Lighting01 is visibly running in Quest VRChat in the inspected
19:17:56 UTC stereo capture, following a connection delay and normal warm-start
retry. Battery 74%, AC powered, weak charger false, 38 C; zero matched Udon exception
lines in the sampled capture is not an all-logs-clean claim. Existing fallback/
error avatar hands remain; no Bird acquisition or real gesture validation.
Raw device evidence remains private. No online upload or account changes.

Three nearby stationary-arrival VrApi samples report 72/72, 73/72 and 72/72,
zero tear/stale frames and 3.20-3.35 ms app time. This narrow idle observation is
retained separately; it does not establish performance with active hands or
multiple visitors.
