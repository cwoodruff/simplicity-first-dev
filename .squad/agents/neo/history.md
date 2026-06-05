# Project Context

- **Owner:** Morpheus
- **Project:** ASP.NET Core site for essays and content with a planned gated book download flow
- **Stack:** ASP.NET Core Razor Pages on .NET 10 with C#, Markdown content, MailKit
- **Created:** 2026-06-04T19:11:30.363-04:00

## Learnings

- Team initialized to plan and deliver a book download flow that captures contact details into SQLite.

### 2026-06-05 — Brand Redesign Plan Decomposed into GitHub Issues
- **Task:** Convert Simplicity-First Brand Redesign Plan (markdown, 4 phases) into GitHub milestones and actionable issues.
- **Outcome:** 4 milestones created; 11 issues derived and assigned (Phase 1: 4, Phase 2: 3, Phase 3: 2, Phase 4: 2).
- **Key insight:** Plan's "Tier 1 credibility leaks" justified as 4 independent, testable issues — not a monolithic "truth pass." Phase 3 split into parallel-safe subtasks (cards vs. blockquotes).
- **Decision doc:** Written to `.squad/decisions/inbox/neo-brand-redesign-issues.md` — explains decomposition logic, dependencies, and issue boundaries.
- **Decomposition principle:** One issue = one user-visible outcome, with concrete acceptance criteria, desktop/mobile testing, and brand consistency verification.
- **Sequencing:** Phase 1 (credibility) → Phase 2 (hero discipline) → Phase 3 (method) → Phase 4 (flow). Phases 2–3 can proceed in parallel; Phase 4 waits on Phase 3.
- **Tool choice:** GitHub REST API (`gh api repos/.../milestones`) used for milestone creation (no `gh milestone` subcommand in active version).
- **Future work:** Scribe will merge decision doc to `.squad/decisions.md`. Team can assign issues and begin work from Phase 1.

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

### 2026-06-05 — Phase 1 ("Truth Pass") Milestone Triaged & Issues Assigned
- **Task:** Triage GitHub milestone "Phase 1: Truth Pass" (4 copy/content fix issues); assign to Trinity and Tank; document sequencing.
- **Outcome:** All 4 issues assigned and ready to start:
  - #1, #2, #3 → squad:trinity (copy fixes: pricing, book parts, banned words)
  - #4 → squad:tank (audit verification)
- **Squads created:** Established 5 squad member labels (squad:trinity, squad:tank, squad:neo, squad:switch, squad base label)
- **Triage comments:** Added clear triage notes to each issue explaining assignment rationale, blockers, and sequencing
- **Parallelism:** All 4 issues can start immediately; no cross-layer dependencies; audit (#4) validates copy removal (#3)
- **Decision doc:** Written to `.squad/decisions/inbox/neo-phase1-assignment.md` explaining routing, parallelism, and label creation
- **Routing applied:** Per `.squad/routing.md` — page UX/copy → Trinity; testing/audit → Tank
- **COMPLETION NOTICE (2026-06-05T16:20:47Z):** Trinity delivered all 3 copy fixes (#1, #2, #3) on draft PR #12 (squad/1-phase1-truth-pass-copy-fixes). Pricing tiers fixed, homepage reads "seven parts", banned words removed, site builds cleanly.

### 2026-06-05 — Phase 1 ("Truth Pass") Milestone Closed
- **Task:** Close Phase 1 milestone and all 4 credibility-fix issues (#1, #2, #3, #4) after verification.
- **Outcome:** All issues closed and milestone marked complete.
  - #1 (pricing), #2 (book parts), #3 (banned words) → resolved by Trinity via merged PR #12
  - #4 (site audit) → verified by Tank; no violations found post-merge
- **Work Delivered:** Copy-only fixes grouped in single PR. No code changes. All 3 issues resolved atomically; audit confirmed compliance.
- **Decision Doc:** Written to `.squad/decisions/inbox/neo-phase1-closeout.md` — explains what was fixed, key insight (editorial work scales well with parallelism), and readiness for Phase 2.
- **Phase 2 Status:** Ready to proceed. Issues #5–#7 queued.
- **Scribe Update (2026-06-05T17:00:52Z):** Phase 1 closeout decision merged to `.squad/decisions.md`. All inbox files cleared. Team histories updated. Orchestration and session logs created.

### 2026-06-04 — Gated book download plan
- **Current subscribe flow:** `Index.cshtml` htmx form POSTs `SubscriberEmail` to `OnPostSubscribeAsync` (`/?handler=Subscribe`), validated by DataAnnotations, persisted by `FileSubscriberStore` (singleton, SemaphoreSlim, CSV `Email,SubscribedAtUtc` at `Data/subscribers.csv`). Returns `_SubscribeResult` partial; `data-show-modal` triggers thank-you modal. `Subscribers.cshtml` is an admin list.
- **Download precedent:** worksheet PDF is served UNGATED as a static file (`wwwroot/docs/...`). Book download must NOT follow this pattern — it must be gated.
- **Stack:** ASP.NET Core Razor Pages, .NET 10, MailKit, Markdig. No SQLite/EF package present yet. `IEmailSender` exists but confirmation email is commented out.
- **Decision:** EF Core SQLite + new `IContactStore`/`Contact` entity, capture-then-reveal gating. Recorded in decisions inbox.
- **Key paths:** `SimplicityFirst/Program.cs` (DI), `Services/ISubscriberStore.cs`, `Services/FileSubscriberStore.cs`, `Services/EmailSettings.cs`, `Pages/Index.cshtml(.cs)`, `Pages/Shared/_SubscribeResult.cshtml`.
- **TEAM UPDATE (Scribe):** Decision merged to decisions.md. Orchestration log created. Ready for task assignment.
