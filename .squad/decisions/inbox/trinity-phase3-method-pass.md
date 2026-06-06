# Decision: Phase 3 Method Pass Grouped Delivery

- **Author:** Trinity
- **Date:** 2026-06-05T21:19:39.121-04:00
- **Status:** Executed

Issues #8 and #9 are being delivered together on `squad/8-phase3-method-pass` with one draft PR.

## Why

Both issues rewrite the same homepage surface in `Index.cshtml`: the hero CTA target, the new method section, and the compressed philosophy band only make sense when reviewed as one narrative flow. Splitting them would force repeated edits in the same markup and increase the risk of landing the cards without the shortened "Why complexity wins" band they depend on.

## Scope

- Add the new "Method in 60 Seconds" section directly under the hero
- Compress the philosophy blockquotes into a tighter "Why Complexity Wins" band
- Retarget navigation and homepage CTA links to the new method section
- Keep the page flow as hero → method → economics → rest
