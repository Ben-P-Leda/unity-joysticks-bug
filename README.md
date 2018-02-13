# unity-joysticks-bug

Simple project to illustrate the bug of how disconnecting then reconnecting joysticks results in behaviour that could make a game non-viable

Tested on PC using wired Xbox 360 controllers on
- Unity 2017.2

-------------------------

### Reproduction steps

- With no controllers are plugged in, restart the PC being tested on (to ensure all stick mappings are reset prior to test)
- Open Unity, load the project, then open Scenes\Demo Bug Scene
- Ensure "maximise on play" is not selected and console window is visible then start the project
- Plug a controller (hereby referred to as controller A) into any USB port
- **VERIFY:** Text below "Joystick [n] value" section reports a stick name count of 1 "Controller (XBOX 360 for Windows)"
- Move the left thumbstick on controller A left and right. 
- **VERIFY:** "Joystick 1 value" text changes with movement
- Plug a second controller (hereby referred to as controller B) into any free USB port
- **VERIFY:** Text below "Joystick [n] value" section reports a stick name count of 2 "Controller (XBOX 360 for Windows) :: Controller (XBOX 360 for Windows)"
- Move the left thumbstick on controller B left and right. 
- **VERIFY:** "Joystick 2 value" text changes with movement
- Unplug controller A
- Unplug controller B
- Plug controller A back in
- Plug controller B back in.
- **VERIFY:** Behaviour remains the same as above
- Unplug controller A
- Unplug controller B
- **Ensuring controller A is unplugged**, plug controller B back in
- **VERIFY:**  Text below "Joystick [n] value" section reports a stick name count of 3 "--UNKNOWN-- || --UNKNOWN-- :: Controller (XBOX 360 for Windows)"
- Plug controller A back in
- **VERIFY:**  Text below "Joystick [n] value" section reports a stick name count of 4 "--UNKNOWN-- || --UNKNOWN-- :: Controller (XBOX 360 for Windows) :: Controller (XBOX 360 for Windows)"
- Move the left thumbstick on controller A left and right. 
- **VERIFY:** "Joystick 1 value" text no longer changes with movement
- **VERIFY:** "Joystick 3 value" text changes with movement
- Move the left thumbstick on controller B left and right.
- **VERIFY:** None of the "Joystick [n] value" texts change

### Observations:
Instead of the expected behaviour of remapping controller A against joystick 1 and controller B against joystick 2, Unity progressively mapping controllers to new joysticks **unless they are plugged back in in the same order as they were unplugged**.

**Note:** Given that Unity can apparently map to the correct joystick if the controllers are plugged back in in the same order as their unplugging, it would indicate that Unity is aware of which controller is which to some degree; this raises the question "why can't Unity detect which controller is which regardless of the order in which they are plugged back in?"

**This is a game-breaking bug** which forum posts has been present in Unity for a considerable time, forcing developers to rely on third party fixes - should controllers become unplugged during a game, at best it would mess up which player controlled which avatar, at worst it would render the game unplayable until the system running it has been hard-reset.

### Conclusion:
This bug needs to be addressed as a matter of urgency, as it creates a game-breaking scenario in anything requiring differentiation between two or more controllers.