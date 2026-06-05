# Project Context

- **Owner:** Morpheus
- **Project:** ASP.NET Core site for essays and content with a planned gated book download flow
- **Stack:** ASP.NET Core Razor Pages on .NET 10 with C#, Markdown content, MailKit
- **Created:** 2026-06-04T19:11:30.363-04:00

## Learnings

- The feature needs both contact capture validation and download authorization/file-delivery coverage.

### 2026-06-05 — Build/Test/Lint Commands Verification
- **Status:** Documented and merged to decisions.md (2026-06-05T15:52:08Z UTC)
- **Build verification:** ✅ `dotnet build` confirmed (also explicit form: `dotnet build SimplicityFirst/SimplicityFirst.csproj --configuration Release`)
- **Publish verification:** ✅ `dotnet publish SimplicityFirst/SimplicityFirst.csproj -c Release -o ./publish`
- **Test status:** ❌ No test framework configured (xUnit/NUnit/MSTest not present; test projects absent)
- **Lint status:** ✅ `dotnet format` available; no `.editorconfig` or style rules defined
- **Role:** Validated Neo's copilot-instructions draft against actual project state; provided feedback rejecting generic ASP.NET content; supplied verified commands for Scribe to reference
- **Outcome:** Decision captured and ready for copilot-instructions.md reference when needed

### 2026-06-05 — Phase 1 Banned-Words Audit (Issue #4)
- **Status:** ✅ Complete. Violations documented. Ready for Trinity (copy).
- **Time:** Audit completed 2026-06-05T16:23:49Z
- **Findings:** 3 violations of 2 banned words (cutting-edge, robust) — all in Index.cshtml
  - Line 626: "...cutting-edge libraries..." (essay preview fallback)
  - Line 633: "...robustness." (essay preview fallback)
  - Line 813: "...robust software solutions." (author bio)
- **Clear:** Manifesto.cshtml, AI.cshtml, ArchAssessment.cshtml, manifesto.md, all essay markdown files
- **Audit scope:** Systematic grep across all 4 primary pages + 5 essay markdown files
- **Output:** Issue comment + decision memo in `.squad/decisions/inbox/tank-phase1-audit.md`
- **Risk:** All violations visible on homepage (high credibility impact). Focused fix—three phrases in one file.
- **Acceptance:** AC satisfied. Audit method documented, violations logged, pre-publish checklist established.
- **Scribe Update:** Tank's audit decision merged to `.squad/decisions.md` (2026-06-05T16:25:52Z). Feeding Trinity's issue #3 (copy fixes).
- **COMPLETION NOTICE (2026-06-05T16:20:47Z):** Trinity delivered Phase 1 copy fixes (#1, #2, #3) on draft PR #12. All banned words removed, pricing fixed, homepage reads "seven parts", site builds cleanly.
- **PHASE 1 CLOSED (2026-06-05T17:00:52Z):** Issue #4 closed. All Phase 1 objectives verified. Scribe finalized milestone closeout and updated team records.
