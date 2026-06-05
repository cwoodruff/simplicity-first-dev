# Project Context

- **Owner:** Morpheus
- **Project:** ASP.NET Core site for essays and content with a planned gated book download flow
- **Stack:** ASP.NET Core Razor Pages on .NET 10 with C#, Markdown content, MailKit
- **Created:** 2026-06-04T19:11:30.363-04:00

## Learnings

- Team initialized to plan and deliver a book download flow that captures contact details into SQLite.

### 2026-06-04 — Gated book download plan
- **Current subscribe flow:** `Index.cshtml` htmx form POSTs `SubscriberEmail` to `OnPostSubscribeAsync` (`/?handler=Subscribe`), validated by DataAnnotations, persisted by `FileSubscriberStore` (singleton, SemaphoreSlim, CSV `Email,SubscribedAtUtc` at `Data/subscribers.csv`). Returns `_SubscribeResult` partial; `data-show-modal` triggers thank-you modal. `Subscribers.cshtml` is an admin list.
- **Download precedent:** worksheet PDF is served UNGATED as a static file (`wwwroot/docs/...`). Book download must NOT follow this pattern — it must be gated.
- **Stack:** ASP.NET Core Razor Pages, .NET 10, MailKit, Markdig. No SQLite/EF package present yet. `IEmailSender` exists but confirmation email is commented out.
- **Decision:** EF Core SQLite + new `IContactStore`/`Contact` entity, capture-then-reveal gating. Recorded in decisions inbox.
- **Key paths:** `SimplicityFirst/Program.cs` (DI), `Services/ISubscriberStore.cs`, `Services/FileSubscriberStore.cs`, `Services/EmailSettings.cs`, `Pages/Index.cshtml(.cs)`, `Pages/Shared/_SubscribeResult.cshtml`.
- **TEAM UPDATE (Scribe):** Decision merged to decisions.md. Orchestration log created. Ready for task assignment.
