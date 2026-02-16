# The Simplicity-First Manifesto

Because complexity is not a sign of sophistication. It is a sign that we stopped asking the right questions.

## The Problem
Software systems are becoming harder to understand, harder to change, and harder to operate. Not because the problems are harder. Because the solutions have outgrown the problems they were built to solve.
Teams add services, abstractions, layers, and tools in the name of flexibility. Then they discover they can’t ship a feature without touching seven repositories, consulting three teams, and running a deployment pipeline that takes longer than the code change itself.
This is the Complexity Trap: a self-reinforcing cycle where each addition seems reasonable in isolation, but collectively produces systems nobody fully understands or can safely change.
We believe this cycle is not inevitable. We believe teams can build systems that are simple, understandable, and a genuine pleasure to work on. We believe they can ship features quickly and confidently. We believe they can sleep through the night.

## What We Believe
**A system is simple if a tired, stressed, unfamiliar engineer can understand it well enough to fix it quickly.** This is our operational definition. It does not care about elegant abstractions or clever patterns. It cares about one thing: can this system be operated under stress by normal humans?

**Simplicity is not the absence of capability. It is the presence of clarity.** Simple systems do real work for real users. They handle edge cases, process transactions, serve millions of requests. What makes them simple is that their design respects human cognition: the paths are traceable, the boundaries are visible, and the behavior is predictable.

**Over-engineering is a structural incentive problem, not a discipline problem.** When building comprehensive makes you look thorough and building simple makes you look lazy, rational engineers will over-engineer every time. Coding standards and best-practices documents fail because they ask people to play against their own incentives. The game itself needs to change.

**Every team has a complexity budget.** This is not a metaphor. It is a real constraint on what your organization can handle. Complexity costs you in cognition, operations, latency, and coordination. When teams overbuild early, they spend complexity budget on imaginary problems. Then real problems arrive and the budget is gone.

**Simpler systems are greener systems.** Software has an environmental footprint. Microservice architectures consume roughly 20% more CPU and 44% more energy than monoliths doing the same work. Every unnecessary network hop, every duplicated infrastructure component, every idle container contributes real carbon emissions. The principles that make systems easier to understand also make them lighter on the planet.

## Three Filters
Every architectural decision passes through three questions.

**The 2 AM Test:** Could a developer who didn’t build this system understand it, troubleshoot it, and fix it at 2 AM, under stress, with limited support? If not, the architecture has failed the only test that matters in production.

**The Half-Rule:** Build half of what you think you need. Treat the rest as a hypothesis. Ship. Learn. Then decide what the other half should really be.

**Primary Path First:** Design for the 95% case. Make the primary path boring, resilient, and fast to understand. Contain edge cases behind seams. The edge cases are real. The question is not whether to handle them, but where.

## Four Commitments

* We refuse architectures that require heroics.
* We don’t ship features we cannot support in production.
* We consider debuggability and operability first-class requirements.
* We keep it simple, keep it clean, and don’t let the bloat win.

## The Invitation
The Complexity Trap is real, but it is not inevitable. Teams escape it every day. They build systems that pass the 2 AM Test. They ship with confidence. They onboard new developers in days instead of months. They spend their engineering hours on problems that matter instead of fighting their own tools.

You can join them.

Start with one question at your next architecture review: “Could a tired engineer debug this at 2 AM?”

If the answer is no, you know where to begin.
