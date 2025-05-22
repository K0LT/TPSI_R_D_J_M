# 🐲 MonsterRaiser

A Windows Forms-based monster-raising game written in C#. Players can collect, feed, and train monsters while managing their stats, health, and experience. The project focuses on modular design and solid UI logic for handling multiple monsters in a player’s collection.

---

## 🛠 Features

- 🎮 **Player Monster Menu**  
  Displays up to four owned monsters with real-time health, icons, and names. Includes options to switch the active monster.

- 📊 **Health and Stats Display**  
  Progress bars show current health points for each monster.

- 🔁 **Monster Switching System**  
  Players can change their currently active monster via confirmation dialogs.

- 👤 **Player Avatars**  
  Dynamic avatar image based on user type (boy, girl, or other).

- 🧠 **Binding-Driven UI Updates**  
  Uses `BindingSource` to reflect live user data in the UI.

---

## 🧱 Technologies

- C# (.NET)
- Windows Forms (WinForms)
- Custom data models (`User`, `MonsterClass`, etc.)
- Embedded resources for icons and avatars

---

## 📂 Project Structure (Key Components)

- `playerMenu.cs`:  
  A custom `UserControl` that shows the player’s monsters and allows switching between them.

- `MonsterClass`:  
  Represents a monster and contains its name, icon, health, and other stats.

- `User`:  
  Represents a player with fields like `Username`, `UserType`, and a list of owned monsters.

- `Form1.cs`:  
  The main form responsible for navigation and monster management.

---

## 🚀 Getting Started

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/MonsterRaiser.git
   cd MonsterRaiser
2. **Set the Startup Project to Monster.UI
3. **Play!**
