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
