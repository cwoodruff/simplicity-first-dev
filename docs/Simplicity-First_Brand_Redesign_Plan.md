# Simplicity-First Site Evaluation and Brand Redesign Plan

**Scope:** Home, Manifesto, AI, and Architecture Assessment pages at desktop and mobile widths. Evaluation based on rendered screenshots, full page copy, and the Simplicity-First brand and editorial standards.

## Overall verdict

The site is already on-brand and confident. The visual system is doing its job: near-black canvas, the #E31B23 red used as a scalpel rather than a wash, Bebas Neue carrying the headlines, JetBrains Mono on the stat labels. The Assessment hero ("Your Architecture Is Costing You More Than You Think") is the strongest screen on the site and should be the template the rest aspires to.

This is not a teardown. It is a sharpening pass. The brand impact is good. The problem is that the site does not yet practice the philosophy it preaches. It asks readers to cut bloat, then makes them scroll roughly 14,000px and read four long blockquotes before the methodology lands. A simplicity brand should deliver its own method faster than anyone else on the internet. Right now it does not.

## What is working (protect these)

The "Kill the Bloat." headline treatment, the red-on-white split, and the diamond mark read instantly as one system across all four pages. The Three Filters are well written and self-contained. The Assessment page is a strong sales asset: fixed pricing, the Findings Guarantee, the stat row, and the "you have already tried these things" empathy block. The manifesto is tight and quotable. The core type and color decisions should stay exactly as they are.

## Findings by priority

### Tier 1: Credibility leaks (fix before any redesign)

These cost trust regardless of how the site looks.

**Pricing contradicts itself on the Assessment page.** The hero says "$8-15K Fixed Price," but the pricing tiers below say $12,000 / $16,000 / $20,000. A CFO-grade buyer will notice, and the whole pitch is that the CFO can read the report. Pick one set of numbers and make them agree. Brand notes also reference a $6,500 to $9,500 Complexity Audit, so a third number may be floating in the materials. Reconcile everything to one price architecture.

**The book section miscounts its own parts.** The homepage says "Six parts. Twenty-five chapters," then lists seven parts (Part 1 through Part 7). Change to "Seven parts."

**Banned words appear in the site copy.** The homepage essay blurb uses "cutting-edge" ("fancy frameworks and cutting-edge libraries"), and the author bio uses "robust" ("building robust software solutions"). Both are on the banned-words CSV. For a brand whose editorial system is zero tolerance, these two words on the front door undercut the authority. Note: "comprehensive," which the working notes treat as banned, is not actually in the CSV, so the AI page use of it is clean.

### Tier 2: The hero is diluting its own punch

Below the "Kill the Bloat." headline and the sharp one-line positioning ("...built for humans, not for résumés"), there is a second muted-gray paragraph: "We advocate for clear and efficient solutions that eliminate unnecessary complexity. Using intelligent software architecture, practical design, and sharp engineering practices, we equip teams to..." This is the exact generic consultant voice the brand exists to kill. It adds words and subtracts force. Cut it entirely. The hero is stronger with the headline, the one-liner, and the two buttons and nothing else. On desktop the floating logo diamond also drifts into the bottom-left and collides with the YouTube embed. The Assessment hero, with no floating logo and a clean stat row, proves the logo is not needed there.

### Tier 3: "Knowledge quickly" is the real gap

A first-time CTO landing on the homepage cannot get the Simplicity-First method in one view. The Three Filters are the heart of the methodology, but they sit below the philosophy section and the book table of contents. Before a visitor reaches them, they have read four stacked blockquotes (Complexity Trap, Core Insight, What It Means, Operational Definition) that say overlapping things at length. The method should arrive within the first scroll, compressed into something a reader can screenshot and redraw from memory.

### Tier 4: Robustness (ironic for this brand)

Section content is gated behind scroll-reveal animations. In a static render with no scroll events, those sections stay invisible, which is why a full-page capture shows large empty bands. Normal users with JavaScript are fine, but a brand built on the 2 AM Test and operability-first should not have content that disappears if JavaScript hiccups or a crawler does not execute it. Make content visible by default and treat the fade-in as progressive enhancement.

## The redesign plan

Run it in four phases, cheapest to highest leverage first.

### Phase 1: Truth pass (an afternoon)

Reconcile all pricing to one number set. Fix "Seven parts." Replace "cutting-edge" and "robust." Run the entire site copy through the existing banned-words audit script, the same way the book chapters are gated. Nothing visual changes. Trust goes up immediately.

### Phase 2: Hero discipline (half a day)

Strip the hero's second paragraph. Standardize all four heroes on the Assessment template: kicker label in red mono, oversized Bebas headline with the red second clause, one tight sub-line, a stat or proof row, two buttons. Remove the floating logo collision. Every hero should be readable and complete in a single viewport.

### Phase 3: "The Method in 60 Seconds" (the core move, two to three days)

Add one new section directly under the hero, above everything else: the Complexity Trap stated in one sentence, then the Three Filters as three equal cards (2 AM Test, Half-Rule, Primary Path First), each with its one diagnostic question. One screen, no scrolling, screenshot-ready. This becomes the thing people share. Then demote and compress the existing philosophy blockquotes into a tighter "Why this happens" band beneath it. This single change is what fixes the "knowledge quickly" goal.

### Phase 4: Flow and conversion (two to three days)

Re-sequence the homepage so it tells one story: hook, then method in 60 seconds, then why complexity wins (the economics), then proof (case studies and numbers), then the book, then the author, then one clear next step. Right now the page has many strong sections but no single narrative spine, and the calls to action compete (Manifesto, Philosophy, Worksheet, Book signup, AI skills, Assessment). Pick a primary CTA per audience and make the rest secondary. Make content visible by default while working in the templates.

## A note on scope

Two honest caveats. First, the visual read is from rendered screenshots at two widths, not every breakpoint, real device, or interaction state, so a redesign should include a proper responsive and QA pass. Second, the deeper "knowledge quickly" win is an information-architecture decision, not a paint job, so Phase 3 is where the real effort belongs if only one thing gets done.
