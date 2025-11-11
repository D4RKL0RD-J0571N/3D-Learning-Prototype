# 🧩 3D Learning Prototype — Modular Game Architecture & Persistence Framework for Unity

**Conceptual Systems Project | Unity C# | Data-Driven RPG Core**

---

## 🎯 Overview

This repository represents a **conceptual 3D Learning Prototype** — a foundational project built to explore and demonstrate **modular game architecture**, **data persistence**, and **system scalability** in Unity using **pure C#** and advanced software design principles.

While its surface-level implementation is a simple 3D prototype, the real intent lies in constructing a **robust, reusable framework** for any **data-driven RPG, simulation, or systems-oriented Unity project**.

---

## 🏗️ Core Concept

The project’s architecture centers around an **Entity–Attribute–Progression (EAP)** model and a clean **I/O (Input–Output)** system.  
It demonstrates how to structure and decouple game logic for scalability and maintainability using enterprise-grade design patterns.

---

## ⚙️ Architectural Principles

| Design Pattern / Principle | Implementation Focus | Benefit |
|-----------------------------|----------------------|----------|
| **Generics & Base Classes** | `Entity.cs`, `BaseEntityManager.cs`, `EntityData.cs` | Reusable templates for all game objects, ensuring consistent initialization and management. |
| **Inversion of Control (IoC)** | `EntityBuilder.cs`, `ActorBuilder.cs` | Decouples complex object construction, enforcing valid states and separation of setup logic. |
| **Singleton / Manager** | `GameManager.cs`, `SaveSystem.cs`, `SpawnManager.cs` | Provides globally accessible system hubs with controlled persistence. |
| **Publisher–Subscriber Pattern** | `GameEventManager.cs`, `InputHandler.cs`, `CoreEvents.cs` | Enables flexible communication between systems without direct dependencies. |
| **Data-Driven Model** | `ActorData.cs`, `ProgressionData.cs`, `SaveData.cs` | Cleanly separates runtime logic from persistent state, simplifying serialization and designer workflows. |

---

## 💻 System Modules

### 1. Entity–Attribute–Progression (EAP) System

**Purpose:** Defines all core gameplay entities and their evolving data.

- **Entity / Actor System:**  
  `Actor.cs` is composition-based and contains an `AttributeCollection` and a `Progression` module.  
  `MainActor.cs` demonstrates player-specific specialization.
  
- **Progression:**  
  `Progression.cs` manages XP gain, level-up logic, and data synchronization through `ProgressionData.cs`.  
  Ensures safe level transitions using defined XP curves.

- **Attributes:**  
  `Attribute.cs` models dynamic stats like Health, Stamina, or Mana, with embedded regeneration logic.  
  `AttributeCollection.cs` coordinates frame-level updates for all active attributes.

---

### 2. Input and Event Handling (I/O)

**Purpose:** Build a fully decoupled user-input layer.

- **Input Handling:**  
  `InputHandler.cs` receives raw Unity Input and publishes structured events (e.g. `InputEventsPlayer`, `InputEventsUI`).

- **Event Bus System:**  
  `GameEventManager.cs` acts as the central static event hub, implementing the **Publisher–Subscriber pattern** to remove fragile references between gameplay, UI, and input logic.

---

### 3. Persistence and Serialization

**Purpose:** Ensure robust, extensible save/load functionality.

- **Save Logic:**  
  `SaveSystem.cs` encapsulates file I/O and JSON serialization, providing unified access to read/write persistent data.

- **Data Transfer Objects (DTOs):**  
  `SaveGame.cs` serves as the root serializable container.  
  `ActorSaveData.cs` mirrors complex runtime state (Level, XP, Attributes) for clean save operations.

---

### 4. Spawning and Initialization

**Purpose:** Safely and consistently create runtime entities.

- **Factory Pattern:**  
  `SpawnManager.cs` serves as a singleton factory, handling prefab instantiation, deactivation, and staged initialization.

- **Prefab Registry:**  
  `SharedPrefabs.cs` centralizes all prefab references, eliminating hardcoded asset dependencies.

---

## 💡 Demonstrated Portfolio Skills

| Skill | Supporting Files |
|--------|------------------|
| **Advanced OOP & Generics** | `Entity<TData>`, `BaseEntityManager<TData, TEntity>` |
| **Design Patterns (IoC, Factory, Singleton)** | `ActorBuilder.cs`, `EntityBuilder.cs`, `SpawnManager.cs` |
| **Persistence / Serialization** | `SaveSystem.cs`, `SaveGame.cs`, `ActorSaveData.cs` |
| **Event-Driven Architecture** | `GameEventManager.cs`, `InputHandler.cs`, `CoreEvents.cs` |
| **System Abstraction & Clean Code** | `Progression.cs`, `Attribute.cs` |
| **Maintainability & Utilities** | `CustomUtilities.cs`, `SharedPrefabs.cs` |

---

## 🧠 Summary

Although titled *3D Learning Prototype*, this project goes far beyond experimentation — it’s a **proof of concept for scalable game systems engineering** in Unity.

It demonstrates:
- Proper use of **composition over inheritance**  
- **Pattern-oriented design** adapted to Unity’s component model  
- Clean serialization for long-term persistence  
- Full architectural separation between **runtime**, **data**, and **editor** concerns  

This prototype acts as a **launchpad** for any future RPG, simulation, or sandbox system requiring modularity and persistence at its core.

---

## 🧩 Tech Stack

- **Engine:** Unity 6.x (URP)
- **Language:** C#  
- **Paradigms:** Data-Oriented, Event-Driven, Modular  
- **Tools:** Unity Input System, Custom Serialization, Editor Utilities  

---

## 📜 License

This project is for **portfolio and educational purposes only**.  
It may be reused or adapted for non-commercial learning and demonstration.

---

**Author:** [Jostin Lopez (J0571N)]  
**Role:** Systems & Gameplay Programmer  
**Focus:** Game Architecture • Data Systems • Engine Tooling
