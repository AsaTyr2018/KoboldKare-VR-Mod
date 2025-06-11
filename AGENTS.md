# Repository Guidelines for Codex Agents

## Install Script
- The repository expects a shell script named `install_dependencies.sh` under `scripts/`.
- Ensure the script has executable permissions (`chmod +x scripts/install_dependencies.sh`).
- Update `README.md` with usage instructions mentioning Unity 2021.3.19f1 when the script is added or modified.

## Programmatic Checks
- For any changes to `install_dependencies.sh`, run `bash -n scripts/install_dependencies.sh` to verify syntax.
- There are currently no unit tests for this project.
