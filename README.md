# EmuLab
A moddable emulator and game platform where you write assembly and build/mod your own virtual hardware through plugins.

---

## Overview

**EmuLab** (“Emulation Lab”) is a fully moddable emulator designed around the idea of inventing your own hardware.  
Instead of emulating a real-world CPU, EmuLab uses a flexible, RISC-style virtual architecture defined almost entirely by plugins.

Players (and modders) can:

- Add new **opcodes**
- Create **memory-mapped devices**
- Provide **APIs** callable from assembly
- Define custom **syntax** for instructions
- Build entire “games” or “consoles” as plugins

The end goal is a creative sandbox where you write low-level programs against a system you designed yourself.

---

## Development Status

EmuLab is in **very early development**. Right now, the core achievements are:

- A working **plugin loading system**
- A clean **IPlugin interface**
- ~~Support for **named service registration**~~ (Planned)
- Project structure and early plans for assembly execution
- Command-line gameplay planned during early stages

Future versions will include a Godot frontend, a modding SDK, and a full toolchain for assembling and running user programs.

---

## Plugin System

At the heart of EmuLab is the plugin architecture.

### What Plugins Can Do

- **Define custom opcodes**
- **Add memory-mapped devices**
- ~~**Register named services** (classes exposed to the emulator)~~ (Planned)
- **Expose APIs** callable from assembly
- **Provide custom instruction syntax**
- Potential future support for plugin-defined UI elements once the Godot frontend is built

### How Plugins Are Structured

Each plugin implements:

```csharp
public interface IPlugin
{
    string name { get; }
    string description { get; }
    Version version { get; }
    string author { get; }
    void OnLoad(PluginContext Context);
    void Update(PluginContext Context);
}
```



Upon loading, plugins can register their systems through the central service registry.  
You can drop compiled plugin `.dll` files into the `Plugins/` folder and they will load automatically.

Runtime hot-loading is not implemented yet, but may be explored later.

---

## How Assembly Works (Planned)

Assembly is planned to be **plugin-driven**.

Instead of one global assembler, plugins will be able to provide their own
assembly loaders and syntax. That means different plugins can effectively define
different “machines” with their own instruction sets and source formats.

High-level goals:

- Plugins can register **assembly loaders** for specific file extensions
  (for example: `.emuasm`, `.mcaan`, etc.).
- Each loader can define its own **syntax** and map it to the opcodes/devices
  the same plugin exposes.
- The core runtime just asks the chosen plugin to **parse + assemble** the
  program into something executable.

By convention, source files will live under an `asm/` directory, but which
files are supported and how they are interpreted is determined by the loaded
plugins.

---

## Frontend

### CLI Mode (Early Development)

The project will first support a command-line interface for:

- Loading plugins
- Running assembly programs
- Displaying program output
- Debugging custom instructions and devices

### Godot Frontend (Planned)

A full graphical frontend will be developed in **Godot** once the core emulator stabilizes.

Possible future features:

- Plugin-defined UI panels
- Visual debugging
- Virtual machine visualization
- Tooling for writing and testing assembly

---

## Tech Stack

- **Language:** C#
- **Runtime:** .NET 10
- **Frontend:** Godot (planned)
- **Architecture:** Plugin-driven emulator with service registry

---

## Modding SDK (Planned)thisthi

A formal SDK will eventually include:

- Project templates for new plugins
- Helpers for defining opcodes and memory-mapped devices
- Diagnostics and debugging tools
- Clear documentation for mod-defined assembly syntax
- Tools to integrate mod logic with the Godot UI

---

## Getting Started (Early Instructions)

### Directory Structure

```
EmuLab
├── Plugins/ # Drop .dll plugins here
├── asm/ # Your assembly programs
└── EmuLab # Main Binary
```

### Running (CLI)

> Note: Running is limited until more systems are built.

```bash
./EmuLab
```



---

## Roadmap

- [ ] Complete emulator core
- [ ] Define base instruction set
- [ ] Implement assembler
- [ ] Implement memory and device models
- [ ] Expand plugin system
- [ ] CLI debugger
- [ ] Godot frontend
- [ ] Modding SDK
- [ ] Example plugins
- [ ] Example “game” built entirely from plugins

---

## License

All rights reserved.  
You may view the source, but redistribution or reuse of the code is not permitted without permission.

---

## Contributing

At this stage, the project is primarily for personal development.  
Contribution guidelines may be added later once the architecture stabilizes.
