# Project Context

- **Owner:** Morpheus
- **Project:** ASP.NET Core site for essays and content with a planned gated book download flow
- **Stack:** ASP.NET Core Razor Pages on .NET 10 with C#, Markdown content, MailKit
- **Created:** 2026-06-05T12:20:47.659-04:00

## Learnings

- The new user journey starts on a site page where visitors request a book download in exchange for contact details.
- Phase 1 truth-pass copy fixes can move together on one frontend branch because the pricing, homepage book copy, and banned-word cleanup all live in static user-facing content and validate cleanly in one pass.

- 2026-06-05T13:01:28.925-04:00 — Phase 2 hero work grouped on one branch because Index, Manifesto, AI, and Assessment all needed the same hero template pass and responsive verification together.
