# Squad Decisions

## Active Decisions

### Decision: Gated Book Download — Contact Capture in SQLite
- **Author:** Neo (Lead)
- **Date:** 2026-06-04T19:11:30.363-04:00
- **Status:** Proposed (planning only — no code written)

**Storage:** Introduce SQLite via EF Core (`Microsoft.EntityFrameworkCore.Sqlite`).
**Separation of concerns:** Add NEW `IContactStore` + `Contact` entity (separate from email-only `ISubscriberStore`).
**Gating model:** Capture-then-reveal. Download link served after successful contact submission.
**Phased delivery** with explicit acceptance criteria.

**Open Questions:**
- Book title spelling: "Ecomnomics" (not auto-corrected)
- Different book from "Software Architecture Made Simple" or retitled?
- Where is the book file? (no asset in wwwroot yet)
- Migrate email-only CSV subscribers to SQLite or leave as-is?

### Decision: Copilot Onboarding Instructions
- **Author:** Neo
- **Date:** 2026-06-05T11:52:08.151-04:00
- **Status:** Implemented

**Outcome:** Created `.github/copilot-instructions.md` (295 lines) providing repository-specific guidance including Quick Start, Architecture, Conventions, Squad Context, Common Tasks, Troubleshooting, Philosophy Checklist, and Resources.

**Revised by:** Scribe (2026-06-05T11:52:08.151-04:00) per Tank's feedback — removed generic ASP.NET sections. Reduction: ~63% fewer words, ~52% fewer lines. Result: 141 lines of project-specific guidance.

**Status:** Applied — all generic material removed. Every section now justifies itself as repository-specific.

### Decision: Copilot Commands Discovery & Verification
- **Author:** Tank (Tester)
- **Date:** 2026-06-05T11:52:08.151-04:00
- **Status:** Documented

**Build:** `dotnet build` (or explicit: `dotnet build SimplicityFirst/SimplicityFirst.csproj --configuration Release`)  
**Publish:** `dotnet publish SimplicityFirst/SimplicityFirst.csproj -c Release -o ./publish`  
**Testing:** No test framework configured yet (test projects and xUnit/NUnit/MSTest required)  
**Linting:** `dotnet format` available; no `.editorconfig` or code style rules defined

**Recommendation:** Reference in copilot-instructions.md as-is; style enforcement and test infrastructure to be added separately.

## Governance

- All meaningful changes require team consensus
- Document architectural decisions here
- Keep history focused on work, decisions focused on direction
