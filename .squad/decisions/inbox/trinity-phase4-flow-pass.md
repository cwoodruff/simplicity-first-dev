# Decision: Phase 4 Flow Pass Grouped Delivery

- **Author:** Trinity
- **Date:** 2026-06-06T05:59:17.229-04:00
- **Status:** Executed

Issues #10 and #11 are being delivered together on `squad/10-phase4-flow-pass` with one draft PR.

## Why

Both issues change the same homepage flow in `Index.cshtml` and rely on the same verification pass in `site.css` and `site.js`. The narrative resequencing only works if the reveal behavior stops hiding content by default, and the progressive-enhancement fix only pays off if the homepage sections are reordered around one clear CTA instead of several competing ones.

## Scope

- Resequence the homepage to read as method → economics → proof → book → author → next step
- Promote the Architecture Assessment as the primary CTA and demote secondary paths
- Move essays and AI into a lower-emphasis resources section
- Make scroll reveal enhancement-only so static renders and no-JavaScript loads still show the full page
