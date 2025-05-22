# 🐲 Monsters

A Windows Forms-based monster-raising game written in C#. Players collect, train, and evolve monsters while engaging in mini-games, battling bosses, and managing health, experience, and inventory. The game features a clean, dynamic UI and modular architecture built with C# and WinForms.

---

## 🛠 Features

- 🎮 **Player Monster Menu**  
  Displays up to four owned monsters with real-time stats including name, health, and icon. Allows switching between monsters.

- ⚔️ **Boss Battles**  
  Fight powerful boss enemies as your monsters level up.

- 🕹️ **Mini-Games**  
  Play interactive mini-games to earn experience and rewards for your monsters.

- 🧪 **Leveling System**  
  Feed and train your monsters to level them up. Higher levels unlock tougher challenges.

- 🎁 **Item & Inventory System**  
  Collect items through mini-games or battles. Use them to restore your monsters’ health or stamina.

- 📊 **Health and Stats Display**  
  Progress bars show real-time health. Future expansions may include experience, stamina, or attack bars.

- 🔁 **Monster Switching System**  
  Seamlessly change your active monster using the in-game confirmation menu.

- 👤 **Player Avatars**  
  Dynamic avatar display based on user type: boy, girl, or other.

- 🧠 **Data Binding**  
  Uses `BindingSource` for responsive UI updates tied to user data and monster attributes.

---

## 🧱 Technologies

- C# (.NET)
- Windows Forms (WinForms)
- Custom models (`User`, `MonsterClass`, `Item`, etc.)
- Embedded resources (images, icons)
- Event-driven architecture

---

## 📂 Project Structure (Key Components)

- `playerMenu.cs`:  
  User control that manages monster display and switching logic.

- `MonsterClass.cs`:  
  Core class representing monsters with properties like name, health, icon, and stats.

- `User.cs`:  
  Stores player information, including username, type, and owned monsters.

- `Form1.cs`:  
  Main form controller that handles screen transitions and global logic (navigation, active monster, etc.).
  
- `GameState.cs`:  
  Class that holds the state of the game (user, current monster, total collection of items and monsters, etc.).

- `GameDataServices.cs`:  
  Class that handles saving and loading from JSON.

## 🚀 Getting Started

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/MonsterRaiser.git
   cd MonsterRaiser

2. **Set the Startup Project to Monster.UI
3. **Play!**
