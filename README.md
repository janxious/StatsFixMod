# StatsFixMod
BattleTech mod (using ModTek and DynModLib) that fixes some of the stat summaries.

## Requirements
** Warning: Uses the experimental BTML mod loader and ModTek **

either
* install BattleTechModTools using [BattleTechModInstaller](https://github.com/Mpstark/BattleTechModTools/releases)

or
* install [BattleTechModLoader](https://github.com/Mpstark/BattleTechModLoader/releases) using [instructions here](https://github.com/Mpstark/BattleTechModLoader)
* install [ModTek](https://github.com/Mpstark/ModTek/releases) using [instructions here](https://github.com/Mpstark/ModTek)
* install [DynModLib](https://github.com/CptMoore/BattleTechModTools/releases) using [instructions here](https://github.com/CptMoore/BattleTechModTools)

## Features

- Fixed movement stats bar. Movement now actually shows movement without jump jets, as jump jets movement can be deduced from number of used jump jet slots in use.
- Fixed heat efficency stats bar. Heat efficiency is calculated based on how much heat capacity is unused after an alpha strike (+ some JJ heat logic from the original code). Should now also properly work with heat sinks, heat banks and heat exchangers.

## Download

Downloads can be found on [github](https://github.com/CptMoore/StatsFixMod/releases).

## Install

After installing BTML, ModTek and DynModLib, put the mod into the \BATTLETECH\Mods\ folder and launch the game.

## Development

* Use git
* Use Visual Studio or DynModLib to compile the project
