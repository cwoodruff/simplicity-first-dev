# Project Context

- **Owner:** Morpheus
- **Project:** ASP.NET Core site for essays and content with a planned gated book download flow
- **Stack:** ASP.NET Core Razor Pages on .NET 10 with C#, Markdown content, MailKit
- **Created:** 2026-06-04T19:11:30.363-04:00

## Learnings

- The new user journey starts on a site page where visitors request a book download in exchange for contact details.

## Active Work

### 2026-06-05 — Phase 1 Copy Fixes (Issues #1, #2, #3)
- **Assignment:** Neo assigned issues #1, #2, #3 to Trinity (2026-06-05T12:20:47Z)
  - **#1:** Fix pricing contradiction on Assessment page ($8-15K hero vs $12K/$16K/$20K tiers)
  - **#2:** Fix book parts count in homepage copy ("Six parts" → "Seven parts" + verify chapter count)
  - **#3:** Remove banned words from site copy ("cutting-edge", "robust")
- **Status:** All 3 ready to start immediately (no blockers)
- **Synergy:** Tank's audit (issue #4) feeds issue #3 — 3 violations documented in Index.cshtml (lines 626, 633, 813)
- **Scope:** All 3 issues are isolated page/copy changes — can run in parallel
- **COMPLETED (2026-06-05T16:20:47Z):** All 3 issues delivered on draft PR #12 (squad/1-phase1-truth-pass-copy-fixes). Pricing tiers fixed, homepage reads "seven parts", banned words removed, site builds cleanly.
- **PHASE 1 CLOSED (2026-06-05T17:00:52Z):** Milestone and all associated issues (#1–#4) now closed. PR #12 merged to dev. Scribe documented closeout decision and updated team records.

### 2026-06-05 — Phase 2 Hero Discipline Pass Completion
- **Assignment:** Neo assigned issues #5, #6, #7 to Trinity as grouped hero discipline pass (2026-06-05T13:01:28Z)
  - **#5:** Strip generic paragraph from hero sections
  - **#6:** Standardize all four heroes on Assessment template
  - **#7:** Fix floating logo collision in hero
- **Status:** COMPLETED (2026-06-05T17:10:27Z)
- **Delivery:** All 3 issues grouped on branch squad/5-phase2-hero-pass, draft PR #13
- **Outcome:**
  - Heroes standardized across Index, Manifesto, AI, and Assessment pages
  - Generic filler copy removed from hero sections
  - Floating hero diamond/video collision fixed by moving homepage video below hero
  - Site builds successfully
  - Desktop and mobile responsive layout validated
  - Brand consistency verified across all four heroes
- **Key insight:** Grouping reduced cognitive overhead and ensured consistent hero discipline across all pages. Single PR review cycle validated patterns holistically.
