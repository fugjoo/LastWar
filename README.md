# Last War

Last War is a Unity-based mobile 3D action game. A conveyor belt moves friendly units and boss enemies toward each other while a helicopter provides aerial support. Units and the helicopter can be upgraded using coins.

## Features
- Conveyor belt with increasing speed
- Upgradeable player units
- Helicopter support
- Boss enemies with health bars
- Currency system and progress display
- UI canvas with coin counter, health bar, and conveyor progress

## Project Structure
- `Assets/` – game assets and scripts
- `Packages/` – Unity Package Manager dependencies
- `ProjectSettings/` – Unity project settings

## Development Status
Core gameplay mechanics and UI are implemented. Additional polishing and content are in progress.

## Performance
- Build settings now use the IL2CPP scripting backend with LZ4HC compression for smaller, faster builds.
- Profile the game with the Unity Profiler and aim to minimise draw calls and garbage collection allocations.
- Test builds on device emulators or real hardware to validate performance.

## Getting Started

### Requirements
- Unity 2021 LTS or newer
- Optional: Android or iOS build support modules

### Setup
1. Clone this repository.
2. Open **Unity Hub** and add the project folder.
3. Ensure the required platform modules (Android or iOS) are installed via Unity Hub if you plan to build for mobile.
4. Open the project in the Unity Editor.

### Running the Game
1. In Unity, open `Assets/Scenes/MainGame.unity`.
2. Press the **Play** button to run the scene in the editor.
3. For mobile builds, open **File > Build Settings**, select your target platform, and build.

## Contributing
Pull requests are welcome. Please follow the guidelines in [AGENTS.md](AGENTS.md).
