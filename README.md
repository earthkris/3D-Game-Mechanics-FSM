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
- **State Decoupling:** Every behavior exists as an isolated class (e.g., `IdleState`, `PatrolState`, `AttackState`), ensuring clean script management and preventing "mega-scripts."

### 2. Advanced Enemy AI (3 Distinct Combat Variants)
Engineered 3 unique enemy types driven by custom FSM logic tailored to their visual indicators and design requirements:
- **Enemy 1 (Melee Skeleton):** Utilizes multi-stage logic for proximity alerts, path patrolling, and conditional physical attack triggers (`E1_MeleeAttackState`, `E1_ChargeAttackState`).
- **Enemy 2 (Ranged Mage):** Manages tactical spacing mechanics coupled with custom projectile spawning routines, vector calculations, and hit registration.
- **Enemy 3 (Suicide Bomb):** Executes a proximity-based trigger system. Once a player enters a defined radius and satisfies specific gameplay conditions, it breaks its standard routine to initiate a localized self-detonation sequence.

### 3. ScriptableObject Integration
- Created structured data containers to separate stats from runtime behaviors. 
- Allows game designers to adjust parameters like enemy vision radiuses or projectile velocity values on-the-fly inside the Unity Inspector without causing code side-effects.

---

## 📂 Repository Structure (Focusing on Code Quality)

```text
📂 Scripts
├── 📂 FSM                  # Abstract architecture blueprints (Entity.cs, State.cs)
├── 📂 PlayerScript         # Modular player states and input processing
├── 📂 EnemyScript          # Custom FSM state matrices for Enemy 1, 2, and 3
├── 📂 projectileScripts    # Vector manipulation, pooling, and projectile velocity logic
└── 📂 Data SO              # ScriptableObject structures for data-driven balancing
