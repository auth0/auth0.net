# Git Workflow

## Branches

- Work on a feature/fix branch off `master`; open a PR against `master`.
- Release prep uses `prepare-x.y.z` branches (see `DEVELOPMENT.md`).

## Commits

- History uses short type prefixes: `feat:`, `fix:`, `deps:`, plus `Bump …` for dependency updates. Keep the summary imperative and scoped.
- **Signed commits are expected** (the README asks contributors to sign commits for verification).

## Pull Requests

- Fill out `.github/PULL_REQUEST_TEMPLATE.md`: describe what changed and why, list endpoints/classes/methods added/removed/changed, and complete the testing + checklist items (unit coverage, integration coverage, tested on latest platform).
- Required CI: the **Build and Test** workflow (`build.yml`) — build, then Core / Authentication / Management test jobs in sequence. `claude-code-review.yml` also runs.
- External PRs: maintainers run the live integration tests manually before merge (Auth0 doesn't share tenant keys).

## Changelog

`CHANGELOG.md` follows a grouped, versioned format and is maintained as part of the release flow — do not hand-edit it during a feature PR.
