# Overlap Shapes

This project implements a modular overlap shape system in Unity designed to simplify detecting colliders within different shapes. It is built to be intuitive, extensible, and customizable within the Unity Editor.

## Table of Contents

1. [Overview](#overview)
2. [Scripts](#scripts)
   - [Core](#core)
     - [OverlapShape.cs](#overlapshapecs)
   - [Shapes](#shapes)
     - [OverlapCube.cs](#overlapcubecs)
     - [OverlapSphere.cs](#overlapspherecs)
     - [OverlapCapsule.cs](#overlapcapsulecs)
3. [Getting Started](#getting-started)
4. [Usage](#usage)
5. [License](#license)

---

## Overview

The OverlapShape system allows you to detect and respond to collider interactions using various shapes (Cube, Sphere, Capsule). It provides:

- Core functionality for shape-specific overlap detection.
- Configurable settings for offsets, sizes, layers, and event callbacks.
- Debug visualization for the shapes in the Scene view.

---

## Scripts

### Core

#### OverlapShape.cs

The **OverlapShape.cs** script is the base class for all overlap shapes. It provides the core functionality for:

- Handling collider detection using Unity's Physics methods.
- Events for `OnEnter`, `OnStay`, and `OnExit` collider interactions.
- Debugging tools to visualize the shapes.

**Key Features:**

- **Abstract Methods:** `Cast()` must be implemented in derived classes.
- **Utility Methods:** `CalculatePosition(Vector3 offset)` simplifies world-space position calculations.

---

### Shapes

#### OverlapCube.cs

The **OverlapCube.cs** script implements cube-shaped overlap detection.

**Key Features:**

- Configurable `halfExtents` and `offset` for custom cube sizes and positions.
- Non-allocating (optional) or allocating methods for collider detection.
- Debug visualization for the cube bounds in the Scene view.

---

#### OverlapSphere.cs

The **OverlapSphere.cs** script implements sphere-shaped overlap detection.

**Key Features:**

- Configurable `radius` and `offset` for customizing the sphere.
- Efficient overlap detection with optional pre-allocation.
- Debug visualization for the sphere bounds.

---

#### OverlapCapsule.cs

The **OverlapCapsule.cs** script implements capsule-shaped overlap detection.

**Key Features:**

- Configurable `radius`, `height`, and `offset` for the capsule.
- Handles the unique geometry of capsules with top and bottom spheres.
- Debug visualization of the capsule, including its connecting lines.

---

## Getting Started

1. Drag and drop the desired shape prefab from `Assets/OverlapShape/Prefabs` into your scene.
2. Adjust the shape's settings in the Inspector, such as size, offset, and layer mask.
3. Hook up UnityEvents (e.g., `OnEnter`, `OnStay`, `OnExit`) for custom behavior on collider interactions.

---

## Usage

### Adding to a GameObject

1. Attach any **OverlapShape**-derived component (`OverlapCube`, `OverlapSphere`, or `OverlapCapsule`) to your GameObject.
2. Configure the shape’s size, position, and layer mask.
3. Use the exposed UnityEvents for runtime interactions with colliders.

### Debugging

Enable the `showBounds` option in the Inspector to visualize the overlap shape in the Scene view.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
