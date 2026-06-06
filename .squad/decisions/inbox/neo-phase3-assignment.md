# Decision: Phase 3 ("Method in 60 Seconds") Triage & Assignment

**Author:** Neo (Lead)  
**Date:** 2026-06-05T21:19:39.121-04:00  
**Status:** Executed

## Overview

Triaged GitHub milestone "Phase 3: The Method in 60 Seconds" (2 issues) and assigned both to Trinity as a coordinated UX/content pass.

## Issues Assigned

| Issue | Title | Owner | Sequence | Status |
|-------|-------|-------|----------|--------|
| #8 | Add "The Method in 60 Seconds" section with Three Filters cards | squad:trinity | PRIMARY | Ready to start |
| #9 | Compress and demote philosophy blockquotes | squad:trinity | SECONDARY | Ready to start |

## Triage Rationale

### Work Type Analysis
Both issues are **pure page UX/content work** with no backend, data, or code-logic dependencies:
- **#8:** Information architecture redesign (new section placement) + responsive card layout + copy writing
- **#9:** Content compression (philosophy blockquotes) + repositioning (narrative reflow)

Per `.squad/routing.md`, page UX and forms → Trinity.

### Sequencing
- **#8 (PRIMARY):** Add the Three Filters card section below hero, compressed Complexity Trap intro
  - Removes scroll depth (reader reaches method immediately after hero)
  - Creates visual foundation for #9
  - Achieves "knowledge quickly" objective from plan
  
- **#9 (SECONDARY):** Compress and demote philosophy blockquotes
  - Depends on #8 being merged (needs new section placement context)
  - Can be worked in parallel for efficiency
  - Further reduces scroll depth by repositioning secondary narrative

### Parallelism & Dependencies
- Both issues can start simultaneously (no code blockers)
- #9 logically waits for #8 merge, but Trinity can plan/draft #9 while #8 is in review
- No cross-layer dependencies (no backend work, database, or API changes needed)

## Pattern Observation

**Phase 3 mirrors Phase 1 and Phase 2:** Grouped editorial/UX work by common concern (content architecture + narrative flow). This grouping strategy consistently delivers:
- Reduced review overhead
- Consistent brand voice and layout
- Atomic, verifiable completion
- Clear narrative flow from one issue to the next

Trinity can execute this as a coordinated two-part pass, similar to how Phase 2 (hero discipline) bundled three hero fixes.

## Acceptance Criteria Summary

**#8 (Method in 60s):**
- Section placed immediately after hero, before philosophy blockquotes
- Three equal-width cards (mobile: stack vertically)
- Each card: filter name, diagnostic question
- Complexity Trap intro compressed to one sentence
- Brand-consistent styling (near-black canvas, red accents, Bebas/JetBrains Mono)
- No scroll required on desktop
- Responsive tested (mobile, tablet, desktop)

**#9 (Philosophy compression):**
- Blockquote content reduced from four lengthy quotes to tight narrative
- Repositioned below Method section
- Flow validated: hero → method → economics → philosophy band
- Word count significantly reduced
- Responsive layout verified

## Next Steps

1. Trinity picks up #8 immediately
2. Both issues available in parallel; Trinity sequences as needed
3. After #8 merges to dev, Trinity proceeds with #9
4. Upon completion of both, Phase 3 is ready for verification and Phase 4 begins

---

**Decision Merged By:** Scribe (awaiting)
