# 3D Enemy AI Framework & UI System (C# Finite-State Machine)

This repository functions as a technical code showcase designed during my high school years to demonstrate foundational software engineering and architecture concepts within Unity/C# for portfolio evaluation. 

The project focuses strictly on implementing a clean, modular **Finite-State Machine (FSM)** framework and a **Reactive UI Health System** to govern diverse 3D enemy behaviors, isolating backend programming logic from visual assets.

---

## 🛠️ Programming Concepts Demonstrated

| Concept | Implementation Details | Key Unity Feature |
| :--- | :--- | :--- |
| **State Pattern Architecture** | Replaced monolithic scripts with a decoupled, class-based State Pattern to manage individual actor states independently. | `C# Inheritance & Polymorphism` |
| **Data-Driven Design** | Isolated immutable stats (e.g., detection radiuses, movement speeds) from the runtime code loop, ensuring scalable balancing. | `ScriptableObjects` (`D_Entity`) |
| **Game UI/UX Systems** | Developed responsive, real-time feedback loops to display gameplay critical stats without breaking decoupling rules. | `Canvas & Screen-Space Tracking` |

---

## 🚀 AI & System Implementation Breakdown

<p align="center">
  <img src="Images/enemies_showcase.png" width="750" alt="3D Enemy AI Variants Showcase">
  <br>
  <em>In-engine demonstration of the 3 unique AI variants managed by the core FSM framework.</em>
</p>

Architected 3 unique enemy types and an integrated UI feedback pipeline driven by custom logic tailored to different gameplay mechanics:

### ⚔️ 1. Melee Vanguard (Skeleton)
* **State Logic:** Manages execution flows for path patrolling, continuous target tracking, and conditional attack triggers (`E1_MeleeAttackState`, `E1_ChargeAttackState`).
* **Defensive Interrupts:** Overrides knockback routines to enforce an immediate transition into a stun state (`E1_StunState`) only when the unit is not caught inside an active attack frame (`!isAttacking`).

### 💣 2. Kamikaze Proximity Agent (Bomb)
* **State Logic:** Implements a high-risk pursuit behavior running on modular configurations (`bombIdleState`, `bombRunState`, `bombExplodeState`).
* **Mechanics:** Overrides standard NavMesh vectors to lock onto target transforms, executing custom runtime calculations to activate a visual area telegraph (`explodeIndicator`) right before triggering a self-detonation sequence.

### 🔮 3. Ranged Vector Caster (Mage)
* **State Logic:** Monitors player proximity vectors to maintain optimal combat distances, utilizing custom retreat or fallback spacing algorithms.
* **Mechanics:** Couples distance checks with a dedicated projectile spawning pipeline (`projectilePrefab`) to control projectile initialization, velocity vectors, and trajectory setups.

### 📊 4. Reactive UI/UX Health Pipeline (Both Player & Enemy)
* **Dynamic Feedback:** Programmed real-time, responsive Health Bars (HP Bars) for both the player and enemy variants to clearly communicate state damage transitions.
* **Optimization:** Optimized Canvas scaling and tracking systems to ensure precise visual positioning relative to world-space actor transforms.

---

## 📂 Repository Structure

```text
📂 Scripts
├── 📂 Data SO
│   └── 📄 D_Entity.cs             # ScriptableObject architecture managing enemy attribute parameters
├── 📂 EnemyScript                 # Shared logic clusters and modular controllers for enemy actions
│   ├── 📂 Bomb                    # Kamikaze pursuit vectors and self-detonation states (Enemy2)
│   ├── 📂 Mage                    # Tactical ranged spacing and projectile casting states (EnemyMage)
│   ├── 📂 Skeleton                # Melee patrolling, dynamic pursuit, and hit-stun states (Enemy1)
│   ├── 📂 State                   # Secondary behavior state definitions specific to individual entities
│   ├── 📄 AnimToEntity.cs         # Animation event triggers acting as FSM-to-Animator pipeline bridges
│   └── 📄 GenerateEnamy.cs        # General runtime system managers and dynamic enemy spawner logic
├── 📂 FSM
│   ├── 📄 EnemyState.cs           # Base constructor managing phase lifecycle hooks (Enter, Exit, Updates)
│   ├── 📄 EnemyStateMachine.cs    # Core state switcher and system execution engine
│   └── 📄 Entity.cs               # Central abstract engine blueprint for all AI entities
└── 📂 projectileScripts           # Vector displacement math and structural hit registration
