# 3D-Game-Mechanics-FSM — Core Gameplay & AI Architecture

This repository serves as a dedicated **Technical Code Showcase** containing strictly my individual programming contributions for a collaborative 3D Action-Adventure game developed in Unity. 

To emphasize clean software engineering practices, all 3D art assets, scene configurations, and other teammates' workflows have been omitted, leaving a pure, production-ready C# codebase.

## 🛠️ Software Architecture & Design Patterns
- **State Pattern (Finite-State Machine):** Fully decoupled state logic using an abstract hierarchical FSM architecture to manage diverse actor behaviors seamlessly.
- **Polymorphism & Inheritance:** Designed a robust base `Entity` and modular state handlers, ensuring highly reusable code across players and multiple enemy variants.
- **Data-Driven Design (ScriptableObjects):** Isolated configuration data (e.g., movement speeds, damage matrices, attack ranges) into Unity ScriptableObjects for fast debugging and efficient runtime balancing without touching the core source code.

---

## 🚀 Deep Dive: Core Mechanics & Implementation

### 1. Modular Finite-State Machine (FSM)
At the core of the game's architecture is a flexible FSM system. Both player characters and enemy AI derive from a base `Entity` class, implementing state transitions via specialized C# scripts:
- **State Decoupling:** Every behavior exists as an isolated class, ensuring clean script management and preventing "mega-scripts."
- **State-to-Animation Synchronization:** Core movement parameters, combat frames, and state boundaries automatically handle the switching and blending of animator parameters during execution phases.

### 2. Advanced Enemy AI (3 Distinct Combat Variants)
Engineered 3 unique enemy types driven by custom FSM logic tailored to their visual indicators and mechanical requirements:
- **Enemy 1 (Melee Skeleton - `Enemy1.cs`):** Utilizes multi-stage logic for proximity alerts, path patrolling, and conditional physical attack triggers. Overrides damage and knockback routines to enforce an `E1_StunState` transition only when the enemy is not locked in an active attack frame (`!isAttacking`).
- **Enemy 2 (Kamikaze Bomb - `Enemy2.cs`):** Executes a proximity-based trigger system. Runs on dedicated state classes (`bombIdleState`, `bombRunState`, `bombExplodeState`) that override standard pathfinding to initiate a localized self-detonation sequence while actively managing a runtime visual area indicator.
- **Enemy 3 (EnemyMage - `EnemyMage.cs`):** Manages ranged distance combat constraints. Operates on custom distance-checking loops that dictate tactical spacing, vector velocity calculations, and handling dedicated ranged instances via a modular projectile launch pipeline.

### 3. ScriptableObject Integration
- Created structured data containers (`D_Entity`) to separate parameters from runtime behaviors. 
- Allows game designers to adjust properties like enemy vision radiuses, acceleration profiles, or maximum health boundaries on-the-fly inside the Unity Inspector without causing code side-effects.

---

## 📂 Repository Structure (Focusing on Code Quality)

```text
📂 Scripts
├── 📂 FSM
│   ├── 📄 Entity.cs           # Central abstract engine blueprint for all combat units
│   ├── 📄 EnemyState.cs       # Hierarchical constructor pattern for execution phases (Enter, Exit, Logic/Physics Update)
│   └── 📄 EnemyStateMachine.cs # Core state container, runner, and transitional pipeline switcher
├── 📂 PlayerScript            # Mechanics governing base player locomotion, jump physics, and standard combat inputs
├── 📂 EnemyScript             # Distinct behavioral state logic clusters for Melee, Mage, and Bomb units
├── 📂 projectileScripts       # Math frameworks managing target vectors, fly speeds, and hit registrations
└── 📂 Data SO                 # ScriptableObject architecture managing immutable attribute parameters
```
## 🤝 Project Acknowledgments

This repository is a technical showcase focusing on my individual implementation of the core AI architecture, State Machine, and player state mechanics. 

However, the game was originally developed as a collaborative project that has since been discontinued.
