# 3D Enemy AI Framework (C# Finite-State Machine)

This repository functions as a technical code showcase designed during my high school years to demonstrate foundational software engineering and architecture concepts within Unity/C# for portfolio evaluation. 

The project focuses strictly on implementing a clean, modular **Finite-State Machine (FSM)** framework to govern diverse 3D enemy behaviors, isolating backend programming logic from visual assets.

## 🛠️ Programming Concepts Demonstrated
- **State Pattern Architecture:** Replaced monolithic scripts with a decoupled, class-based State Pattern to manage individual actor states independently.
- **Object-Oriented Programming (OOP):** Utilized inheritance and polymorphism through an abstract base `Entity` class, creating expandable blueprints for variance in AI types.
- **Data-Driven Design:** Integrated Unity `ScriptableObjects` (`D_Entity`) to isolate immutable stats (e.g., detection radiuses, movement speeds) from the runtime code loop, ensuring scalable balancing.

---

## 🚀 AI Implementation Breakdown

Architected 3 unique enemy types driven by custom state logic tailored to different gameplay mechanics:

### 1. Melee Vanguard (Skeleton - `Enemy1.cs`)
- **Logic:** Manages execution flows for path patrolling, continuous target tracking, and conditional attack triggers (`E1_MeleeAttackState`, `E1_ChargeAttackState`).
- **Defensive Interrupts:** Overrides knockback routines to enforce an immediate transition into a stun state (`E1_StunState`) only when the unit is not caught inside an active attack frame (`!isAttacking`).

### 2. Kamikaze Proximity Agent (Suicide Bomb - `Enemy2.cs`)
- **Logic:** Implements a high-risk pursuit behavior running on modular configurations (`bombIdleState`, `bombRunState`, `bombExplodeState`).
- **Mechanics:** Overrides standard NavMesh vectors to lock onto target transforms, executing custom runtime calculations to activate a visual area telegraph (`explodeIndicator`) right before triggering a self-detonation sequence.

### 3. Ranged Vector Caster (Mage - `EnemyMage.cs`)
- **Logic:** Monitors player proximity vectors to maintain optimal combat distances, utilizing custom retreat or fallback spacing algorithms.
- **Mechanics:** Couples distance checks with a dedicated projectile spawning pipeline (`projectilePrefab`) to control projectile initialization, velocity vectors, and trajectory setups.

---

## 📂 Repository Structure

```text
📂 Scripts
├── 📂 FSM
│   ├── 📄 Entity.cs             # Central abstract engine blueprint for all AI entities
│   ├── 📄 EnemyState.cs         # Base constructor managing phase lifecycle hooks (Enter, Exit, Updates)
│   └── 📄 EnemyStateMachine.cs   # Core state switcher and system execution engine
├── 📂 EnemyScript               # Behavioral state logic clusters for Melee, Mage, and Bomb units
├── 📂 projectileScripts         # Vector displacement math and structural hit registration
└── 📂 Data SO                 # ScriptableObject architecture managing attribute parameters
```
## 🤝 Project Acknowledgments
This repository highlights my personal technical milestone in core system programming and gameplay architecture prior to university admission. Other tertiary prototypes and connecting features from the original development timeline remain omitted to maintain an explicit focus on backend AI engineering quality.
