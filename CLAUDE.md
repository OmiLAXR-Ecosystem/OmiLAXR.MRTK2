# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

Working rules (versioning, CHANGELOG, `.meta` files, licenses, compatibility) are in @AGENTS.md. Follow them.

## What this is

`com.rwth.unity.omilaxr.mrtk2`: Adapter module for Microsoft MRTK2 (HoloLens and other mixed-reality devices): object manipulation, button/menu and eye-tracking tracking, including its own xAPI composers.

## Commands

There is no command-line build or linter: the package compiles inside a Unity project. Paths below are relative to the workspace root (`..`).

- **Develop:** `OmiLAXR_Dev/` (Unity 6000.3.13f1) does not link this package. Add `"com.rwth.unity.omilaxr.mrtk2": "file:<abs path to OmiLAXR.MRTK2>"` to `OmiLAXR_Dev/Packages/manifest.json`, together with any packages its asmdef references.
- **Tests:** none. There is no `Tests/` folder, and the required SDK is not available locally.

## Architecture

- **`MRTK2LearnerPipelineExtension`** registers the listeners and tracking behaviours with the learner pipeline.
- **`MRTK2DataProviderExtension`** (`DataProviderExtension<xApiDataProvider>`) registers this module's composers with the xAPI data provider. This is the data-side counterpart of a pipeline extension.
- **Listeners** (`Runtime/Listeners`): `ObjectManipulatorListener`, `ButtonConfigHelperListener`, `EyeTrackingTargetListener` and `GazeDetectionListener`.
- **Tracking behaviours** are in `Runtime/Tracking Behaviours` (the folder name has a space): manipulation, menu and eye tracking.
- **Composers** (`Runtime/Composers`) build xAPI statements directly, which differs from the other XR adapters.
- `GazeDetection` (global namespace) is a dwell-time gaze helper. `ReenablePipelinesOnSceneLoad` restarts pipelines after scene loads.
