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

## Governance

- All meaningful changes require team consensus
- Document architectural decisions here
- Keep history focused on work, decisions focused on direction
