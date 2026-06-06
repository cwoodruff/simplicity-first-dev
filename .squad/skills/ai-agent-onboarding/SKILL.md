# Skill: Philosophy-Driven AI Agent Onboarding

**Pattern:** Comprehensive, repository-specific instructions for AI agents that embed team philosophy and operational patterns.

## Context

When generic AI assistant instructions (e.g., "be helpful") meet a project with strong operational philosophy (e.g., Simplicity-First, 2 AM Test), the agent needs both:

1. **Technical routing** — what tools/layers to touch, team roles, branching conventions
2. **Philosophy grounding** — decisions should align with manifesto, not just "follow patterns"
3. **Future orientation** — cover planned architecture changes, not just current state

Generic docs fail because they lack the binding glue: *why* we build this way.

## The Pattern

### Structure (in `.github/copilot-instructions.md` or similar)

1. **Quick start** — Commands to build, run, test. Verify they work.
2. **Project structure** — ASCII tree showing key directories and their purpose.
3. **Architecture & philosophy** — Link operations to manifesto; embed philosophy checklist.
4. **Development conventions** — Naming, style, DI, error handling, validation.
5. **Squad/team context** — Roles, routing rules, branching convention, decision workflow.
6. **Common tasks** — Copy-paste templates for frequent work (new page, new service, etc.).
7. **Troubleshooting** — Real pain points, not hypotheticals.
8. **Resources** — Links to manifesto, charters, decision log, external docs.

### Key Principles

- **Philosophy first** — Every section ties operations back to why. "2 AM Test" appears in troubleshooting and philosophy checklist.
- **Squad-aware** — Explain how the agent fits into team roles. Link to charters. Document handoff points.
- **Future-proof** — Describe planned changes (e.g., SQLite migration) alongside current state (CSV). Don't prescribe timing.
- **Concise & complete** — ~300 lines. Enough to work autonomously; brief enough to scan before starting.
- **Operational** — Focus on what an agent needs to *do*, not architecture theory.

### Scope

**Covers:**
- Build, run, test commands (verified working)
- High-level architecture (layers, key files, DI pattern)
- Coding conventions (naming, style, error handling)
- Team integration (roles, routing, branching, decisions)
- Common tasks with examples
- Known troubleshooting
- Philosophy/checklist

**Does not cover:**
- Deep implementation (e.g., "how to implement EF Core migrations" — that's a specialist task)
- Detailed API docs (link to external sources instead)
- UI/UX decisions (that's a specialist's domain)

### When to Use

✅ **Do use this pattern when:**
- The project has a distinct philosophy or operational principles
- The team uses specialization/agents/routing
- Future architectural changes are planned but not yet implemented
- The codebase is non-trivial but benefits from clear onboarding

❌ **Don't use this pattern when:**
- The project is a one-off utility with no planned evolution
- The team is purely freelance with no routing
- The project is so simple that one `.md` file would be redundant

## Example Output

See `.github/copilot-instructions.md` in simplicity-first-dev:

- 295 lines
- Ties all operational guidance back to 2 AM Test, Half-Rule, Primary Path First
- Explains squad roles and how Copilot fits in
- Covers current CSV storage and planned SQLite migration
- Includes common tasks (new page, new service, email, essay, migration)
- Lists troubleshooting and a philosophy checklist

## Benefits

1. **Autonomy** — AI agents can start work without asking for context
2. **Philosophy adherence** — Operations align with team values, not just convenience
3. **Reduced rework** — Common mistakes (over-engineering, skipping tests, wrong patterns) are pre-empted
4. **Team scaling** — New humans *and* new agents onboard the same way
5. **Future-ready** — Roadmap is visible; agents don't over-build for current-only constraints

## Implementation Checklist

- [ ] Read `.squad/decisions.md` and manifesto
- [ ] Map project structure (directories, key files, DI pattern)
- [ ] Verify build/run commands work
- [ ] Identify 3-5 common tasks agents will perform
- [ ] List real troubleshooting scenarios (ask the team)
- [ ] Identify philosophy checkpoints (2 AM Test, etc.)
- [ ] Extract squad roles and routing rules
- [ ] Document planned architecture changes
- [ ] Create `.github/copilot-instructions.md` (300–400 lines)
- [ ] Link to external docs, manifesto, charters
- [ ] Review with at least one squad member

---

**First used:** 2026-06-05 in simplicity-first-dev  
**Author:** Neo  
**Related:** Squad pattern, philosophy-driven operations
