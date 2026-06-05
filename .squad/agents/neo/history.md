# Project Context

- **Owner:** Morpheus
- **Project:** ASP.NET Core site for essays and content with a planned gated book download flow
- **Stack:** ASP.NET Core Razor Pages on .NET 10 with C#, Markdown content, MailKit
- **Created:** 2026-06-04T19:11:30.363-04:00

## Learnings

- Team initialized to plan and deliver a book download flow that captures contact details into SQLite.

### 2026-06-05 — Copilot Instructions Onboarding
- **Outcome:** Created `.github/copilot-instructions.md` (348 lines) to onboard future Copilot sessions.
- **Coverage:** Quick start (build/run), architecture (Razor Pages + Services layer, CSV → SQLite migration path), philosophy (2 AM Test, Half-Rule, Primary Path First), conventions (C# 14, DataAnnotations, DI pattern), squad context (routing, branch naming, decision workflow), common tasks (new page, new service, email, essay, SQLite migration), error handling, dependencies, git workflow, troubleshooting.
- **Key insights:** No test infrastructure yet (feature-first approach); single-project monolith (Simplicity-First philosophy); manifest embedded in project; FileSubscriberStore is thread-safe CSV with SemaphoreSlim. All paths documented; team roster cross-linked. File integrates manifesto philosophy into operational guidance.
- **Path created:** `.github/copilot-instructions.md` (11.5K, 318 lines)

### 2026-06-05 — Copilot Instructions Revision & Finalization
- **Status:** Approved and merged to decisions.md (2026-06-05T15:52:08Z UTC)
- **Tank feedback:** Initial draft rejected for generic ASP.NET content; requested project-specific scope only
- **Scribe revision:** Reduced instructions from 295 lines (8,500 words) to 141 lines (3,100 words) — ~63% reduction while keeping all repository-specific guidance
- **Final outcome:** `.github/copilot-instructions.md` now concise, high-signal reference for all Copilot agents
- **Integration:** All sections repositioned to justify inclusion; philosophy checklist, squad context, and git workflow retained; common tasks/troubleshooting/paths removed as generic

### 2026-06-04 — Gated book download plan
- **Current subscribe flow:** `Index.cshtml` htmx form POSTs `SubscriberEmail` to `OnPostSubscribeAsync` (`/?handler=Subscribe`), validated by DataAnnotations, persisted by `FileSubscriberStore` (singleton, SemaphoreSlim, CSV `Email,SubscribedAtUtc` at `Data/subscribers.csv`). Returns `_SubscribeResult` partial; `data-show-modal` triggers thank-you modal. `Subscribers.cshtml` is an admin list.
- **Download precedent:** worksheet PDF is served UNGATED as a static file (`wwwroot/docs/...`). Book download must NOT follow this pattern — it must be gated.
- **Stack:** ASP.NET Core Razor Pages, .NET 10, MailKit, Markdig. No SQLite/EF package present yet. `IEmailSender` exists but confirmation email is commented out.
- **Decision:** EF Core SQLite + new `IContactStore`/`Contact` entity, capture-then-reveal gating. Recorded in decisions inbox.
- **Key paths:** `SimplicityFirst/Program.cs` (DI), `Services/ISubscriberStore.cs`, `Services/FileSubscriberStore.cs`, `Services/EmailSettings.cs`, `Pages/Index.cshtml(.cs)`, `Pages/Shared/_SubscribeResult.cshtml`.
- **TEAM UPDATE (Scribe):** Decision merged to decisions.md. Orchestration log created. Ready for task assignment.
