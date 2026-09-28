# Mid-range assessment and Quest validation, 2026-09-28

Source: `SackJBones/bird-3d-cursor`, feature/vrchat-modernization.
Source commit: `d4f91970407c332d8b1b799bd38b2208b6e2fe27`. See that repository's
`docs/modernization/MID-RANGE-ASSESSMENT.md` for the hypothesis, measurement
definitions, numerical interpretation and deliberately unchanged defaults.

Both normal editor-target compiled-Udon suites pass 390,859 assertions over
2,929 frames with exit code 0. Result and exit records are retained here.
The 1,008 controlled measurements compare full center-filter influence at 20,
12 and 8 metres, at 30/72/120 Hz, with white/correlated noise, aim steps and
half/double range steps. Android/Windows controlled CSVs match byte-for-byte:

`24C9D1693B9FB6CFF18067F6BC06AC5F949693EEB008070708B2242A91039583`

The articulated-bone comparisons use actual avatar/fitter/limit/filter code in
normal editor frames; they are synthetic inputs, not measured headset noise.
Each side has 900 noisy samples across 3/6/8/12/20 m, with zero singular fits.
Frame cadence differs between targets, so retain each target's results. No
runtime algorithm, saved default, architecture or visual setting changed.
Android was restored after Windows. No fresh world build was needed.

Earlier full effect yields modest stationary benefit, extra directional delay,
and more inward contraction on abrupt turns. At 6 m, the full avatar pipeline
actually worsens radial RMS in both targets. This comparison is rejected for
deployment; it is not a claimed solution to Dana's feedback.

## Actual Quest recheck

The new `tests/quest_vrchat_smoke.py` transferred the existing validated Social
Bird 02 Android bundle again and verified matching source/device SHA256:

`E5D014AB60B6789A20E5AA7542843805CF5430B32F54092F4063ED576CA730BD`

Android accepted the normal SDK-style launch request at 10:41 UTC. However,
VRChat was absent afterward. A CRC-checked 4128x2208 stereo capture at 10:42 UTC
was inspected and shows Quest's “Finding position in room” dialog saying the
room is too dim. **This fresh launch is not successful VRChat rendering.**
The earlier successful Social Bird 02 rendering remains historical evidence.
No boundary, tracking or account bypass was attempted. Battery was 69%, AC
powered, no weak charger, 42 degrees C. Power/connectivity remain available;
room tracking is the observed blocker. Physical feel and multiplayer remain
unverified. Raw captures, address, logs and metadata stay in ignored private
Validation/CoastalWorld directories, not in this reference folder.

The helper retained a failure status and diagnostic screenshot when no process
was present. Its PNG verifier accepted the real capture and rejected truncated,
bad-signature and damaged-CRC variants. The post-launch running-app success
path remains to be exercised with this helper once tracking recovers.

## Multi-client gap

Official SDK documentation supports two desktop clients in a local test instance.
The configured Steam library and standard Oculus software directory contain no
PC VRChat client; neither standard executable path exists. This does not block
independent world work. Do not confuse the existing ClientSim snapshot tests
with two-client transport, immutable ownership or Quest multiplayer performance.
