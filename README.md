# HarmonyOS Clock Music Visualizer
_A real-time audio visualizer for mobile & desktop built with Unity._

This project is a proof-of-concept UI effect designed for the Huawei TechArena Finland 2025 hackathon.
It demonstrates a simple deforming bubble that surrounds a clock. The bubble reacts to music creating a nice visual effect.

The effect is designed to work on PC and mobile (included builds are for Windows and Android devices for now).

The use case for this visualizer is simply quality-of-life. I was motivated by my own desire to have such an effect on my own phone's lock screen when I listens to music. Although there are probably other use-cases that can be envisioned with e.g. mic access.

## Functionality
1. Creates a bubble around a real-time clock on initialization.
2. Deforms the bubble based on audio source (currently source is static but should be updated to dynamically pick up audio from device).
3. Visualizes sound.

## Demo
Since the song I have chosen to use as an example is copyrighted, I can't upload my demos on youtube :( . In any case, all rights are reserved to the original created of the [song](https://www.youtube.com/watch?v=1tHdCULPZHk)!
Windows demo: Videos/WindowsDemo.mp4

Android demo: Videos/AndroidDemo.mp4

## Releases
You can find both an Android apk and a Windows .exe file in the [releases](https://github.com/filkata123/harmonyOS_audio_visualizer/releases).

## Tech Stack
- Unity 2022.3.30f1 (LTS)
- C# and HLSL
- Built-in Render Pipeline (2d)

## How to build
1. Clone repo
2. Ensure the correct Unity version as written above (might work with other versions too)
3. **Unity Hub** -> **Project** -> **Add** -> select cloned folder
4. Open project
### Windows
1. File -> Build Settings -> tick Scenes/PCScene -> select Windows platform (should be default)
2. click Switch Platform (if necessary)
3. click Build
### Android
1. File -> Build Settings -> tick Scenes/PhoneScene -> select Android platform
2. click Switch Platform
3. click Build
(make sure that IL2CPP is chosen and ARMv7 + ARM64 are enabled in the Player settings

## Future improvements
This is a very barebones POC that I made in 4 hours on a Sunday. Had I more time to spend on this event I would focus on the following:
1. Use system sound so that the user can e.g. put Spotify on an experience the visualization of their songs. Instead, right now there is a static song. This is not easily doable in Unity, but can be achieved with some libraries.
2. It is noticable that on the right of the visualization there is a spike since this is the start of the frequency band. Although this is technically correct, could be nice to smooth it so that it is a bit more uniform along the whole circle.
3. Make this a widget for the lock screen instead of an app (would be nice if the widget is also transparent so that the effect is soft).
4. Make the circle more dynamic. Right now it's not entirely static but I am not sure how it will look on devices with a different form factor than than mine.
