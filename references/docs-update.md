# Docs Update Rules

Auth0.NET is a **library/SDK** — its public surface is exported types and methods. Keep these docs in lockstep with public-API changes, in the same PR.

## Tracked docs

| Doc | Covers | Exists |
|-----|--------|--------|
| `README.md` | Installation, requirements, quick-start for Management + Authentication clients, advanced usage (raw response, `Optional<T>`, DI/interfaces) | ✅ |
| `Examples.md` | Runnable code samples — client init, client credentials, MFA/ROPG, RAR (PAR/CIBA), MRRT, Custom Token Exchange, Token Vault; Management: token quota, job errors, Network ACLs, custom-domain header | ✅ |

`reference.md` is the generated API reference (Fern) — do not hand-edit. Migration guides (`V8_MIGRATION_GUIDE.md`, `V9_MIGRATION_GUIDE.md`) are version-specific and handled at breaking-change time, not tracked here. `CHANGELOG.md` is maintained by the release flow.

## When you change code, update these docs

| When this changes | Update these docs |
|-------------------|-------------------|
| Public API surface (a client/sub-client, exported type, or public method) | `README.md` (usage), `Examples.md` (affected samples) |
| Configuration options (`ClientOptions`, `ManagementClientOptions`, token providers) | `README.md` (usage/configuration) |
| Authentication / token-handling flow | `README.md` (quick-start), `Examples.md` (auth/token samples) |
| Install, package name, or target-framework requirements | `README.md` (installation / requirements) |
| A new public method or exported type added | `Examples.md` (add a usage sample) |
| A public method or type removed or renamed | `README.md` + `Examples.md` (remove/update references) |
| A new integration pattern supported | `Examples.md` (add integration example) |

> When you touch code that maps to a doc above, update that doc **in the same PR** — do not defer. For Management API changes, remember most of that surface is Fern-generated: the doc update still ships in the PR that changes the definition/generation.
