# Squad Decisions

## Completed Phases

### Decision: Phase 1 ("Truth Pass") Closeout
- **Author:** Neo (Lead)
- **Date:** 2026-06-05T12:58:47.201-04:00
- **Status:** Completed

Phase 1 ("Truth Pass") milestone is now closed. All 4 credibility-fix issues (#1, #2, #3, #4) are resolved and verified.

**Issues Closed:**
| Issue | Title | Owner | Status |
|-------|-------|-------|--------|
| #1 | Fix pricing contradiction | Trinity | ✓ Merged (PR #12) |
| #2 | Fix book parts count | Trinity | ✓ Merged (PR #12) |
| #3 | Remove banned words | Trinity | ✓ Merged (PR #12) |
| #4 | Run full site audit | Tank | ✓ Verified |

**Outcome:** PR #12 ("fix: phase 1 truth-pass copy credibility leaks") merged to `dev`, resolving #1–#3 in a single grouped commit. Tank's audit (#4) confirmed zero banned-words violations post-merge.

**Key Insight:** Phase 1 work was purely editorial — no code changes, no dependencies, high-quality copy review. Delivery was fast and parallel-safe because each issue touched isolated text.

**Next:** Phase 2 ("Hero Discipline") can now proceed. Issues #5–#7 are queued and ready for assignment.

### Decision: Phase 2 ("Hero Discipline") Closeout
- **Author:** Neo (Lead)
- **Date:** 2026-06-05T21:07:09.893-04:00
- **Status:** Completed

Phase 2 ("Hero Discipline") milestone is now **closed**. All 3 hero issues (#5, #6, #7) are resolved and verified.

**Issues Closed:**
| Issue | Title | Owner | Status |
|-------|-------|-------|--------|
| #5 | Strip generic paragraph from hero sections | Trinity | ✓ Resolved (PR #13) |
| #6 | Standardize all four heroes on Assessment template | Trinity | ✓ Resolved (PR #13) |
| #7 | Fix floating logo collision in hero | Trinity | ✓ Resolved (PR #13) |

**Outcome:** Trinity delivered all 3 hero discipline issues grouped into a single coordinated pass on draft PR #13 (squad/5-phase2-hero-pass):

- **Heroes standardized:** Index, Manifesto, AI, and Assessment pages all follow consistent kicker/headline/subline/stats/buttons structure
- **Generic boilerplate removed:** Tighter, proof-driven copy replaces filler language
- **Logo collision fixed:** Video repositioned below hero section; no floating overlap
- **Responsive layout validated:** Desktop and mobile viewports tested; layout holds
- **Brand consistency verified:** All 4 heroes align on visual treatment and tone

**Key Insight:** Like Phase 1 (Truth Pass), Phase 2 grouping editorial/UX work by common concern (hero discipline) reduced review overhead and ensured consistent delivery. Grouping similar fixes on one branch scales well for cohesive front-end improvements.

**Next:** Phase 3 ("Method in 60s") is now ready to proceed. Issues #8–#9 queued.

### Decision: Phase 3 ("Method in 60 Seconds") Closeout
- **Author:** Neo (Lead)
- **Date:** 2026-06-05T21:40:40.114-04:00
- **Status:** Completed

Phase 3 ("The Method in 60 Seconds") milestone is now **closed**. All 2 method-section issues (#8, #9) are resolved and verified in draft PR #14.

**Issues Closed:**
| Issue | Title | Owner | Status |
|-------|-------|-------|--------|
| #8 | Add "The Method in 60 Seconds" section with Three Filters cards | Trinity | ✓ Resolved (PR #14) |
| #9 | Compress and demote philosophy blockquotes | Trinity | ✓ Resolved (PR #14) |

**Outcome:** Trinity delivered all 2 method-section issues grouped into a single coordinated pass on draft PR #14 (`squad/8-phase3-method-pass`):

- **Method section added:** Complexity Trap intro (one sentence) + Three Filters cards (2 AM Test, Half-Rule, Primary Path First) with diagnostic questions
- **Cards positioned:** Directly under hero, before philosophy blockquotes — no scroll required on desktop
- **Philosophy compressed:** Four lengthy blockquotes reduced to tight "Why Complexity Wins" band, repositioned below method section
- **Reader flow optimized:** hero → method → economics → philosophy → rest (honors "knowledge quickly" principle)
- **Responsive validated:** Desktop, tablet, mobile layouts tested; all viewports hold
- **Brand consistency:** Card design aligned with Simplicity-First (near-black canvas, red accents, Bebas/JetBrains Mono)

**Key Insight:** Like Phase 1 (Truth Pass) and Phase 2 (Hero Discipline), Phase 3 grouping information-architecture and narrative-flow work by common concern reduced review overhead and ensured consistent delivery. The pattern demonstrates that editorial/UX work at this scale (2–4 related issues) ships faster and more coherently when grouped into single coordinated passes.

**PR Status:**
- **PR #14:** Draft, stacked on PR #13 (Phase 2 hero pass)
- **Branch:** `squad/8-phase3-method-pass`
- **Merge readiness:** Ready for merge once Phase 2 (PR #13) lands to `dev`
- **Commit:** Single commit from Chris + Copilot with Phase 3 work and Trinity squad decision document

**Next:** Phase 4 ("Flow & Conversion") is queued and ready for triage once Phase 3 PR #14 merges.

---

## Active Decisions

### Decision: Phase 3 ("Method in 60 Seconds") Triage & Assignment
- **Author:** Neo (Lead)
- **Date:** 2026-06-05T21:19:39.121-04:00
- **Status:** Executed

Triaged GitHub milestone "Phase 3: The Method in 60 Seconds" (2 issues) and assigned both to Trinity as a coordinated UX/content pass.

**Issues Assigned:**
| Issue | Title | Owner | Sequence | Status |
|-------|-------|-------|----------|--------|
| #8 | Add "The Method in 60 Seconds" section with Three Filters cards | squad:trinity | PRIMARY | Ready to start |
| #9 | Compress and demote philosophy blockquotes | squad:trinity | SECONDARY | Ready to start |

**Triage Rationale:** Both issues are pure page UX/content work (information architecture redesign + card layout + copy writing). Per `.squad/routing.md`, page UX and forms → Trinity. No backend, data, or code-logic dependencies.

**Sequencing:**
- **#8 (PRIMARY):** Add Three Filters card section below hero; removes scroll depth; reader reaches method immediately post-hero
- **#9 (SECONDARY):** Compress philosophy blockquotes; depends on #8 merge but can draft in parallel

**Pattern Observation:** Phase 3 mirrors Phase 1 (Truth Pass) and Phase 2 (Hero Discipline) — grouped editorial/UX work by common concern. This strategy consistently delivers reduced review overhead, consistent brand voice, and atomic verifiable completion.

**Acceptance Criteria:**
- **#8:** Three equal-width cards (responsive); Complexity Trap intro one sentence; brand-consistent styling; no scroll on desktop
- **#9:** Blockquotes reduced and repositioned; flow validated; word count significantly reduced; responsive tested

**Next:** Trinity picks up #8 immediately. Both available in parallel; Trinity sequences as needed.

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

### Decision: Brand Redesign Plan Decomposition into GitHub Issues
- **Author:** Neo (Lead)
- **Date:** 2026-06-05T12:13:24.493-04:00
- **Status:** Implemented

Decomposed the Simplicity-First Brand Redesign Plan (4 phases, 62 lines) into 11 GitHub issues, organized by phase. Milestones created as phase containers. Issues include concrete acceptance criteria, references to plan sections, and enough detail for implementation without constant plan re-reading.

**Phases & Issue Mapping:**
- **Phase 1 (Truth Pass):** 4 issues — fix pricing, book parts, banned words, site audit
- **Phase 2 (Hero Discipline):** 3 issues — strip generic copy, standardize templates, fix logo collision
- **Phase 3 (Method in 60s):** 2 issues — add filters card section, compress philosophy quotes
- **Phase 4 (Flow & Conversion):** 2 issues — resequence narrative, enable content visibility

**Key choices:** One issue per discrete user-visible outcome; acceptance criteria prioritize verifiability; phase dependencies and rationale documented in issues.

### Decision: Playwright MCP Server Configuration
- **Author:** Switch (Backend Dev)
- **Date:** 2026-06-05T11:52:08.151-04:00
- **Status:** Implemented

Added Playwright MCP server entry to `.copilot/mcp-config.json`:
```json
"playwright": {
  "command": "npx",
  "args": ["-y", "@anthropic/playwright-mcp-server"]
}
```

Follows existing config pattern (npx, args array). No secrets required. Enables Copilot agents and developers to use Playwright MCP for browser automation without additional setup.

### Decision: Phase 1 — Truth Pass Issue Assignment & Sequencing
- **Author:** Neo (Lead)
- **Date:** 2026-06-05T12:20:47.659-04:00
- **Status:** Executed

Triaged and assigned all 4 Phase 1 ("Truth Pass") issues from the GitHub milestone. Created squad member labels and routed work per team routing rules.

**Assignment:**
- **#1 Fix pricing contradiction** → Trinity (Frontend Dev)
- **#2 Fix book parts count** → Trinity (Frontend Dev)
- **#3 Remove banned words from site copy** → Trinity (Frontend Dev)
- **#4 Run full site copy audit** → Tank (Tester)

**Rationale:** All 4 issues can start in parallel. No cross-layer dependencies; each is isolated page/copy change.

### Decision: Tank Phase 1 Audit — Banned-Words Violations
- **Author:** Tank (Tester)
- **Date:** 2026-06-05T12:20:47.659-04:00
- **Status:** Audit Complete

Banned-words audit completed across all primary pages (Index, Manifesto, AI, Assessment) and essay markdown.

**Violations Found: 2 words across 3 instances, all in Index.cshtml:**
1. "cutting-edge" — line 626 (essay preview card fallback text)
2. "robust" — line 633 (essay preview card fallback text)
3. "robust" — line 813 (author bio paragraph)

**Impact:** High on lines 626, 633 (visible on front page); Critical on line 813 (author bio, trust-building point).

**Fix Owner:** Trinity (copy). Single focused edit of three phrases achieves full compliance.

**Audit Scope:** Index.cshtml, Manifesto.cshtml, AI.cshtml, ArchAssessment.cshtml, manifesto.md, Essays/* — No violations in Manifesto.cshtml, AI.cshtml, ArchAssessment.cshtml, or essay markdown.

### Decision: Phase 2 ("Hero Discipline") Issue Assignment & Sequencing
- **Author:** Neo (Lead)
- **Date:** 2026-06-05T13:01:28.925-04:00
- **Status:** Executed

Triaged and assigned all 3 Phase 2 ("Hero Discipline") issues from the GitHub milestone. All assigned to Trinity as one coordinated hero pass.

**Issues Assigned:**
| Issue | Title | Owner | Status |
|-------|-------|-------|--------|
| #5 | Strip generic paragraph from hero sections | Trinity | squad:trinity |
| #6 | Standardize all four heroes on Assessment template | Trinity | squad:trinity |
| #7 | Fix floating logo collision in hero | Trinity | squad:trinity |

**Rationale:** All three issues are frontend-only fixes. Per routing, Page UX and forms route to Trinity. These form a coherent hero discipline pass with shared context (Assessment page and hero sections), low cross-dependency, and reduced review overhead when grouped.

**Acceptance Criteria:**
- Generic paragraph language removed from all hero sections
- Assessment page hero sections follow established template pattern
- Logo collision resolved; no regression on other sections
- Desktop and mobile viewports tested; responsive layout holds
- Brand consistency verified across all four heroes

**Key Insight:** Hero discipline is a single coherent improvement. Grouping reduces cognitive overhead and improves consistency review, similar to Phase 1 Truth Pass.

## Governance

- All meaningful changes require team consensus
- Document architectural decisions here
- Keep history focused on work, decisions focused on direction
