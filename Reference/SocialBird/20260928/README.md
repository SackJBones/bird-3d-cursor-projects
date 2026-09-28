# Social Bird 02 and pedestal debounce

Maintained source: `SackJBones/bird-3d-cursor`, branch
`feature/vrchat-modernization`, source revision `5edf1bf44fd2d283ccb8c759d70be263d7237f4a`.
Read `docs/modernization/SOCIAL-BIRD.md`, `PERSONAL-BIRD.md` and the latest
checkpoint there for implementation and reproduction.

This adds an optional ordinary SDK PlayerObject template to the existing
personal station prefab. Local input, sphere fit, filtering and visual size
laws are unchanged. Remote presentation has independent point containers and
uses the same embodiment. Nine synced fields (72 raw scalar bytes, before
transport overhead) are requested at at most 10 Hz. Inactive acknowledged
stations are idle. Local and remote representations use the same deterministic
per-player palette, retaining contrasting left/right companion colors.

Acquisition is debounced: leave the pedestal's 2.2 m vicinity before returning
within 1.1 m and touching/using it can put Bird away. Vicinity follows the tracked
head's horizontal position, including room-scale motion with a fixed playspace
origin. Repeated touch/Use and hand withdrawal alone cannot immediately undo
acquisition. Reacquisition requires hand withdrawal and a one-second cooldown.

## Evidence

- Android and Windows personal tests: 334 compiled-Udon assertions per target,
  including physical head motion with a fixed playspace origin, unchanged saved
  Lab 14 settings and actual camera rendering/occlusion at 1 m, 4 m, 30 m and
  10 km. The PNGs are editor camera renders for each target, not headset captures.
- Android and Windows social tests: 41 compiled-Udon assertions per target,
  actual ClientSim per-player cloning/reference binding/initial ownership and
  removal; typed synthetic snapshot delivery and an SDK field-codec/JSON
  roundtrip; both hands, palette contrast, bounded interpolation, tracking loss,
  revisions, teleportation, malformed/stale/reordered data, late arrival,
  timeout/recovery, put-away and request cadence.
- The SDK 3.10.5 ClientSim ownership-steal probe did not enforce the documented
  immutable PlayerObject ownership contract. That specific enforcement is not
  counted as passing; it needs a real-client test. No SDK/client code was patched.
- Normal unmodified SDK exports pass both compressed and uncompressed size gates
  and bundle catalog checks. Processed scenes retain 299 GameObjects and 924
  components, with 17 unsynced Udon programs and one manual player stream,
  no VRCEnablePersistence and no missing/project MonoBehaviours.
- Android: 590128 bytes, SHA256
  `E5D014AB60B6789A20E5AA7542843805CF5430B32F54092F4063ED576CA730BD`.
- Windows: 628683 bytes, SHA256
  `4F315CE14DDC71141875D66049B8AA580F76281B845FC9E9B32CE5819139DCE8`.

The social checks are a single-process simulator exercise, not real multi-client
transport, measured wire bandwidth, full-capacity Quest performance or human
feel validation. The final pedestal-only head-position refinement was followed
by fresh personal checks and SDK builds on both targets; social logic remained
unchanged from its 41-assertion runs. Architecture/collision did not change, so
the previous traversal/architecture evidence remains applicable.

The final Android artifact was transferred to Quest as
`BirdCoastalWorld_SocialBird02.vrcw` using the normal VRChat TestWorlds workflow;
device SHA256 matched. A complete 4128x2208 stereo capture shows the coastal world
rendering at spawn in real VRChat; per-process captured logs contain zero matched
Udon exception/halt lines. This unattended capture does not verify touch
acquisition or active remote cursors. Private device logs/screenshots are kept under
the ignored `Validation/CoastalWorld/DeviceSocialBird02` folder. Prior test worlds
remain installed for rollback.

Dana authorizes routine headset use and replacement of the loaded build at any
time. The recurring plan now includes the complete new world/interaction vision,
with 30–60 minute passes every two hours and infrastructure before decoration.
